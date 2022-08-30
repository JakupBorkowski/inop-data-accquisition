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
    internal class DbDevice
    {
        //CREATE METHOD
        public static void AddDevice(Device device)
        {
            string sql = "INSERT INTO device VALUES (NULL, @DeviceName)";

            Globals.conn = Globals.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@DeviceName", MySqlDbType.VarChar).Value = device.name;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Student not insert! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Globals.conn.Close();
        }

        //UPDATE METHOD
        public static void UpdateDevice(Device device, string id)
        {
            string sql = "UPDATE device SET name = @DeviceName WHERE idDevice = @DeviceId";

            Globals.conn = Globals.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@DeviceName", MySqlDbType.VarChar).Value = device.name;
            cmd.Parameters.Add("@DeviceId", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Device not updated! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Globals.conn.Close();
        }

        //DELETE METHOD
        public static void DeleteDevice(string id)
        {
            string sql = "DELETE FROM device WHERE idDevice = @DeviceId";
            Globals.conn = Globals.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@DeviceId", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Device not deleted! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Globals.conn.Close();

        }

        //TO DO 
        //SEARCH METHOD NOT NEEDED ATM



    }
}
