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
    internal class DbSession
    {
        public static MySqlConnection GetConnection()
        {
           // string sql = "datasource=localhost;port=3306;username=root;password=;database=usb205db";
            //string sql = "datasource=database-1.crdizhrpr8gd.us-east-1.rds.amazonaws.com;port=3306;username=root;password=12345678;database=datebase1;Convert Zero Datetime=True";

            MySqlConnection conn = new MySqlConnection(Globals.sql);
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
        public static void AddSession(Session session)
        {
            string sql = "INSERT INTO session VALUES (NULL, @Name, @Start, @NumberOfSamples, @Tp)";

            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = session.name;
            cmd.Parameters.Add("@Start", MySqlDbType.VarChar).Value = session.start;
            cmd.Parameters.Add("@NumberOfSamples", MySqlDbType.Int32).Value = session.numberOfSamples;
            cmd.Parameters.Add("@Tp", MySqlDbType.Float).Value = session.tp;

            try
            {
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Added Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Sample not inserted! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }


        //DELETE METHOD
        public static void DeleteSession(string id)
        {

            string sql = "DELETE FROM session WHERE idSession = @SessionId";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SessionId", MySqlDbType.Int32).Value = id;

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


        //Find id of last added session
        public static int LastSessionId()
        {
            string sql = "SELECT MAX(idSession) as idSession FROM session ";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader mdr;
            try
            {
                mdr = cmd.ExecuteReader();
                if(mdr.Read())
                {
                    //Console.WriteLine(mdr.GetInt32("idSession"));
                    return mdr.GetInt32("idSession");
                }
                //MessageBox.Show("Id ostatniej sesji.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Device not deleted! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            conn.Close();
            return mdr.GetInt32("idSession");

        }
    }
}
