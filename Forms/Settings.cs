using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_205_DataAccquisition.Forms
{
    public partial class Settings : Form
    {
        private void LoadTheme()
        {
            btnAdd.BackColor = ThemeColor.PrimaryColor;
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
        }
        public Settings()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FileStream fs = File.Create("data.txt");
            var sw = new StreamWriter(fs);
            using (sw)
            {
                sw.WriteLine(txtMaxPressure.Text.Trim() + "\n" + txtMinPressure.Text.Trim() + "\n" + txtMinVoltage.Text.Trim() + "\n" + txtMaxVoltage.Text.Trim() + "\n" + txtNumberOfImpulses.Text.Trim() + "\n" + checkBox1.Checked + "\n" + txtNumberOfSamples.Text.Trim());
            }

            Globals.maxPressure = Convert.ToDouble(txtMaxPressure.Text.Trim());
            Globals.minPressure = Convert.ToDouble(txtMinPressure.Text.Trim());
            Globals.minReading = Convert.ToDouble(txtMinVoltage.Text.Trim());
            Globals.maxReading = Convert.ToDouble(txtMaxVoltage.Text.Trim());
            Globals.numberOfEncoderImpulses = Convert.ToInt32(txtNumberOfImpulses.Text.Trim());
            Globals.usrednianieEnabled = checkBox1.Checked;
            Globals.numberOfSamples = Convert.ToInt32(txtNumberOfSamples.Text.Trim());


            fs.Close();

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txtMaxPressure.Text = Globals.maxPressure.ToString();
            txtMinPressure.Text = Globals.minPressure.ToString();
            txtMinVoltage.Text = Globals.minReading.ToString();
            txtMaxVoltage.Text = Globals.maxReading.ToString();
            txtNumberOfImpulses.Text = Globals.numberOfEncoderImpulses.ToString();
            checkBox1.Checked = Globals.usrednianieEnabled;
            txtNumberOfSamples.Text = Globals.numberOfSamples.ToString();

            LoadTheme();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
