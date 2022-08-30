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
        //CREATE METHOD
        public static void AddSession(Session session)
        {
            string sql = "INSERT INTO session VALUES (NULL, @Name, @Start, @NumberOfSamples, @Tp)";
            Globals.conn = Globals.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = session.name;
            cmd.Parameters.Add("@Start", MySqlDbType.VarChar).Value = session.start;
            cmd.Parameters.Add("@NumberOfSamples", MySqlDbType.Int32).Value = session.numberOfSamples;
            cmd.Parameters.Add("@Tp", MySqlDbType.Float).Value = session.tp;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex){}
            Globals.conn.Close();
        }

        //DELETE METHOD
        public static void DeleteSession(string id)
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


        //Find id of last added session
        public static int LastSessionId()
        {
            string sql = "SELECT MAX(idSession) as idSession FROM session ";
            Globals.conn = Globals.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader mdr;
            try
            {
                mdr = cmd.ExecuteReader();
                if(mdr.Read())
                {
                    return mdr.GetInt32("idSession");
                    mdr.Close();
                }        
            }
            catch (Exception ex)
            {
                return 0;
            }
            Globals.conn.Close();
            return mdr.GetInt32("idSession");

        }
    }
}
