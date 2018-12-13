using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorLogInserterRe.Daos
{
    class LatencyTesttimeDao
    {
        public static readonly string TableName = "LATENCY_TESTTIME";
        public static readonly string ColumnTestId = "TEST_ID";
        public static readonly string ColumnParallelNum = "PARALLEL_NUM";
        public static readonly string ColumnSizeNum = "SIZE_NUM";
        public static readonly string ColumnLatency = "LATENCY";

        public static void Insert(DataTable dataTable)
        {
            DatabaseAccesser.Insert(TableName, dataTable);
        }

        public static DataTable Get()
        {
            string query = "SELECT * FROM " + TableName;

            return DatabaseAccesser.GetResult(query);
        }
    }
}
