using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MindFusion.Graphs;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace USB_205_DataAccquisition
{
    internal class DbSessionSettings
    {
        public static MySqlConnection GetConnection()
        {
            string sql = Globals.sql;
            MySqlConnection conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }

        //CREATE METHOD
        public static void UpdateSessionSettings(SessionSettings sessionSettings)
        {
            string sql = "UPDATE session_settings SET nr_order  = @nr_order, name = @name, number_of_samples = @number_of_samples, tp = @tp WHERE id = @id";

            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@nr_order", MySqlDbType.VarChar).Value = sessionSettings.nr_order;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = sessionSettings.name;
            cmd.Parameters.Add("@number_of_samples", MySqlDbType.Int32).Value = sessionSettings.number_of_samples;
            cmd.Parameters.Add("@tp", MySqlDbType.Double).Value = sessionSettings.tp;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = 1;
          

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sample not inserted! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            Globals.tp = (int)(DbSessionSettings.SearchSessionSettings().tp * 1000);
        }

        public static SessionSettings SearchSessionSettings()
        {
            SessionSettings sessionSettings = new SessionSettings();
            string sql = "SELECT nr_order, name, number_of_samples, tp, id FROM session_settings";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader mdr;
            try
            {
                mdr = cmd.ExecuteReader();
                if (mdr.Read())
                {
                    //Console.WriteLine(mdr.GetInt32("idSession"));
                    sessionSettings.nr_order = mdr.GetString("nr_order");
                    sessionSettings.name = mdr.GetString("name");
                    sessionSettings.number_of_samples = mdr.GetInt32("number_of_samples");
                    sessionSettings.tp = mdr.GetDouble("tp");
                    return sessionSettings;
                }
                //MessageBox.Show("Id ostatniej sesji.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Device not deleted! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            return sessionSettings;

        }
    }
}
