namespace USB_205_DataAccquisition.Forms
{
    partial class FormSessionParams
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_order_id = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_number_of_samples = new System.Windows.Forms.Label();
            this.txt_number_of_samples = new System.Windows.Forms.TextBox();
            this.lbl_tp = new System.Windows.Forms.Label();
            this.txt_tp = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nr_order_add = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_company_name = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonAddOrder = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_order_id
            // 
            this.lbl_order_id.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_order_id.AutoSize = true;
            this.lbl_order_id.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lbl_order_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_order_id.Location = new System.Drawing.Point(44, 128);
            this.lbl_order_id.Name = "lbl_order_id";
            this.lbl_order_id.Size = new System.Drawing.Size(143, 20);
            this.lbl_order_id.TabIndex = 4;
            this.lbl_order_id.Text = "Numer zamówienia";
            // 
            // lbl_name
            // 
            this.lbl_name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_name.AutoSize = true;
            this.lbl_name.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_name.Location = new System.Drawing.Point(44, 173);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(57, 20);
            this.lbl_name.TabIndex = 6;
            this.lbl_name.Text = "Nazwa";
            // 
            // txt_name
            // 
            this.txt_name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_name.Location = new System.Drawing.Point(244, 170);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(138, 26);
            this.txt_name.TabIndex = 5;
            // 
            // lbl_number_of_samples
            // 
            this.lbl_number_of_samples.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_number_of_samples.AutoSize = true;
            this.lbl_number_of_samples.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lbl_number_of_samples.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_number_of_samples.Location = new System.Drawing.Point(44, 220);
            this.lbl_number_of_samples.Name = "lbl_number_of_samples";
            this.lbl_number_of_samples.Size = new System.Drawing.Size(195, 20);
            this.lbl_number_of_samples.TabIndex = 8;
            this.lbl_number_of_samples.Text = "Liczba próbek do zebrania";
            // 
            // txt_number_of_samples
            // 
            this.txt_number_of_samples.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_number_of_samples.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_number_of_samples.Location = new System.Drawing.Point(244, 217);
            this.txt_number_of_samples.Name = "txt_number_of_samples";
            this.txt_number_of_samples.Size = new System.Drawing.Size(138, 26);
            this.txt_number_of_samples.TabIndex = 7;
            // 
            // lbl_tp
            // 
            this.lbl_tp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_tp.AutoSize = true;
            this.lbl_tp.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lbl_tp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_tp.Location = new System.Drawing.Point(44, 267);
            this.lbl_tp.Name = "lbl_tp";
            this.lbl_tp.Size = new System.Drawing.Size(135, 20);
            this.lbl_tp.TabIndex = 10;
            this.lbl_tp.Text = "Krok próbkowania";
            // 
            // txt_tp
            // 
            this.txt_tp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_tp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_tp.Location = new System.Drawing.Point(244, 264);
            this.txt_tp.Name = "txt_tp";
            this.txt_tp.Size = new System.Drawing.Size(138, 26);
            this.txt_tp.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(32, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 253);
            this.panel1.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.Location = new System.Drawing.Point(266, 211);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Zapisz";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(214, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 28);
            this.comboBox1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(32, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(367, 41);
            this.panel2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Parametry aktualnej sesji";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(432, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(336, 41);
            this.panel3.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Dodawania nowego zamowienia";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(454, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Numer zamówienia";
            // 
            // txt_nr_order_add
            // 
            this.txt_nr_order_add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_nr_order_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_nr_order_add.Location = new System.Drawing.Point(613, 217);
            this.txt_nr_order_add.Name = "txt_nr_order_add";
            this.txt_nr_order_add.Size = new System.Drawing.Size(138, 26);
            this.txt_nr_order_add.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(454, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Nazwa firmy";
            // 
            // txt_company_name
            // 
            this.txt_company_name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_company_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_company_name.Location = new System.Drawing.Point(613, 170);
            this.txt_company_name.Name = "txt_company_name";
            this.txt_company_name.Size = new System.Drawing.Size(138, 26);
            this.txt_company_name.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel4.Controls.Add(this.buttonAddOrder);
            this.panel4.Location = new System.Drawing.Point(432, 101);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(336, 253);
            this.panel4.TabIndex = 20;
            // 
            // buttonAddOrder
            // 
            this.buttonAddOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonAddOrder.Location = new System.Drawing.Point(236, 211);
            this.buttonAddOrder.Name = "buttonAddOrder";
            this.buttonAddOrder.Size = new System.Drawing.Size(86, 32);
            this.buttonAddOrder.TabIndex = 0;
            this.buttonAddOrder.Text = "Dodaj";
            this.buttonAddOrder.UseVisualStyleBackColor = true;
            this.buttonAddOrder.Click += new System.EventHandler(this.buttonAddOrder_Click);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(800, 450);
            this.panel5.TabIndex = 22;
            // 
            // FormSessionParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_nr_order_add);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_company_name);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbl_tp);
            this.Controls.Add(this.txt_tp);
            this.Controls.Add(this.lbl_number_of_samples);
            this.Controls.Add(this.txt_number_of_samples);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.lbl_order_id);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Name = "FormSessionParams";
            this.Text = "FormSessionParams";
            this.Load += new System.EventHandler(this.FormSessionParams_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_order_id;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_number_of_samples;
        private System.Windows.Forms.TextBox txt_number_of_samples;
        private System.Windows.Forms.Label lbl_tp;
        private System.Windows.Forms.TextBox txt_tp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nr_order_add;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_company_name;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonAddOrder;
        private System.Windows.Forms.Panel panel5;
    }
}