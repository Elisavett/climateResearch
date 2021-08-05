using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Web;
using climateResearch.Models.Entities;
using climateResearch.Models.ViewModels;
using MySql.Data.MySqlClient;

namespace climateResearch.ExternalDatabase
{
    public class DBManager
    {

        const string connectionString1 = ";";
        const string connectionString2 = "Server=imces.ru;Username=site;Database=apik3;Port=22303;Password=f2VXz3_7";
        public static string getDbJsonData(PhysicalQuantity physicalQuantity)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            List<Sensor> sensorList = new List<Sensor>(physicalQuantity.Sensors);
            List<ObservationPointOnMap> obsPointValues = new List<ObservationPointOnMap>();
            string valueUnit = physicalQuantity.Unit;
            foreach(Sensor sensor in sensorList)
            {
                ObservationPointOnMap obsPoint = new ObservationPointOnMap(sensor.MeasuringInstrument.ObservationPoint);
                string dbName = sensor.DbName;
                string connectionString;
                if (dbName.Equals("apik3")) connectionString = connectionString1;
                else connectionString = connectionString2;
                string commandString = "SELECT `" + sensor.Designation + "` FROM `" + sensor.DbTable + "` order by `time` desc limit 1";
                obsPoint.MeasuredValue = getLastValueFromDB(connectionString, commandString) + valueUnit;
                obsPointValues.Add(obsPoint);
            }
            return JsonSerializer.Serialize(obsPointValues, options);
        }
        private static double getLastValueFromDB(string connectionString, string commandString)
        {
            MySqlConnectionStringBuilder connBuilder = new MySqlConnectionStringBuilder();
            connBuilder.AllowBatch = true;
            connBuilder.Server = "imces.ru";
            connBuilder.Port = 22303;
            connBuilder.UserID = "site";
            connBuilder.Password = "ff2VXz3_7";
            connBuilder.Database = "apik3";
            connBuilder.SslMode = MySqlSslMode.None;


            double value = 0;
            using (MySqlConnection conn = new MySqlConnection(connBuilder.ConnectionString))
            {
                conn.Open();
                using (var command = new MySqlCommand(commandString, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        value = reader.GetDouble(0);
                    }
                }
            }
            return Math.Round(value*100)/100;
        }
    }
}