using SensorLogInserterRe.Daos;
using SensorLogInserterRe.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueryTestCHORALE
{
    class Program
    {

        volatile static bool _keyReaded = false;
        static DataTable LatencyTesttimeTable;
        static void Main(string[] args)
        {
            ExecuteTest();
            Console.WriteLine("If Press Any Key, This program will be closed.");
            Console.ReadKey(true);
        }
       　static void ExecuteTest()
        {
            int parallel = 5;
            int size = 1000;
            DataTable LatencyTestTable = new DataTable();
            LatencyTestTable = DataTableUtil.GetLatencyTestTable(LatencyTestTable);
            DataRow dataRow = LatencyTestTable.NewRow();
            dataRow.SetField(LatencyTestDao.ColumnStartTime, DateTime.Now);
            Console.WriteLine(dataRow.Field<DateTime>(LatencyTestDao.ColumnStartTime));
            dataRow.SetField(LatencyTestDao.ColumnParallel, parallel);
            dataRow.SetField(LatencyTestDao.ColumnSize, size);
            dataRow.SetField(LatencyTestDao.ColumnDescription, "CHORALEクエリTestVer2");
            LatencyTestTable.Rows.Add(dataRow);
            LatencyTestDao.Insert(LatencyTestTable);

            ExecuteMethod(parallel, size, LatencyTestDao.GetMaxId());
            
        }

        async static void ExecuteMethod(int n, int size, int testId)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(MyHandler), null);
            LatencyTesttimeTable = new DataTable();
            LatencyTesttimeTable = DataTableUtil.GetLatencyTesttimeTable(LatencyTesttimeTable);

            for (int t = 0; t < size; t++)
            {

                if (_keyReaded)
                {
                    Console.WriteLine("キーが押されました");
                    break;
                }

                var semanticLinkList = getSemanticLinkList();

                List<Task> arrayTask = new List<Task>();

                for (int i = 0; i < n; i++)
                {
                    int index = getRandomIndex(arrayTask.Count);
                    var task = Task.Run(() => ExecuteCHORALEQuery(semanticLinkList[index].Item1, 
                        semanticLinkList[index].Item2, i, t, testId));
                    arrayTask.Add(task);
                }

                await Task.WhenAll(arrayTask);

                

            }
            Console.WriteLine("end.");
            LatencyTesttimeDao.Insert(LatencyTesttimeTable);
            LatencyTestDao.UpdateEndtime(DateTime.Now, testId);
        }
        static List<Tuple<int, string>> getSemanticLinkList()
        {
            List<Tuple<int, string>> tupleList = new List<Tuple<int, string>>();

            foreach (int i in Enumerable.Range(187, 15))
            {
                addTupleList(ref tupleList, i, "outward");
            }

            foreach (int i in Enumerable.Range(202, 17))
            {
                addTupleList(ref tupleList, i, "homeward");
            }

            foreach (int i in Enumerable.Range(332, 7))
            {
                addTupleList(ref tupleList, i, "outward");
            }

            foreach (int i in Enumerable.Range(333, 7))
            {
                addTupleList(ref tupleList, i, "homeward");
            }

            return tupleList;
        }

        static int getRandomIndex(int listCount)
        {
            System.Random r = new System.Random(0);
            int index = r.Next(listCount);
            return index;
        }

        static void addTupleList(ref List<Tuple<int, string>> tupleList, int semanticLinkID, string tripDirection)
        {
            Tuple<int, string> tuple = new Tuple<int, string>(semanticLinkID, tripDirection);
            tupleList.Add(tuple);
        }

        static void MyHandler(object userState)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            _keyReaded = true;
        }

        static void Anything()
        {

            Console.WriteLine("Hello");
            Thread.Sleep(1000);

        }

        static void ExecuteCHORALEQuery(int semanticLinkID, string tripDirection, int parallel, int size, int testid)
        {
            string query = "SELECT COUNT(*), SUM(LOST_ENERGY)"+
            "FROM ECOLOG_Doppler_NotMM, SEMANTIC_LINKS" +
            "WHERE ECOLOG_Doppler_NotMM.DRIVER_ID = SEMANTIC_LINKS.DRIVER_ID AND SEMANTIC_LINKS.SEMANTIC_LINK_ID = " +
            semanticLinkID + "AND SEMANTIC_LINKS.LINK_ID = ECOLOG_Doppler_NotMM.LINK_ID" +
            "AND ECOLOG_Doppler_NotMM.TRIP_DIRECTION = "+ tripDirection + 
            "GROUP BY TRIP_ID";

            //Stopwatchオブジェクトを作成する
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //ストップウォッチを開始する
            sw.Start();

            //クエリ実行
            DatabaseAccesser.GetResult(query);

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            DataRow dataRow = LatencyTesttimeTable.NewRow();
            dataRow.SetField(LatencyTesttimeDao.ColumnTestId, testid);
            dataRow.SetField(LatencyTesttimeDao.ColumnParallelNum, parallel);
            dataRow.SetField(LatencyTesttimeDao.ColumnSizeNum, size);
            dataRow.SetField(LatencyTesttimeDao.ColumnLatency, sw.Elapsed);

            LatencyTesttimeTable.Rows.Add(dataRow);
        }
    }
}
