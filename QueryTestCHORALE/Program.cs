using SensorLogInserterRe.Daos;
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
        DataTable dataTable = new DataTable();

        static void Main(string[] args)
        {
            ExecuteMethod();
            Console.ReadKey(true);
        }

        static void ExecuteMethod()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(MyHandler), null);

            for (; ; )
            {
                if (_keyReaded)
                {
                    Console.WriteLine("キーが押されました");
                    break;
                }

                Console.Write("Sleep in....");
                for (int i = 0; i < 1; i++)
                {
                    Task.Run(() => ExecuteCHORALEQuery(1, 1, "homeward"));
                }
                
                Console.WriteLine("end.");
                break;
            }
            
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

        static void ExecuteCHORALEQuery(int semanticLinkID, int driverID, string tripDirection)
        {
            string query = "SELECT COUNT(*), SUM(LOST_ENERGY)"+
            "FROM ECOLOG_Doppler_NotMM, SEMANTIC_LINKS" +
            "WHERE ECOLOG_Doppler_NotMM.DRIVER_ID = " + driverID + "AND SEMANTIC_LINKS.SEMANTIC_LINK_ID = " +
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
        }
    }
}
