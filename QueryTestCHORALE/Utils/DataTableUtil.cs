using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorLogInserterRe.Daos;

namespace SensorLogInserterRe.Utils
{
    static class DataTableUtil
    {
        public static DataTable GetTripsRawTable()
        {
            DataTable tripsRawTable = new DataTable();

            // TODO string 直書きでなく、Daoのstaticフィールドを参照に
            tripsRawTable.Columns.Add(new DataColumn("DRIVER_ID", typeof(int)));
            tripsRawTable.Columns.Add(new DataColumn("CAR_ID", typeof(int)));
            tripsRawTable.Columns.Add(new DataColumn("SENSOR_ID", typeof(int)));
            tripsRawTable.Columns.Add(new DataColumn("START_TIME", typeof(DateTime)));
            tripsRawTable.Columns.Add(new DataColumn("END_TIME", typeof(DateTime)));
            tripsRawTable.Columns.Add(new DataColumn("START_LATITUDE", typeof(double)));
            tripsRawTable.Columns.Add(new DataColumn("START_LONGITUDE", typeof(double)));
            tripsRawTable.Columns.Add(new DataColumn("END_LATITUDE", typeof(double)));
            tripsRawTable.Columns.Add(new DataColumn("END_LONGITUDE", typeof(double)));

            return tripsRawTable;
        }

        public static DataTable GetTripsTable()
        {
            DataTable tripsTable = new DataTable();

            // TODO string 直書きでなく、Daoのstaticフィールドを参照に
            tripsTable.Columns.Add(new DataColumn("TRIP_ID", typeof(int)));
            tripsTable.Columns.Add(new DataColumn("DRIVER_ID", typeof(int)));
            tripsTable.Columns.Add(new DataColumn("CAR_ID", typeof(int)));
            tripsTable.Columns.Add(new DataColumn("SENSOR_ID", typeof(int)));
            tripsTable.Columns.Add(new DataColumn("START_TIME", typeof(DateTime)));
            tripsTable.Columns.Add(new DataColumn("END_TIME", typeof(DateTime)));
            tripsTable.Columns.Add(new DataColumn("START_LATITUDE", typeof(double)));
            tripsTable.Columns.Add(new DataColumn("START_LONGITUDE", typeof(double)));
            tripsTable.Columns.Add(new DataColumn("END_LATITUDE", typeof(double)));
            tripsTable.Columns.Add(new DataColumn("END_LONGITUDE", typeof(double)));
            tripsTable.Columns.Add(new DataColumn("CONSUMED_ENERGY", typeof(Single)));
            tripsTable.Columns.Add(new DataColumn("TRIP_DIRECTION", typeof(string)));
            tripsTable.Columns.Add(new DataColumn("VALIDATION", typeof(string)));

            return tripsTable;
        }

        public static DataTable GetAndroidGpsRawDopplerTable()
        {
            // TODO 並び順をデータベース通りに
            // TODO string 直書きでなく、Daoのstaticフィールドを参照に
            DataTable gpsRawTable = new DataTable();

            gpsRawTable.Columns.Add(new DataColumn("DRIVER_ID", typeof(int)));
            gpsRawTable.Columns.Add(new DataColumn("CAR_ID", typeof(int)));
            gpsRawTable.Columns.Add(new DataColumn("SENSOR_ID", typeof(int)));
            gpsRawTable.Columns.Add(new DataColumn("JST", typeof(DateTime)));
            gpsRawTable.Columns.Add(new DataColumn("LATITUDE", typeof(double)));
            gpsRawTable.Columns.Add(new DataColumn("LONGITUDE", typeof(double)));
            gpsRawTable.Columns.Add(new DataColumn("ALTITUDE", typeof(double)));
            gpsRawTable.Columns.Add(new DataColumn("ACCURACY", typeof(int)));
            gpsRawTable.Columns.Add(new DataColumn("SPEED", typeof(double)));
            gpsRawTable.Columns.Add(new DataColumn("BEARING", typeof(double)));
            gpsRawTable.Columns.Add(new DataColumn("ANDROID_TIME", typeof(DateTime)));

            return gpsRawTable;
        }

        public static DataTable GetAndroidGpsRawTable()
        {
            // TODO 並び順をデータベース通りに
            // TODO string 直書きでなく、Daoのstaticフィールドを参照に
            DataTable gpsRawTable = new DataTable();

            gpsRawTable.Columns.Add(new DataColumn("DRIVER_ID", typeof(int)));
            gpsRawTable.Columns.Add(new DataColumn("CAR_ID", typeof(int)));
            gpsRawTable.Columns.Add(new DataColumn("SENSOR_ID", typeof(int)));
            gpsRawTable.Columns.Add(new DataColumn("JST", typeof(DateTime)));
            gpsRawTable.Columns.Add(new DataColumn("LATITUDE", typeof(double)));
            gpsRawTable.Columns.Add(new DataColumn("LONGITUDE", typeof(double)));
            gpsRawTable.Columns.Add(new DataColumn("ALTITUDE", typeof(double)));
            gpsRawTable.Columns.Add(new DataColumn("ANDROID_TIME", typeof(DateTime)));

            return gpsRawTable;
        }

        public static DataTable[] GetAndroidGpsRawTableArray(int n)
        {
            // TODO 並び順をデータベース通りに
            // TODO string 直書きでなく、Daoのstaticフィールドを参照に
            DataTable[] gpsRawTable = new DataTable[n];
            for (int i = 0; i < n; i++)
            {
                gpsRawTable[i] = new DataTable();
                gpsRawTable[i].Columns.Add(new DataColumn("DRIVER_ID", typeof(int)));
                gpsRawTable[i].Columns.Add(new DataColumn("CAR_ID", typeof(int)));
                gpsRawTable[i].Columns.Add(new DataColumn("SENSOR_ID", typeof(int)));
                gpsRawTable[i].Columns.Add(new DataColumn("JST", typeof(DateTime)));
                gpsRawTable[i].Columns.Add(new DataColumn("LATITUDE", typeof(double)));
                gpsRawTable[i].Columns.Add(new DataColumn("LONGITUDE", typeof(double)));
                gpsRawTable[i].Columns.Add(new DataColumn("ALTITUDE", typeof(double)));
                gpsRawTable[i].Columns.Add(new DataColumn("ANDROID_TIME", typeof(DateTime)));
            }
            return gpsRawTable;
        }

        public static DataTable[] GetAndroidGpsRawDopplerTableArray(int n)
        {
            // TODO 並び順をデータベース通りに
            // TODO string 直書きでなく、Daoのstaticフィールドを参照に
            DataTable[] gpsRawTable = new DataTable[n];
            for (int i = 0; i < n; i++)
            {
                gpsRawTable[i] = new DataTable();
                gpsRawTable[i].Columns.Add(new DataColumn("DRIVER_ID", typeof(int)));
                gpsRawTable[i].Columns.Add(new DataColumn("CAR_ID", typeof(int)));
                gpsRawTable[i].Columns.Add(new DataColumn("SENSOR_ID", typeof(int)));
                gpsRawTable[i].Columns.Add(new DataColumn("JST", typeof(DateTime)));
                gpsRawTable[i].Columns.Add(new DataColumn("LATITUDE", typeof(double)));
                gpsRawTable[i].Columns.Add(new DataColumn("LONGITUDE", typeof(double)));
                gpsRawTable[i].Columns.Add(new DataColumn("ALTITUDE", typeof(double)));
                gpsRawTable[i].Columns.Add(new DataColumn("ACCURACY", typeof(int)));
                gpsRawTable[i].Columns.Add(new DataColumn("SPEED", typeof(double)));
                gpsRawTable[i].Columns.Add(new DataColumn("BEARING", typeof(double)));
                gpsRawTable[i].Columns.Add(new DataColumn("ANDROID_TIME", typeof(DateTime)));
            }
            return gpsRawTable;
        }

        public static DataTable GetAndroidAccRawTable()
        {
            // TODO 並び順をデータベース通りに
            // TODO string 直書きでなく、Daoのstaticフィールドを参照に
            DataTable accRawTable = new DataTable();

            accRawTable.Columns.Add(new DataColumn("DRIVER_ID", typeof(int)));
            accRawTable.Columns.Add(new DataColumn("CAR_ID", typeof(int)));
            accRawTable.Columns.Add(new DataColumn("SENSOR_ID", typeof(int)));
            accRawTable.Columns.Add(new DataColumn("DATETIME", typeof(DateTime)));
            accRawTable.Columns.Add(new DataColumn("ACC_X", typeof(Single)));
            accRawTable.Columns.Add(new DataColumn("ACC_Y", typeof(Single)));
            accRawTable.Columns.Add(new DataColumn("ACC_Z", typeof(Single)));

            return accRawTable;
        }





        public static DataTable GetTempCorrectedAccTable(DataTable table)
        {
            table.Columns.Add(new DataColumn("ROLL", typeof(Single)));
            table.Columns.Add(new DataColumn("PITCH", typeof(Single)));
            table.Columns.Add(new DataColumn("YAW", typeof(Single)));

            //補正データを記録するためのカラムを追加
            table.Columns.Add(new DataColumn("ALPHA", typeof(Single)));
            table.Columns.Add(new DataColumn("VECTOR_X", typeof(Single)));
            table.Columns.Add(new DataColumn("VECTOR_Y", typeof(Single)));
            table.Columns.Add(new DataColumn("BETA", typeof(Single)));
            table.Columns.Add(new DataColumn("GAMMA", typeof(Single)));

            return table;
        }

        public static DataTable GetLatencyTestTable(DataTable table)
        {
            table.Columns.Add(new DataColumn(LatencyTestDao.ColumnTestId, typeof(int)));
            table.Columns.Add(new DataColumn(LatencyTestDao.ColumnStartTime, typeof(DateTime)));
            table.Columns.Add(new DataColumn(LatencyTestDao.ColumnEndTime, typeof(DateTime)));
            table.Columns.Add(new DataColumn(LatencyTestDao.ColumnParallel, typeof(int)));
            table.Columns.Add(new DataColumn(LatencyTestDao.ColumnSize, typeof(int)));
            table.Columns.Add(new DataColumn(LatencyTestDao.ColumnDescription, typeof(string)));

            return table;
        }
        public static DataTable GetLatencyTesttimeTable(DataTable table)
        {
            table.Columns.Add(new DataColumn(LatencyTesttimeDao.ColumnTestId, typeof(int)));
            table.Columns.Add(new DataColumn(LatencyTesttimeDao.ColumnParallelNum, typeof(int)));
            table.Columns.Add(new DataColumn(LatencyTesttimeDao.ColumnSizeNum, typeof(int)));
            table.Columns.Add(new DataColumn(LatencyTesttimeDao.ColumnLatency, typeof(TimeSpan)));

            return table;
        }
    }
}
