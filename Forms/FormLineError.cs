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
    public partial class FormLineError : Form
    {
        public string idEvent, idSession, idMachine, info, stopTime, stopTimeLength;

        public void UpdateInfo()
        {
            button1.Text = "Update";
            textBox1.Text = idMachine;
            textBox2.Text = info;
            txtX.Text = stopTime.Substring(0, 2);
            txtM.Text = stopTime.Substring(3, 2);
            txtS.Text = stopTime.Substring(6, 2);
            textBox4.Text = stopTimeLength;
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

                if(btns.GetType() == typeof(Label))
                {
                    Label lbl = (Label)btns;
                    btns.ForeColor = ThemeColor.PrimaryColor;
                    //btns.Font = new Font(lbl.Font, FontStyle.Bold);
                }
            }
        }


        public FormLineError()
        {
            InitializeComponent();
        }

        private void FormLineError_Load(object sender, EventArgs e)
        {
            LoadTheme();
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("HH:mm:ss");
            txtX.Text = sqlFormattedDate.Substring(0, 2);
            txtM.Text = sqlFormattedDate.Substring(3, 2);
            txtS.Text = sqlFormattedDate.Substring(6, 2);
        }

        public void Clear()
        {
            textBox1.Text = textBox2.Text = textBox4.Text = String.Empty;
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("HH:mm:ss");
            txtX.Text = sqlFormattedDate.Substring(0, 2);
            txtM.Text = sqlFormattedDate.Substring(3, 2);
            txtS.Text = sqlFormattedDate.Substring(6, 2);
            Display();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("HH:mm:ss");
            txtX.Text = sqlFormattedDate.Substring(0, 2);
            txtM.Text = sqlFormattedDate.Substring(3, 2);
            txtS.Text = sqlFormattedDate.Substring(6, 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Pole Nr maszyny nie moze być puste.");
                return;
            }
            if(textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Pole Nr maszyny nie moze być puste.");
                return;
            }
            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("Pole Nr maszyny nie moze być puste.");
                return;
            }
            if(button1.Text =="Dodaj")
            {
                Event eve = new Event(DbSession.LastSessionId(),int.Parse(textBox1.Text.Trim()), textBox2.Text.Trim(), txtX.Text.Trim()+":"+txtM.Text.Trim() + ":"+txtS.Text.Trim(), double.Parse(textBox4.Text.Trim()));
                DbEvent.AddEvent(eve);
                Clear();

            }

            if(button1.Text == "Update")
            {
                Event eve = new Event(DbSession.LastSessionId(), int.Parse(textBox1.Text.Trim()), textBox2.Text.Trim(), txtX.Text.Trim() + ":" + txtM.Text.Trim() + ":" + txtS.Text.Trim(), double.Parse(textBox4.Text.Trim()));
                DbEvent.UpdateEvent(eve, idEvent);
                button1.Text = "Dodaj";
                Clear();
                Display();

            }

        }

        public void Display()
        {
            DbEvent.DisplayAndSearch("SELECT id_event, id_session, id_machine, info, stop_time, stop_time_length FROM event ORDER BY id_event DESC",dataGridView);
        }

        private void FormLineError_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbEvent.DisplayAndSearch("SELECT id_event, id_session, id_machine, info, stop_time, stop_time_length FROM event WHERE stop_time LIKE'%"+txtSearch.Text +"%' ORDER BY id_event DESC", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                //Edit
                idEvent = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                idSession = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                idMachine = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                info = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                stopTime = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                stopTimeLength = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                UpdateInfo();

                return;
            }
            if(e.ColumnIndex==1)
            {
                //Delete
                if(MessageBox.Show("Do you want to delete this event?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbEvent.DeleteEvent(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }

        }
    }
}
