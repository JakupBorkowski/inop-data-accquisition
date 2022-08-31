using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace USB_205_DataAccquisition
{
    internal class DbOrder
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
        public static List<Order> SearchOrders()
        {
            string sql = "SELECT id, company,  nr_order FROM order_list";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader mdr;
            List<Order> orders = new List<Order>();
            try
            {
                mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    Order order = new Order(mdr.GetInt32("id"),mdr.GetString("company"), mdr.GetString("nr_order"));
                    //Console.WriteLine(mdr.GetInt32("id")+ mdr.GetString("company") + mdr.GetString("nr_order"));
                    orders.Add(order);
                    //Console.WriteLine(orders);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Device not deleted! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            return orders;
        }

        public static void  AddOrder(Order order)
        {
            string sql = "INSERT into order_list VALUES (NULL, @company, @nr_order)";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@company", MySqlDbType.VarChar).Value = order.company;
            cmd.Parameters.Add("@nr_order", MySqlDbType.VarChar).Value = order.nr_order;

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
    }
}
