using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace USB_205_DataAccquisition
{
    static class Globals
    {
        //string sql = "datasource=localhost;port=3306;username=root;password=;database=usb205db";
        //string sql = "datasource=localhost;port=3308;username=root;password=helloworld;database=db;Convert Zero Datetime=True";
        //string sql = "datasource=database-1.crdizhrpr8gd.us-east-1.rds.amazonaws.com;port=3306;username=root;password=12345678;database=datebase1;Convert Zero Datetime=True";
        public static string sql = "datasource=awssterprojekt.c0vme02i9e9r.eu-central-1.rds.amazonaws.com;port=3306;username=admin;password=Maciej1!!;database=usb205db;Convert Zero Datetime=True";
        public static int tp = (int)(DbSessionSettings.SearchSessionSettings().tp*1000);
        public static SessionSettings sessionSettings = DbSessionSettings.SearchSessionSettings();
        public static int sentSampleCounter = 0;
        public static int numberOfUsedCanals = 2;


        public static List<Sample> sampleList = new List<Sample>();
        public static List<Session> sessionList = new List<Session>();
        public static List<Sessionhaschannel> sessionhaschannelsList = new List<Sessionhaschannel>();

        public static MySqlConnection GetConnection()
        {
            
            MySqlConnection conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
               // MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }
    }
}
