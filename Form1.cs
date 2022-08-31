
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MindFusion.Charting.Components;
using MindFusion.Charting.WinForms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using MySqlX.XDevAPI;

namespace USB_205_DataAccquisition
{

    public partial class Form1 : Form
    {

        private void backgroundFunction()
        {
            while (true)
            {
                if (Globals.sampleList.Count() != 0)
                {
                    if (Globals.sampleList[0] != null)
                    {
                        DbSample.AddSample(Globals.sampleList[0]);
                        Globals.sampleList.RemoveAt(0);
                    }
                    //Thread.Sleep(Globals.tp);
                }
                if (Globals.sessionList.Count() != 0)
                {
                    DbSession.AddSession(Globals.sessionList[0]);
                    Globals.sessionList.RemoveAt(0);
                }
                if (Globals.sessionhaschannelsList.Count() != 0)
                {
                    DbSessionhaschannel.AddSessionhaschannel(Globals.sessionhaschannelsList[0].idSession, Globals.sessionhaschannelsList[0].idChannel);
                    Globals.sessionhaschannelsList.RemoveAt(0);
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread obj1 = new Thread(backgroundFunction);
            obj1.IsBackground = true;
            obj1.Start();
        }

        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = String.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while(tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            //return ColorTranslator.FromHtml("#EA676C"color);
            return ColorTranslator.FromHtml("#3F51B5");
        }

        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif",12.5F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color,-0.3);    
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;

                }
            }
        }

        private void DisableButton()
        {
            foreach(Control previousBtn in panelMenu.Controls)
            {
                if(previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51,51,76) ;
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font= new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm,object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            lblTitle.Text = childForm.Text;
            childForm.BringToFront();
            childForm.Show();
        }
       
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDataCollector(),sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {  
            OpenChildForm(new Forms.FormLineError(), sender);
        }
        private void btnSessionParams_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSessionParams(), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                Reset();
            }
        }

        public void Reset()
        {
            DisableButton();
            lblTitle.Text = "Menu";
            panelTitleBar.BackColor = Color.FromArgb(51,51,76);
            panelLogo.BackColor = Color.FromArgb(39,39,58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
    }
}
