namespace ELECTRONIC_SCARE
{
    partial class Setting
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label3 = new Label();
            tbPQT = new TextBox();
            btnEnter = new Button();
            cbTPaper = new ComboBox();
            cbPName = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            tbMRight = new TextBox();
            tbMLeft = new TextBox();
            tbMBot = new TextBox();
            tbMTop = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.WhiteSmoke;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1095, 609);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(tbPQT);
            panel1.Controls.Add(btnEnter);
            panel1.Controls.Add(cbTPaper);
            panel1.Controls.Add(cbPName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1095, 233);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(151, 82);
            label3.Name = "label3";
            label3.Size = new Size(277, 49);
            label3.TabIndex = 8;
            label3.Text = "Print quantity :";
            // 
            // tbPQT
            // 
            tbPQT.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPQT.Location = new Point(442, 85);
            tbPQT.Name = "tbPQT";
            tbPQT.Size = new Size(302, 50);
            tbPQT.TabIndex = 7;
            tbPQT.Text = "1";
            tbPQT.KeyPress += tbPQT_KeyPress;
            // 
            // btnEnter
            // 
            btnEnter.BackColor = SystemColors.ButtonHighlight;
            btnEnter.FlatStyle = FlatStyle.Popup;
            btnEnter.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEnter.Location = new Point(804, 50);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(247, 119);
            btnEnter.TabIndex = 6;
            btnEnter.Text = "ENTER";
            btnEnter.UseVisualStyleBackColor = false;
            btnEnter.Click += btnEnter_Click;
            // 
            // cbTPaper
            // 
            cbTPaper.Enabled = false;
            cbTPaper.Font = new Font("Times New Roman", 13.875F);
            cbTPaper.FormattingEnabled = true;
            cbTPaper.Location = new Point(442, 154);
            cbTPaper.Name = "cbTPaper";
            cbTPaper.Size = new Size(302, 50);
            cbTPaper.TabIndex = 5;
            // 
            // cbPName
            // 
            cbPName.Font = new Font("Times New Roman", 13.875F);
            cbPName.FormattingEnabled = true;
            cbPName.Location = new Point(442, 22);
            cbPName.Name = "cbPName";
            cbPName.Size = new Size(302, 50);
            cbPName.TabIndex = 4;
            cbPName.SelectedIndexChanged += cbPName_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 155);
            label2.Name = "label2";
            label2.Size = new Size(424, 49);
            label2.TabIndex = 3;
            label2.Text = "Type of printing paper :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(166, 19);
            label1.Name = "label1";
            label1.Size = new Size(261, 49);
            label1.TabIndex = 2;
            label1.Text = "Printer name :";
            // 
            // panel2
            // 
            panel2.Controls.Add(tbMRight);
            panel2.Controls.Add(tbMLeft);
            panel2.Controls.Add(tbMBot);
            panel2.Controls.Add(tbMTop);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 233);
            panel2.Name = "panel2";
            panel2.Size = new Size(1095, 609);
            panel2.TabIndex = 2;
            // 
            // tbMRight
            // 
            tbMRight.Anchor = AnchorStyles.Right;
            tbMRight.Enabled = false;
            tbMRight.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbMRight.Location = new Point(972, 320);
            tbMRight.Name = "tbMRight";
            tbMRight.Size = new Size(120, 50);
            tbMRight.TabIndex = 3;
            tbMRight.TextAlign = HorizontalAlignment.Center;
            tbMRight.KeyPress += tbMRight_KeyPress;
            // 
            // tbMLeft
            // 
            tbMLeft.Anchor = AnchorStyles.Left;
            tbMLeft.Enabled = false;
            tbMLeft.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbMLeft.Location = new Point(3, 320);
            tbMLeft.Name = "tbMLeft";
            tbMLeft.Size = new Size(120, 50);
            tbMLeft.TabIndex = 2;
            tbMLeft.TextAlign = HorizontalAlignment.Center;
            tbMLeft.KeyPress += tbMLeft_KeyPress;
            // 
            // tbMBot
            // 
            tbMBot.Anchor = AnchorStyles.Bottom;
            tbMBot.Enabled = false;
            tbMBot.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbMBot.Location = new Point(487, 556);
            tbMBot.Name = "tbMBot";
            tbMBot.Size = new Size(120, 50);
            tbMBot.TabIndex = 1;
            tbMBot.TextAlign = HorizontalAlignment.Center;
            tbMBot.KeyPress += tbMBot_KeyPress;
            // 
            // tbMTop
            // 
            tbMTop.Anchor = AnchorStyles.Top;
            tbMTop.Enabled = false;
            tbMTop.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbMTop.Location = new Point(487, 3);
            tbMTop.Name = "tbMTop";
            tbMTop.Size = new Size(120, 50);
            tbMTop.TabIndex = 0;
            tbMTop.TextAlign = HorizontalAlignment.Center;
            tbMTop.KeyPress += tbMTop_KeyPress;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // Setting
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 842);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Setting";
            Text = "Setting";
            FormClosing += Setting_FormClosing;
            Load += Setting_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel2;
        private TextBox tbMRight;
        private TextBox tbMLeft;
        private TextBox tbMBot;
        private TextBox tbMTop;
        private ComboBox cbTPaper;
        private ComboBox cbPName;
        private Button btnEnter;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Label label3;
        private TextBox tbPQT;
        private Label label2;
        private Label label1;
    }
}
