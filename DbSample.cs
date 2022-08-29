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
    internal class DbSample
    {
        public static MySqlConnection GetConnection()
        {
            //string sql = "datasource=localhost;port=3306;username=root;password=;database=usb205db";
            string sql = "datasource=database-1.crdizhrpr8gd.us-east-1.rds.amazonaws.com;port=3306;username=root;password=12345678;database=datebase1;Convert Zero Datetime=True";
           
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
        public static void AddSample(Sample sample)
        {
            string sql = "INSERT INTO sample VALUES (NULL, @ChannelId, @Value, @Timestamp)";

            //MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ChannelId", MySqlDbType.VarChar).Value = sample.idChannel;
            cmd.Parameters.Add("@Value", MySqlDbType.Float).Value = sample.value;
            cmd.Parameters.Add("@Timestamp", MySqlDbType.VarChar).Value = sample.timestamp;


            try
            {
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Added Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Sample not inserted! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //conn.Close();
        }
        
        // TO DO UPDATE METHOD
        public static void UpdateSample(Sample sample, string id)
        {
            string sql = "UPDATE sample SET idChannel = @ChannelId, value = @Value, timestamp = @Timestamp WHERE idSample = @SampleId";

            //MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ChannelId", MySqlDbType.VarChar).Value = sample.idChannel;
            cmd.Parameters.Add("@Value", MySqlDbType.Float).Value = sample.value;
            cmd.Parameters.Add("@Timestamp", MySqlDbType.VarChar).Value = sample.timestamp;
            cmd.Parameters.Add("@SampleId", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sample not updated! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //conn.Close();
        }
        

        //TO DODELETE METHOD
        public static void DeleteSample(string id)
        {

            string sql = "DELETE FROM sample WHERE idSample = @SampleId";
            //MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@SampleId", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Device not deleted! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           // conn.Close();

        }

        //TO DO 
        //SEARCH METHOD NOT NEEDED ATM
        
    }
}
