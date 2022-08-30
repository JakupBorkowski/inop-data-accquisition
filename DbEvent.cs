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
        //CREATE METHOD
        public static void AddEvent(Event e)
        {
            Globals.conn = Globals.GetConnection();
            string sql = "INSERT INTO event VALUES (NULL, @IDSESSION, @IDMACHINE, @INFO, @STOPTIME, @STOPTIMELENGTH)";
            
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@IDSESSION", MySqlDbType.Int32).Value = e.idSession;
            cmd.Parameters.Add("@IDMACHINE", MySqlDbType.Int32).Value = e.idMachine;
            cmd.Parameters.Add("@INFO", MySqlDbType.VarChar).Value = e.info;
            cmd.Parameters.Add("@STOPTIME", MySqlDbType.VarChar).Value = e.stopTime;
            cmd.Parameters.Add("@STOPTIMELENGTH", MySqlDbType.Double).Value = e.stopTimeLength;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex){}
            Globals.conn.Close();
        }

        //UPDATE METHOD
        public static void UpdateEvent(Event e, string id)
        {
            Globals.conn = Globals.GetConnection();
            string sql = "UPDATE event SET id_session = @IDSESSION, id_machine = @IDMACHINE, info = @INFO, stop_time = @STOPTIME, stop_time_length = @STOPTIMELENGTH WHERE id_event = @IDEVENT";
           
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
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
            }
            catch (Exception ex){}
            Globals.conn.Close();
        }

        //DELETE METHOD
        public static void DeleteEvent(string id)
        {
            Globals.conn = Globals.GetConnection();
            string sql = "DELETE FROM event WHERE id_event = @EventId";
          
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@EventId", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex){}
            Globals.conn.Close();
           
        }

        //TO DO
        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            Globals.conn = Globals.GetConnection();
            string sql = query;
            MySqlCommand cmd  = new MySqlCommand(sql, Globals.conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;     
            Globals.conn.Close();
        }

    }
}
