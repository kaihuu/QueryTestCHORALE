using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorLogInserterRe.Daos
{
    class LatencyTestDao
    {
        public static readonly string TableName = "LATENCY_TEST";
        public static readonly string ColumnTestId = "TEST_ID";
        public static readonly string ColumnStartTime = "START_TIME";
        public static readonly string ColumnEndTime = "END_TIME";
        public static readonly string ColumnParallel = "PARALLEL";
        public static readonly string ColumnSize = "SIZE";
        public static readonly string ColumnDescription = "DESCRIPTION";

        public static void Insert(DataTable dataTable)
        {
            DatabaseAccesser.Insert(TableName, dataTable);
        }

        public static DataTable Get()
        {
            string query = "SELECT * FROM " + TableName;

            return DatabaseAccesser.GetResult(query);
        }

        public static int GetMaxId()
        {
            string query = "SELECT MAX(" + ColumnTestId + ") as max_id FROM " + TableName;

            return DatabaseAccesser.GetResult(query).Rows[0].Field<int>("max_id");
        }

        public static void UpdateEndtime(DateTime endtime, int testId)
        {
            string query = "UPDATE " + TableName + " SET END_TIME = '"+ endtime + "' WHERE TEST_ID = " + testId;

            DatabaseAccesser.Update(query);
        }

    }
}
