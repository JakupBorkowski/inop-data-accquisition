using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_205_DataAccquisition
{
    internal class DbEvent
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
        public static void AddEvent(Event e)
        {
            string sql = "INSERT INTO event VALUES (NULL, @IDSESSION, @IDMACHINE, @INFO, @STOPTIME, @STOPTIMELENGTH)";

            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@IDSESSION", MySqlDbType.Int32).Value = e.idSession;
            cmd.Parameters.Add("@IDMACHINE", MySqlDbType.Int32).Value = e.idMachine;
            cmd.Parameters.Add("@INFO", MySqlDbType.VarChar).Value = e.info;
            cmd.Parameters.Add("@STOPTIME", MySqlDbType.VarChar).Value = e.stopTime;
            cmd.Parameters.Add("@STOPTIMELENGTH", MySqlDbType.Double).Value = e.stopTimeLength;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Student not insert! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        //UPDATE METHOD
        //CREATE METHOD
        public static void UpdateEvent(Event e, string id)
        {
            string sql = "UPDATE event SET id_session = @IDSESSION, id_machine = @IDMACHINE, info = @INFO, stop_time = @STOPTIME, stop_time_length = @STOPTIMELENGTH WHERE id_event = @IDEVENT";

            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@IDSESSION", MySqlDbType.Int32).Value = e.idSession;
            cmd.Parameters.Add("@IDMACHINE", MySqlDbType.Int32).Value = e.idMachine;
            cmd.Parameters.Add("@INFO", MySqlDbType.VarChar).Value = e.info;
            cmd.Parameters.Add("@STOPTIME", MySqlDbType.VarChar).Value = e.stopTime;
            cmd.Parameters.Add("@STOPTIMELENGTH", MySqlDbType.Double).Value = e.stopTimeLength;
            cmd.Parameters.Add("@IDEVENT", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Student not insert! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        //DELETE METHOD
        public static void DeleteEvent(string id)
        {
            string sql = "DELETE FROM event WHERE id_event = @EventId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@EventId", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Device not deleted! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();

        }

        //TO DO 
        //SEARCH METHOD NOT NEEDED ATM
        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            conn.Close();

        }

    }
}