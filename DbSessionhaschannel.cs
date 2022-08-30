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
    internal class DbSessionhaschannel
    {
        //CREATE METHOD
        public static void AddSessionhaschannel(int sessionId, int channelId)
        {
            string sql = "INSERT INTO sessionhaschannel VALUES (@SessionId, @ChannelId)";
            Globals.conn = Globals.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SessionId", MySqlDbType.Int32).Value = sessionId;
            cmd.Parameters.Add("@ChannelId", MySqlDbType.Int32).Value = channelId;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex){}
            Globals.conn.Close();
        }


        //DELETE METHOD
        public static void DeleteSessionhaschannel(string id)
        {

            string sql = "DELETE FROM session WHERE idSession = @SessionId";
            Globals.conn = Globals.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SessionId", MySqlDbType.Int32).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex){}
            Globals.conn.Close();
        }
    }
}
