using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_205_DataAccquisition.Forms
{
    public partial class FormSessionParams : Form
    {

        List<Order> orders = new List<Order>();
        public FormSessionParams()
        {
            InitializeComponent();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btns.BackColor = ThemeColor.PrimaryColor;
                    btns.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }

                if (btns.GetType() == typeof(Label))
                {
                    Label lbl = (Label)btns;
                    btns.ForeColor = ThemeColor.PrimaryColor;
                    //btns.Font = new Font(lbl.Font, FontStyle.Bold);
                }
                //btnSave.BackColor = ThemeColor.PrimaryColor;
                //btnSave.ForeColor = ThemeColor.SecondaryColor;
                btnSave.BackColor = ThemeColor.PrimaryColor;
                btnSave.ForeColor = Color.White;
                btnSave.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                
                buttonAddOrder.BackColor = ThemeColor.PrimaryColor;
                buttonAddOrder.ForeColor = Color.White;
                buttonAddOrder.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            }
        }

        private void FormSessionParams_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadSessionParams();
            
        }
        private void LoadSessionParams()
        {

            orders = DbOrder.SearchOrders();
            Globals.sessionSettings = DbSessionSettings.SearchSessionSettings();

            comboBox1.ValueMember = "nr_order";
            comboBox1.DisplayMember = "FullName";
            comboBox1.DataSource = orders;


            comboBox1.SelectedValue= Globals.sessionSettings.nr_order.ToString();
            txt_name.Text = Globals.sessionSettings.name.ToString();
            txt_number_of_samples.Text = Globals.sessionSettings.number_of_samples.ToString();
            txt_tp.Text = Globals.sessionSettings.tp.ToString();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            SessionSettings sessionSesstings = new SessionSettings(comboBox1.SelectedValue.ToString(), txt_name.Text.Trim(), int.Parse(txt_number_of_samples.Text.Trim()), double.Parse(txt_tp.Text.Trim())); ;
            DbSessionSettings.UpdateSessionSettings(sessionSesstings);
        }

        private void ClearAndSetNewCreatedOrder()
        {
            txt_company_name.Text = txt_nr_order_add.Text = String.Empty;
        }

        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            Order order = new Order(txt_company_name.Text.Trim(), txt_nr_order_add.Text.Trim());
            DbOrder.AddOrder(order);
            LoadSessionParams();
        }
    }
}
