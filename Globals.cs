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
        public static string sql = "datasource=localhost;port=3308;username=root;password=helloworld;database=db;Convert Zero Datetime=True";
        public static MySqlConnection conn = GetConnection();

                    /// <summary>chujjjjjjjjjjjjjjjjjjjjjjjjjj
                    /// ///hujjjjjj2
                    /// ///
                    /// </summary>
                    /// <returns></returns>

        public static MySqlConnection GetConnection()
        {
           // string sql = "datasource=localhost;port=3308;username=root;password=helloworld;database=db;Convert Zero Datetime=True";
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
