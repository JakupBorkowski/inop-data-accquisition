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
            catch (Exception ex){}
        }
        
        // TO DO UPDATE METHOD
        public static void UpdateSample(Sample sample, string id)
        {
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
           
        }
        
        //DELETE METHOD
        public static void DeleteSample(string id)
        {
            string sql = "DELETE FROM sample WHERE idSample = @SampleId";

            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SampleId", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex){}

        }

        //TO DO 
        //SEARCH METHOD NOT NEEDED ATM
        
    }
}
