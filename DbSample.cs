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
        //CREATE METHOD
        public static void AddSample(Sample sample)
        {
            Globals.conn = Globals.GetConnection();
            string sql = "INSERT INTO sample VALUES (NULL, @ChannelId, @Value, @Timestamp)";
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ChannelId", MySqlDbType.VarChar).Value = sample.idChannel;
            cmd.Parameters.Add("@Value", MySqlDbType.Float).Value = sample.value;
            cmd.Parameters.Add("@Timestamp", MySqlDbType.VarChar).Value = sample.timestamp;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex){
                 //MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Globals.conn.Close();   
        }
        
        // TO DO UPDATE METHOD
        public static void UpdateSample(Sample sample, string id)
        {
            Globals.conn = Globals.GetConnection();
            string sql = "UPDATE sample SET idChannel = @ChannelId, value = @Value, timestamp = @Timestamp WHERE idSample = @SampleId";

            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ChannelId", MySqlDbType.VarChar).Value = sample.idChannel;
            cmd.Parameters.Add("@Value", MySqlDbType.Float).Value = sample.value;
            cmd.Parameters.Add("@Timestamp", MySqlDbType.VarChar).Value = sample.timestamp;
            cmd.Parameters.Add("@SampleId", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex){}
            Globals.conn.Close();
           
        }
        
        //DELETE METHOD
        public static void DeleteSample(string id)
        {
            Globals.conn = Globals.GetConnection();
            string sql = "DELETE FROM sample WHERE idSample = @SampleId";

            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SampleId", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex){}
            Globals.conn.Close();
        }

        //TO DO 
        //SEARCH METHOD NOT NEEDED ATM
        
    }
}
