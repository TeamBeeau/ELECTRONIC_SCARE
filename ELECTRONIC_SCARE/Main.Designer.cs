using System.Windows.Forms;

namespace ELECTRONIC_SCARE
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            panel12 = new Panel();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            toolStripStatusLabel4 = new ToolStripStatusLabel();
            toolStripStatusLabel5 = new ToolStripStatusLabel();
            panel18 = new Panel();
            panel5 = new Panel();
            lbStatus = new Label();
            label9 = new Label();
            tbQuan = new Label();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel9 = new Panel();
            panel38 = new Panel();
            tbPO = new TextBox();
            label1 = new Label();
            panel8 = new Panel();
            tbQtyib = new TextBox();
            label2 = new Label();
            panel7 = new Panel();
            label3 = new Label();
            tbQty = new TextBox();
            panel6 = new Panel();
            tbBox = new TextBox();
            label4 = new Label();
            panel3 = new Panel();
            panel13 = new Panel();
            dgvMain = new DataGridView();
            panel4 = new Panel();
            panel2 = new Panel();
            btnRun = new Button();
            panel23 = new Panel();
            panel32 = new Panel();
            panel22 = new Panel();
            btnSetting = new Button();
            panel14 = new Panel();
            btnReprint = new Button();
            panel25 = new Panel();
            btnDelete = new Button();
            panel15 = new Panel();
            btnConnect = new Button();
            panel17 = new Panel();
            btnPrint = new Button();
            panel16 = new Panel();
            btnExport = new Button();
            panel11 = new Panel();
            panel21 = new Panel();
            label5 = new Label();
            tpFrom = new DateTimePicker();
            panel20 = new Panel();
            label6 = new Label();
            tpTo = new DateTimePicker();
            panel19 = new Panel();
            cbPO = new ComboBox();
            label8 = new Label();
            panel10 = new Panel();
            btnSearch = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            tmChecking = new System.Windows.Forms.Timer(components);
            tmOut = new System.Windows.Forms.Timer(components);
            panel12.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel18.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel9.SuspendLayout();
            panel38.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel23.SuspendLayout();
            panel32.SuspendLayout();
            panel22.SuspendLayout();
            panel14.SuspendLayout();
            panel25.SuspendLayout();
            panel15.SuspendLayout();
            panel17.SuspendLayout();
            panel16.SuspendLayout();
            panel11.SuspendLayout();
            panel21.SuspendLayout();
            panel20.SuspendLayout();
            panel19.SuspendLayout();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // panel12
            // 
            panel12.BackColor = Color.Transparent;
            panel12.Controls.Add(statusStrip1);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 534);
            panel12.Margin = new Padding(2, 1, 2, 1);
            panel12.Name = "panel12";
            panel12.Size = new Size(1036, 20);
            panel12.TabIndex = 17;
            // 
            // statusStrip1
            // 
            statusStrip1.Dock = DockStyle.Fill;
            statusStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusStrip1.ImageScalingSize = new Size(32, 32);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3, toolStripStatusLabel4, toolStripStatusLabel5 });
            statusStrip1.Location = new Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 8, 0);
            statusStrip1.Size = new Size(1036, 20);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Font = new Font("Segoe UI", 9F);
            toolStripStatusLabel1.ForeColor = Color.Red;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(234, 15);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.Text = "Scale: lost connection.";
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Font = new Font("Segoe UI", 9F);
            toolStripStatusLabel2.ForeColor = Color.Red;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(234, 15);
            toolStripStatusLabel2.Spring = true;
            toolStripStatusLabel2.Text = "Arduino: lost connection.";
            toolStripStatusLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Font = new Font("Segoe UI", 9F);
            toolStripStatusLabel3.ForeColor = Color.Red;
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(234, 15);
            toolStripStatusLabel3.Spring = true;
            toolStripStatusLabel3.Text = "Printer: lost connection.";
            toolStripStatusLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new Size(234, 15);
            toolStripStatusLabel4.Spring = true;
            toolStripStatusLabel4.Text = "Bee Eyes Automation";
            toolStripStatusLabel4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new Size(91, 15);
            toolStripStatusLabel5.Text = "Version: 1.0.0";
            // 
            // panel18
            // 
            panel18.BackColor = SystemColors.ActiveCaption;
            panel18.Controls.Add(panel5);
            panel18.Controls.Add(pictureBox1);
            panel18.Dock = DockStyle.Left;
            panel18.Location = new Point(0, 0);
            panel18.Margin = new Padding(2, 1, 2, 1);
            panel18.Name = "panel18";
            panel18.Size = new Size(516, 534);
            panel18.TabIndex = 20;
            // 
            // panel5
            // 
            panel5.Controls.Add(lbStatus);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(tbQuan);
            panel5.Controls.Add(label7);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 246);
            panel5.Margin = new Padding(2, 1, 2, 1);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(10, 10, 10, 10);
            panel5.Size = new Size(516, 288);
            panel5.TabIndex = 9;
            // 
            // lbStatus
            // 
            lbStatus.BackColor = Color.FromArgb(224, 224, 224);
            lbStatus.BorderStyle = BorderStyle.Fixed3D;
            lbStatus.Dock = DockStyle.Fill;
            lbStatus.Font = new Font("Yu Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbStatus.Location = new Point(10, 422);
            lbStatus.Margin = new Padding(2, 0, 2, 0);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(496, 0);
            lbStatus.TabIndex = 6;
            lbStatus.Text = "WAIT";
            lbStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.Dock = DockStyle.Top;
            label9.Font = new Font("Times New Roman", 36F);
            label9.Location = new Point(10, 344);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(496, 78);
            label9.TabIndex = 5;
            label9.Text = "Status";
            label9.TextAlign = ContentAlignment.BottomCenter;
            // 
            // tbQuan
            // 
            tbQuan.BackColor = Color.Cornsilk;
            tbQuan.BorderStyle = BorderStyle.Fixed3D;
            tbQuan.Dock = DockStyle.Top;
            tbQuan.Font = new Font("Yu Gothic UI", 99.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbQuan.Location = new Point(10, 108);
            tbQuan.Margin = new Padding(2, 0, 2, 0);
            tbQuan.Name = "tbQuan";
            tbQuan.Size = new Size(496, 236);
            tbQuan.TabIndex = 4;
            tbQuan.Text = "00000";
            tbQuan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Times New Roman", 36F);
            label7.Location = new Point(10, 10);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(496, 98);
            label7.TabIndex = 0;
            label7.Text = "Quantity";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaption;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(2, 1, 2, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(516, 246);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(panel9);
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel6);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(516, 0);
            panel1.Margin = new Padding(2, 1, 2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(520, 113);
            panel1.TabIndex = 21;
            // 
            // panel9
            // 
            panel9.BackColor = SystemColors.GradientActiveCaption;
            panel9.Controls.Add(panel38);
            panel9.Controls.Add(label1);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(0, 0);
            panel9.Margin = new Padding(2, 1, 2, 1);
            panel9.Name = "panel9";
            panel9.Size = new Size(0, 113);
            panel9.TabIndex = 13;
            // 
            // panel38
            // 
            panel38.Controls.Add(tbPO);
            panel38.Dock = DockStyle.Fill;
            panel38.Location = new Point(0, 31);
            panel38.Margin = new Padding(2, 1, 2, 1);
            panel38.Name = "panel38";
            panel38.Padding = new Padding(5, 5, 5, 5);
            panel38.Size = new Size(0, 82);
            panel38.TabIndex = 5;
            // 
            // tbPO
            // 
            tbPO.BackColor = SystemColors.Info;
            tbPO.Dock = DockStyle.Fill;
            tbPO.Font = new Font("Times New Roman", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPO.Location = new Point(5, 5);
            tbPO.Margin = new Padding(2, 1, 2, 1);
            tbPO.Name = "tbPO";
            tbPO.Size = new Size(0, 63);
            tbPO.TabIndex = 0;
            tbPO.Text = "W20240626015-0160";
            tbPO.TextAlign = HorizontalAlignment.Center;
            tbPO.TextChanged += tbPO_TextChanged;
            tbPO.KeyDown += TbPO_KeyDown;
            tbPO.KeyPress += tbPO_KeyPress;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Times New Roman", 16.125F);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 31);
            label1.TabIndex = 4;
            label1.Text = "PO";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            panel8.Controls.Add(tbQtyib);
            panel8.Controls.Add(label2);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(-185, 0);
            panel8.Margin = new Padding(2, 1, 2, 1);
            panel8.Name = "panel8";
            panel8.Size = new Size(235, 113);
            panel8.TabIndex = 12;
            // 
            // tbQtyib
            // 
            tbQtyib.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbQtyib.BackColor = SystemColors.Info;
            tbQtyib.Font = new Font("Times New Roman", 36F);
            tbQtyib.Location = new Point(12, 36);
            tbQtyib.Margin = new Padding(2, 1, 2, 1);
            tbQtyib.Name = "tbQtyib";
            tbQtyib.Size = new Size(205, 63);
            tbQtyib.TabIndex = 1;
            tbQtyib.Text = "30";
            tbQtyib.TextAlign = HorizontalAlignment.Center;
            tbQtyib.TextChanged += tbQtyib_TextChanged;
            tbQtyib.KeyDown += tbSetValue_KeyDown;
            tbQtyib.KeyPress += tbSetValue_KeyPress;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Times New Roman", 16.125F);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(235, 31);
            label2.TabIndex = 5;
            label2.Text = "Q'TY in Box";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            panel7.Controls.Add(label3);
            panel7.Controls.Add(tbQty);
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(50, 0);
            panel7.Margin = new Padding(2, 1, 2, 1);
            panel7.Name = "panel7";
            panel7.Size = new Size(235, 113);
            panel7.TabIndex = 11;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Times New Roman", 16.125F);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(235, 31);
            label3.TabIndex = 6;
            label3.Text = "Q'TY";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbQty
            // 
            tbQty.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbQty.BackColor = Color.SteelBlue;
            tbQty.BorderStyle = BorderStyle.FixedSingle;
            tbQty.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbQty.ForeColor = Color.White;
            tbQty.Location = new Point(15, 36);
            tbQty.Margin = new Padding(2, 1, 2, 1);
            tbQty.Name = "tbQty";
            tbQty.ReadOnly = true;
            tbQty.Size = new Size(213, 63);
            tbQty.TabIndex = 3;
            tbQty.Text = "00";
            tbQty.TextAlign = HorizontalAlignment.Center;
            tbQty.TextChanged += tbQty_TextChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(tbBox);
            panel6.Controls.Add(label4);
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(285, 0);
            panel6.Margin = new Padding(2, 1, 2, 1);
            panel6.Name = "panel6";
            panel6.Size = new Size(235, 113);
            panel6.TabIndex = 10;
            // 
            // tbBox
            // 
            tbBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbBox.BackColor = Color.MediumSeaGreen;
            tbBox.BorderStyle = BorderStyle.FixedSingle;
            tbBox.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbBox.ForeColor = Color.White;
            tbBox.Location = new Point(14, 36);
            tbBox.Margin = new Padding(2, 1, 2, 1);
            tbBox.Name = "tbBox";
            tbBox.ReadOnly = true;
            tbBox.Size = new Size(210, 63);
            tbBox.TabIndex = 2;
            tbBox.Text = "00";
            tbBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Times New Roman", 16.125F);
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(235, 31);
            label4.TabIndex = 7;
            label4.Text = "Box";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel13);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(516, 113);
            panel3.Margin = new Padding(2, 1, 2, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(520, 421);
            panel3.TabIndex = 22;
            // 
            // panel13
            // 
            panel13.Controls.Add(dgvMain);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(0, 144);
            panel13.Margin = new Padding(2, 1, 2, 1);
            panel13.Name = "panel13";
            panel13.Size = new Size(520, 277);
            panel13.TabIndex = 18;
            // 
            // dgvMain
            // 
            dgvMain.AllowUserToAddRows = false;
            dgvMain.BackgroundColor = SystemColors.MenuBar;
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Dock = DockStyle.Fill;
            dgvMain.Location = new Point(0, 0);
            dgvMain.Margin = new Padding(2, 1, 2, 1);
            dgvMain.MultiSelect = false;
            dgvMain.Name = "dgvMain";
            dgvMain.ReadOnly = true;
            dgvMain.RowHeadersVisible = false;
            dgvMain.RowHeadersWidth = 100;
            dgvMain.Size = new Size(520, 277);
            dgvMain.TabIndex = 16;
            dgvMain.CellFormatting += dgvMain_CellFormatting;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlLight;
            panel4.Controls.Add(panel2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(2, 1, 2, 1);
            panel4.Name = "panel4";
            panel4.Size = new Size(520, 144);
            panel4.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.Controls.Add(btnRun);
            panel2.Controls.Add(panel23);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(2, 1, 2, 1);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5, 5, 5, 5);
            panel2.Size = new Size(520, 144);
            panel2.TabIndex = 17;
            // 
            // btnRun
            // 
            btnRun.BackColor = Color.DarkSlateGray;
            btnRun.Dock = DockStyle.Fill;
            btnRun.FlatStyle = FlatStyle.Popup;
            btnRun.Font = new Font("Times New Roman", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRun.ForeColor = Color.White;
            btnRun.Location = new Point(5, 5);
            btnRun.Margin = new Padding(2, 1, 2, 1);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(0, 134);
            btnRun.TabIndex = 31;
            btnRun.Text = "RUN";
            btnRun.UseVisualStyleBackColor = false;
            btnRun.Click += BtnRun_Click;
            // 
            // panel23
            // 
            panel23.BorderStyle = BorderStyle.FixedSingle;
            panel23.Controls.Add(panel32);
            panel23.Controls.Add(panel11);
            panel23.Dock = DockStyle.Right;
            panel23.Location = new Point(-349, 5);
            panel23.Name = "panel23";
            panel23.Size = new Size(864, 134);
            panel23.TabIndex = 29;
            // 
            // panel32
            // 
            panel32.BackColor = SystemColors.InactiveCaption;
            panel32.Controls.Add(panel22);
            panel32.Controls.Add(panel14);
            panel32.Controls.Add(panel25);
            panel32.Controls.Add(panel15);
            panel32.Controls.Add(panel17);
            panel32.Controls.Add(panel16);
            panel32.Dock = DockStyle.Fill;
            panel32.Location = new Point(0, 67);
            panel32.Name = "panel32";
            panel32.Size = new Size(862, 65);
            panel32.TabIndex = 27;
            // 
            // panel22
            // 
            panel22.Controls.Add(btnSetting);
            panel22.Dock = DockStyle.Right;
            panel22.Location = new Point(-3, 0);
            panel22.Name = "panel22";
            panel22.Padding = new Padding(8, 8, 8, 8);
            panel22.Size = new Size(136, 65);
            panel22.TabIndex = 27;
            // 
            // btnSetting
            // 
            btnSetting.AutoSize = true;
            btnSetting.BackColor = SystemColors.ButtonHighlight;
            btnSetting.Dock = DockStyle.Fill;
            btnSetting.FlatStyle = FlatStyle.Popup;
            btnSetting.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnSetting.ForeColor = Color.Goldenrod;
            btnSetting.Location = new Point(8, 8);
            btnSetting.Margin = new Padding(2, 1, 2, 1);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(120, 49);
            btnSetting.TabIndex = 12;
            btnSetting.Text = "SETTING";
            btnSetting.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSetting.UseVisualStyleBackColor = false;
            btnSetting.Click += btnSetting_Click;
            // 
            // panel14
            // 
            panel14.Controls.Add(btnReprint);
            panel14.Dock = DockStyle.Right;
            panel14.Location = new Point(133, 0);
            panel14.Margin = new Padding(2, 1, 2, 1);
            panel14.Name = "panel14";
            panel14.Padding = new Padding(8, 8, 8, 8);
            panel14.Size = new Size(140, 65);
            panel14.TabIndex = 22;
            // 
            // btnReprint
            // 
            btnReprint.BackColor = SystemColors.ButtonHighlight;
            btnReprint.Dock = DockStyle.Fill;
            btnReprint.FlatStyle = FlatStyle.Popup;
            btnReprint.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnReprint.ForeColor = Color.Black;
            btnReprint.Location = new Point(8, 8);
            btnReprint.Margin = new Padding(5, 5, 5, 5);
            btnReprint.Name = "btnReprint";
            btnReprint.Size = new Size(124, 49);
            btnReprint.TabIndex = 16;
            btnReprint.Text = "REPRINT";
            btnReprint.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReprint.UseVisualStyleBackColor = false;
            btnReprint.Click += btnReprint_Click;
            // 
            // panel25
            // 
            panel25.Controls.Add(btnDelete);
            panel25.Dock = DockStyle.Right;
            panel25.Location = new Point(273, 0);
            panel25.Margin = new Padding(2, 1, 2, 1);
            panel25.Name = "panel25";
            panel25.Padding = new Padding(8, 8, 8, 8);
            panel25.Size = new Size(140, 65);
            panel25.TabIndex = 26;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.ButtonHighlight;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnDelete.ForeColor = Color.Red;
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(8, 8);
            btnDelete.Margin = new Padding(2, 1, 2, 1);
            btnDelete.Name = "btnDelete";
            btnDelete.RightToLeft = RightToLeft.Yes;
            btnDelete.Size = new Size(124, 49);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "DELETE";
            btnDelete.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // panel15
            // 
            panel15.Controls.Add(btnConnect);
            panel15.Dock = DockStyle.Right;
            panel15.Location = new Point(413, 0);
            panel15.Margin = new Padding(2, 1, 2, 1);
            panel15.Name = "panel15";
            panel15.Padding = new Padding(8, 8, 8, 8);
            panel15.Size = new Size(140, 65);
            panel15.TabIndex = 23;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = SystemColors.ButtonHighlight;
            btnConnect.Dock = DockStyle.Fill;
            btnConnect.FlatStyle = FlatStyle.Popup;
            btnConnect.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnConnect.ForeColor = Color.Black;
            btnConnect.Location = new Point(8, 8);
            btnConnect.Margin = new Padding(2, 1, 2, 1);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(124, 49);
            btnConnect.TabIndex = 17;
            btnConnect.Text = "CONNECT";
            btnConnect.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // panel17
            // 
            panel17.Controls.Add(btnPrint);
            panel17.Dock = DockStyle.Right;
            panel17.Location = new Point(553, 0);
            panel17.Margin = new Padding(2, 1, 2, 1);
            panel17.Name = "panel17";
            panel17.Padding = new Padding(8, 8, 8, 8);
            panel17.Size = new Size(140, 65);
            panel17.TabIndex = 25;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = SystemColors.ButtonHighlight;
            btnPrint.Dock = DockStyle.Fill;
            btnPrint.FlatStyle = FlatStyle.Popup;
            btnPrint.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnPrint.ForeColor = Color.Black;
            btnPrint.Location = new Point(8, 8);
            btnPrint.Margin = new Padding(2, 1, 2, 1);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(124, 49);
            btnPrint.TabIndex = 19;
            btnPrint.Text = "PRINT";
            btnPrint.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // panel16
            // 
            panel16.Controls.Add(btnExport);
            panel16.Dock = DockStyle.Right;
            panel16.Location = new Point(693, 0);
            panel16.Margin = new Padding(5, 5, 5, 5);
            panel16.Name = "panel16";
            panel16.Padding = new Padding(8, 8, 8, 8);
            panel16.Size = new Size(169, 65);
            panel16.TabIndex = 24;
            // 
            // btnExport
            // 
            btnExport.BackColor = SystemColors.ButtonHighlight;
            btnExport.Dock = DockStyle.Fill;
            btnExport.FlatStyle = FlatStyle.Popup;
            btnExport.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnExport.ForeColor = Color.Black;
            btnExport.Location = new Point(8, 8);
            btnExport.Margin = new Padding(2, 1, 2, 1);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(153, 49);
            btnExport.TabIndex = 18;
            btnExport.Text = "EXPORT";
            btnExport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // panel11
            // 
            panel11.BackColor = Color.AliceBlue;
            panel11.Controls.Add(panel21);
            panel11.Controls.Add(panel20);
            panel11.Controls.Add(panel19);
            panel11.Controls.Add(panel10);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(0, 0);
            panel11.Margin = new Padding(2, 1, 2, 1);
            panel11.Name = "panel11";
            panel11.Size = new Size(862, 67);
            panel11.TabIndex = 21;
            // 
            // panel21
            // 
            panel21.Controls.Add(label5);
            panel21.Controls.Add(tpFrom);
            panel21.Dock = DockStyle.Right;
            panel21.Location = new Point(1, 0);
            panel21.Name = "panel21";
            panel21.Size = new Size(172, 67);
            panel21.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(47, 6);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(60, 22);
            label5.TabIndex = 11;
            label5.Text = "From ";
            // 
            // tpFrom
            // 
            tpFrom.Font = new Font("Times New Roman", 16.125F);
            tpFrom.Format = DateTimePickerFormat.Short;
            tpFrom.Location = new Point(6, 29);
            tpFrom.Margin = new Padding(2, 1, 2, 1);
            tpFrom.Name = "tpFrom";
            tpFrom.Size = new Size(157, 32);
            tpFrom.TabIndex = 14;
            tpFrom.Value = new DateTime(2024, 7, 31, 0, 0, 0, 0);
            // 
            // panel20
            // 
            panel20.Controls.Add(label6);
            panel20.Controls.Add(tpTo);
            panel20.Dock = DockStyle.Right;
            panel20.Location = new Point(173, 0);
            panel20.Name = "panel20";
            panel20.Size = new Size(169, 67);
            panel20.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(46, 2);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(36, 22);
            label6.TabIndex = 12;
            label6.Text = "To ";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tpTo
            // 
            tpTo.Font = new Font("Times New Roman", 16.125F);
            tpTo.Format = DateTimePickerFormat.Short;
            tpTo.Location = new Point(2, 29);
            tpTo.Margin = new Padding(2, 1, 2, 1);
            tpTo.Name = "tpTo";
            tpTo.Size = new Size(157, 32);
            tpTo.TabIndex = 15;
            // 
            // panel19
            // 
            panel19.Controls.Add(cbPO);
            panel19.Controls.Add(label8);
            panel19.Dock = DockStyle.Right;
            panel19.Location = new Point(342, 0);
            panel19.Name = "panel19";
            panel19.Size = new Size(351, 67);
            panel19.TabIndex = 1;
            // 
            // cbPO
            // 
            cbPO.Font = new Font("Times New Roman", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbPO.FormattingEnabled = true;
            cbPO.Location = new Point(5, 29);
            cbPO.Margin = new Padding(2, 1, 2, 1);
            cbPO.Name = "cbPO";
            cbPO.Size = new Size(341, 30);
            cbPO.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(179, 6);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(37, 22);
            label8.TabIndex = 13;
            label8.Text = "PO";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            panel10.Controls.Add(btnSearch);
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(693, 0);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(5, 5, 5, 5);
            panel10.Size = new Size(169, 67);
            panel10.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ButtonHighlight;
            btnSearch.Dock = DockStyle.Fill;
            btnSearch.FlatStyle = FlatStyle.Popup;
            btnSearch.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = SystemColors.ActiveCaptionText;
            btnSearch.Location = new Point(5, 5);
            btnSearch.Margin = new Padding(2, 1, 2, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(159, 57);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // tmChecking
            // 
            tmChecking.Enabled = true;
            tmChecking.Interval = 600;
            tmChecking.Tick += timer2_Tick;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 554);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel18);
            Controls.Add(panel12);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 1, 2, 1);
            Name = "Main";
            Text = "Main";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel18.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel38.ResumeLayout(false);
            panel38.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel23.ResumeLayout(false);
            panel32.ResumeLayout(false);
            panel22.ResumeLayout(false);
            panel22.PerformLayout();
            panel14.ResumeLayout(false);
            panel25.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel21.ResumeLayout(false);
            panel21.PerformLayout();
            panel20.ResumeLayout(false);
            panel20.PerformLayout();
            panel19.ResumeLayout(false);
            panel19.PerformLayout();
            panel10.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel12;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private Panel panel18;
        private Panel panel1;
        private Panel panel9;
        private Label label1;
        private TextBox tbPO;
        private Panel panel8;
        private TextBox tbQtyib;
        private Label label2;
        private Panel panel7;
        private Label label3;
        private Panel panel6;
        private TextBox tbBox;
        private Label label4;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Panel panel13;
        private DataGridView dgvMain;
        private Panel panel4;
        private ComboBox cbPO;
        private Button btnSearch;
        private DateTimePicker tpTo;
        private Label label6;
        private Label label5;
        private DateTimePicker tpFrom;
        private Button btnSetting;
        private Label label7;
        private Panel panel5;
        public TextBox tbQty;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.Timer timer1;
        private Panel panel2;
        private Button btnPrint;
        private Button btnExport;
        private Button btnConnect;
        private Button btnReprint;
        private Panel panel14;
        private Panel panel11;
        private Panel panel15;
        private Panel panel16;
        private Panel panel17;
        private Panel panel38;
        private System.Windows.Forms.Timer tmChecking;
        private System.Windows.Forms.Timer tmOut;
        private Label label8;
        private Panel panel32;
        private Panel panel25;
        private Button btnDelete;
        private Panel panel10;
        private Panel panel21;
        private Panel panel20;
        private Panel panel19;
        private Panel panel22;
        private Panel panel23;
        private Button btnRun;
        private Label tbQuan;
        private Label lbStatus;
        private Label label9;
    }
}