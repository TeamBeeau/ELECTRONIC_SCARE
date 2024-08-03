using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;
using System.Data.OleDb;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.IO.Ports;
using System.DirectoryServices.ActiveDirectory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using OfficeOpenXml;
using System.IO.Packaging;
using System.Drawing.Printing;
using App1;
using System.Reflection;
using System.Data.SQLite;
using System.Threading.Tasks.Dataflow;
using Org.BouncyCastle.Asn1.Cmp;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf.IO;
using OfficeOpenXml.Drawing.Slicer.Style;
using System.Windows.Markup;
using System.Diagnostics.Metrics;
using UglyToad.PdfPig.Fonts.TrueType.Tables;


namespace ELECTRONIC_SCARE
{
    public partial class Main : Form
    {
        //private static string connectionString = @"Server=DESKTOP-HOFO27K;Database=MAIN;Integrated Security=True;";
        private StringBuilder dataBuffer = new StringBuilder();
        private string latestQuantity = string.Empty;
        private object bufferLock = new object();
        private string scaleValue = string.Empty;
        private string[] scaleReadings = new string[3];
        string connectionString = @"Data Source=C:\DDK\MAIN.db;Version=3;";
        string settingsFilePath ="settings.txt";

        public Main()
        {
            InitializeComponent();
           
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadSettings();
            this.myDelegate = new AddDataDelegate(UpdateTextBox);
            //Bitmap bitmap = new Bitmap("Logo.png");
            //IntPtr iconHandle = bitmap.GetHicon();
            //Icon icon = Icon.FromHandle(iconHandle);
            //this.Icon = icon;
            EnsureDatabaseAndTableExist();
            LoadDataIntoGridView();
            dgvMain.Columns["ID"].Visible = false;
            dgvMain.CellFormatting += dgvMain_CellFormatting;
            UpdateStatusColumn();
            cbPO.Items.Clear();
            GetcpPO();
            string arduinoPort = LoadPort("ArduinoPort");
            string scalePort = LoadPort("ScalePort");
            AutoConnectDevices();
            CheckPrinterConnection();
        }

        private void EnsureDatabaseAndTableExist()
        
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
      
                    string query = @"
                        CREATE TABLE IF NOT EXISTS tbMAIN (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            MAIN_PO TEXT,
                            MAIN_DATE DATE,
                            MAIN_STWG REAL,
                            MAIN_BOX TEXT,
                            MAIN_STATUS TEXT
                        )";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void LoadDataIntoGridView()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    DateTime retentionDate = DateTime.Now.AddDays(-RetentionDays);
                    string query = "SELECT * FROM tbMAIN WHERE MAIN_DATE >= @RetentionDate ORDER BY MAIN_DATE DESC";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RetentionDate", retentionDate);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvMain.DataSource = dataTable;
                    dgvMain.DefaultCellStyle.Font = new Font("Times New Roman", 17);
                    dgvMain.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 22);

                    // Set column widths
                    dgvMain.Columns["MAIN_STWG"].Width = 250;
                    dgvMain.Columns["MAIN_DATE"].Width = 400;
                    dgvMain.Columns["MAIN_QTY"].Width = 200;
                    dgvMain.Columns["MAIN_PO"].Width = 450;
                    dgvMain.Columns["MAIN_STATUS"].Width = 240;
                    dgvMain.Columns["MAIN_BOX"].Width = 200;

                    // Set column headers text
                    dgvMain.Columns["MAIN_STWG"].HeaderText = "Q'TY in Box";
                    dgvMain.Columns["MAIN_DATE"].HeaderText = "Date";
                    dgvMain.Columns["MAIN_QTY"].HeaderText = "Q'TY ";
                    dgvMain.Columns["MAIN_PO"].HeaderText = "PO";
                    dgvMain.Columns["MAIN_BOX"].HeaderText = "Box";
                    dgvMain.Columns["MAIN_STATUS"].HeaderText = "Status";

                    // Align columns
                    dgvMain.Columns["MAIN_STATUS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvMain.Columns["MAIN_STWG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvMain.Columns["MAIN_BOX"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvMain.Columns["MAIN_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvMain.Columns["MAIN_STATUS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvMain.Columns["MAIN_STWG"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvMain.Columns["MAIN_BOX"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvMain.Columns["MAIN_QTY"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgvMain.EnableHeadersVisualStyles = false;
                    dgvMain.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvMain.ColumnHeadersDefaultCellStyle.BackColor;
                    dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvMain.MultiSelect = false;
                    dgvMain.ReadOnly = true;

                    // Set column display order
                    dgvMain.Columns["MAIN_DATE"].DisplayIndex = 0;
                    dgvMain.Columns["MAIN_PO"].DisplayIndex = 1;
                    dgvMain.Columns["MAIN_QTY"].DisplayIndex = 2;
                    dgvMain.Columns["MAIN_STWG"].DisplayIndex = 3;
                    dgvMain.Columns["MAIN_BOX"].DisplayIndex = 4;
                    dgvMain.Columns["MAIN_STATUS"].DisplayIndex = 5;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            UpdateStatusColumn();
        }
        private void EntryValue()
        {
            if (tbPO.Text.Trim() == "")
            {
                MessageBox.Show("Please enter PO!");
            }
            else if (tbQtyib.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Q'TY in Box!");
            }
            else
            {
                string PO = tbPO.Text.Trim();
                string Qtyib = tbQtyib.Text.Trim();
                DateTime currentTime = DateTime.Now;
                string qty = qtyibString;
                string box = tbBox.Text.Trim();
                double qtyInBox;
                double.TryParse(Qtyib, out qtyInBox);
                double quantity;
                double.TryParse(qty, out quantity);
                int roundedQtyInBox = (int)Math.Round(qtyInBox);
                int roundedQuantity = (int)Math.Round(quantity);
                int boxValueInt;

                if (string.IsNullOrEmpty(box) || !int.TryParse(box, out boxValueInt) || boxValueInt < 0)
                {
                    boxValueInt = 0;
                    tbBox.Text = boxValueInt.ToString();
                }

                int newBoxValue = boxValueInt + 1;

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO tbMAIN (MAIN_PO, MAIN_STWG, MAIN_DATE, MAIN_BOX, MAIN_QTY, MAIN_STATUS) VALUES (@PO, @Qtyib, @currentTime, @box, @qty, @status)";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PO", PO);
                    cmd.Parameters.AddWithValue("@Qtyib", roundedQtyInBox);
                    cmd.Parameters.AddWithValue("@currentTime", currentTime);
                    cmd.Parameters.AddWithValue("@box", newBoxValue);
                    cmd.Parameters.AddWithValue("@qty", roundedQuantity);
                    cmd.Parameters.AddWithValue("@status", "OK");

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        LoadDataIntoGridView();
                        tbBox.Text = newBoxValue.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert data!");
                    }

                    UpdateStatusColumn();
                    GetcpPO();
                    stateScale = StateScale.Putting;
                    SerialPortArduino.Write("Buzz");
                }
            }
        }

        private void UpdateStatusColumn()
        {
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataGridViewCell qtyCell = row.Cells["MAIN_QTY"];
                    DataGridViewCell qtyInBoxCell = row.Cells["MAIN_STWG"];
                    DataGridViewCell statusCell = row.Cells["MAIN_STATUS"];
                    if (qtyCell.Value != null && qtyInBoxCell.Value != null)
                    {
                        int qty = Convert.ToInt32(qtyCell.Value);
                        int qtyInBox = Convert.ToInt32(qtyInBoxCell.Value);
                        if (qty < qtyInBox)
                        {
                            statusCell.Value = "NG";
                        }
                        else
                        {
                            statusCell.Value = "OK";
                        }
                    }
                }
            }
        }
        private void dgvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMain.Columns[e.ColumnIndex].Name == "MAIN_STATUS" && e.RowIndex >= 0)
            {
                DataGridViewCell cell = dgvMain.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string statusValue = Convert.ToString(cell.Value);
                if (statusValue == "OK")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (statusValue == "NG")
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
            if (dgvMain.Columns[e.ColumnIndex].Name == "MAIN_DATE" && e.Value != null)
            {
                DateTime dateValue;
                if (DateTime.TryParse(e.Value.ToString(), out dateValue))
                {
                    e.Value = dateValue.ToString("dd/MM/yyyy HH:mm");
                    e.FormattingApplied = true;
                }
            }
        }
        private string previousPO = "";
        private void TbPO_KeyDown(object sender, KeyEventArgs e)//note
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbPO.Text != previousPO)
                {
                    DialogResult result = MessageBox.Show("Do you want to change the PO?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        tbQuan.Text = "0";
                        tbBox.Text = "0";
                        previousPO = tbPO.Text;
                        i = true;
                    }
                    else
                    {
                        tbPO.Text = previousPO;
                        i = false;
                    }
                }
            }
        }
        private void tbSetValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (tbPO.Text != previousPO)
                {
                    DialogResult result = MessageBox.Show("Do you want to change the Q'TY in Box?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        tbQuan.Text = "0";
                        tbBox.Text = "0";
                        previousPO = tbQtyib.Text;
                        o = true;
                    }
                    else
                    {
                        tbQtyib.Text = previousPO;
                        o = false;

                    }
                }
            }
        }
        private void tbSetValue_KeyPress(object sender, KeyPressEventArgs e)//PO
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (textBox.Text.Contains(".") || textBox.Text.Contains(",")))
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (dgvMain.SelectedRows.Count > 0)
        //    {
        //        DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //        if (result == DialogResult.Yes)
        //        {
        //            DataGridViewRow selectedRow = dgvMain.SelectedRows[0];
        //            string mainCode = selectedRow.Cells["ID"].Value.ToString();
        //            string po = cbPO.SelectedItem?.ToString();
        //            using (SqlConnection conn = new SqlConnection(connectionString))
        //            {
        //                conn.Open();
        //                string query = "DELETE FROM tbMAIN WHERE ID = @mainCode";
        //                SqlCommand cmd = new SqlCommand(query, conn);
        //                cmd.Parameters.AddWithValue("@mainCode", mainCode);
        //                int rowsAffected = cmd.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    MessageBox.Show("Data deleted successfully!");
        //                    LoadDataIntoGridView();
        //                    GetcpPO();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Failed to delete data!");
        //                }
        //            }
        //        }
        //        FilterDate();

        //    }

        //    else
        //    {
        //        MessageBox.Show("Please select a row to delete!");
        //    }
        //}
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dgvMain.SelectedRows[0];
                    string mainCode = selectedRow.Cells["ID"].Value.ToString();
                    string po = cbPO.SelectedItem?.ToString();
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM tbMAIN WHERE ID = @mainCode";
                        SQLiteCommand cmd = new SQLiteCommand(query, conn);
                        cmd.Parameters.AddWithValue("@mainCode", mainCode);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data deleted successfully!");
                            LoadDataIntoGridView();
                            GetcpPO();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete data!");
                        }
                    }
                }
                FilterDate();
            }
            else
            {
                MessageBox.Show("Please select a row to delete!");
            }
            LoadDataIntoGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterDate();
            //LoadDataIntoGridView();
            SearchValueBox();
        }
        //private void FilterDate()
        //{
        //    DateTime startDate = tpFrom.Value.Date;
        //    DateTime endDate = tpTo.Value.Date.AddDays(1);
        //    string po = cbPO.SelectedItem?.ToString();

        //    if (startDate >= endDate)
        //    {
        //        MessageBox.Show("Start date must be before end date!");
        //        return;
        //    }

        //    string query = "SELECT * FROM tbMAIN WHERE MAIN_DATE >= @StartDate AND MAIN_DATE < @EndDate";

        //    if (!string.IsNullOrEmpty(po))
        //    {
        //        query += " AND MAIN_PO = @PO";
        //    }
        //    query += " ORDER BY MAIN_DATE DESC";

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@StartDate", startDate);
        //        cmd.Parameters.AddWithValue("@EndDate", endDate);
        //        if (!string.IsNullOrEmpty(po))
        //        {
        //            cmd.Parameters.AddWithValue("@PO", po);
        //        }

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        DataTable dataTable = new DataTable();
        //        adapter.Fill(dataTable);
        //        dgvMain.DataSource = dataTable;
        //        dgvMain.Columns["ID"].Visible = false;
        //        UpdateStatusColumn();
        //    }
        //}
        private void FilterDate()
        {
            DateTime startDate = tpFrom.Value.Date;
            DateTime endDate = tpTo.Value.Date.AddDays(1);
            string po = cbPO.SelectedItem?.ToString();

            if (startDate >= endDate)
            {
                MessageBox.Show("Start date must be before end date!");
                return;
            }

            string query = "SELECT * FROM tbMAIN WHERE MAIN_DATE >= @StartDate AND MAIN_DATE < @EndDate";

            if (!string.IsNullOrEmpty(po))
            {
                query += " AND MAIN_PO = @PO";
            }
            query += " ORDER BY MAIN_DATE DESC";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                if (!string.IsNullOrEmpty(po))
                {
                    cmd.Parameters.AddWithValue("@PO", po);
                }

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvMain.DataSource = dataTable;
                dgvMain.Columns["ID"].Visible = false;
                // Set column widths
                dgvMain.Columns["MAIN_STWG"].Width = 250;
                dgvMain.Columns["MAIN_DATE"].Width = 400;
                dgvMain.Columns["MAIN_QTY"].Width = 200;
                dgvMain.Columns["MAIN_PO"].Width = 450;
                dgvMain.Columns["MAIN_STATUS"].Width = 240;
                dgvMain.Columns["MAIN_BOX"].Width = 200;

                // Set column headers text
                dgvMain.Columns["MAIN_STWG"].HeaderText = "Q'TY in Box";
                dgvMain.Columns["MAIN_DATE"].HeaderText = "Date";
                dgvMain.Columns["MAIN_QTY"].HeaderText = "Q'TY ";
                dgvMain.Columns["MAIN_PO"].HeaderText = "PO";
                dgvMain.Columns["MAIN_BOX"].HeaderText = "Box";
                dgvMain.Columns["MAIN_STATUS"].HeaderText = "Status";

                // Align columns
                dgvMain.Columns["MAIN_STATUS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMain.Columns["MAIN_STWG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMain.Columns["MAIN_BOX"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMain.Columns["MAIN_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMain.Columns["MAIN_STATUS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMain.Columns["MAIN_STWG"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMain.Columns["MAIN_BOX"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMain.Columns["MAIN_QTY"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvMain.EnableHeadersVisualStyles = false;
                dgvMain.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvMain.ColumnHeadersDefaultCellStyle.BackColor;
                dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvMain.MultiSelect = false;
                dgvMain.ReadOnly = true;

                // Set column display order
                dgvMain.Columns["MAIN_DATE"].DisplayIndex = 0;
                dgvMain.Columns["MAIN_PO"].DisplayIndex = 1;
                dgvMain.Columns["MAIN_QTY"].DisplayIndex = 2;
                dgvMain.Columns["MAIN_STWG"].DisplayIndex = 3;
                dgvMain.Columns["MAIN_BOX"].DisplayIndex = 4;
                dgvMain.Columns["MAIN_STATUS"].DisplayIndex = 5;
                UpdateStatusColumn();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Setting formsetting = new Setting(this);
            formsetting.Size = new Size(1121, 1000);
            formsetting.StartPosition = FormStartPosition.Manual;
            formsetting.Location = new Point(1000, 400);
            formsetting.Show();
            formsetting.FormBorderStyle = FormBorderStyle.FixedDialog;
            formsetting.MaximizeBox = false;
        }

        //private void GetcpPO()
        //{
        //    cbPO.Items.Clear();
        //    cbPO.Items.Insert(0, "");
        //    cbPO.SelectedIndex = 0;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "SELECT DISTINCT MAIN_PO FROM tbMAIN";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            string value = reader["MAIN_PO"].ToString();
        //            cbPO.Items.Add(value);
        //        }
        //        reader.Close();
        //    }
        //}
        private void GetcpPO()
        {
            cbPO.Items.Clear();
            cbPO.Items.Insert(0, "");
            cbPO.SelectedIndex = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT MAIN_PO FROM tbMAIN";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string value = reader["MAIN_PO"].ToString();
                    cbPO.Items.Add(value);
                }
                reader.Close();
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            CheckPrinterConnection();
            DisconnectPorts();
            listPort = SerialPort.GetPortNames().ToList();
            if (listPort.Count == 0)
            {
                MessageBox.Show("No COM ports found.");
                return;
            }
            index = 0;
            ConnectPort();
            timer1.Enabled = true;
        }
        SerialPort SerialPortArduino=new SerialPort();
        SerialPort SerialPortScale;
        List<System.String> listPort;
        int index = 0;
        string Set = "Set = 100".Trim();
        string Conn = "Conn".Trim();
        string True = "True".Trim();
        string Fals = "Fals".Trim();
        string Disc = "Disc".Trim();
        private bool arduinoConnected = false;
        private bool scaleConnected = false;
        private string arduinoPortName = "";
        private void ConnectPort()
        {
            try
            {
                if (index < listPort.Count)
                {
                    string portName = listPort[index];
                    if (!arduinoConnected)
                    {
                        SerialPortArduino = new SerialPort(portName)
                        {
                            BaudRate = 9600,
                            Parity = Parity.None,
                            DataBits = 8,
                            StopBits = StopBits.One,
                            Handshake = Handshake.None,
                            ReadTimeout = 500,
                            WriteTimeout = 500
                        };

                        if (SerialPortArduino.IsOpen)
                        {
                            SerialPortArduino.Close();
                        }

                        try
                        {
                            SerialPortArduino.Open();
                            SerialPortArduino.Write("Conn\n");
                            System.Threading.Thread.Sleep(500);
                            string response = SerialPortArduino.ReadExisting();

                            if (response.Contains("DDK01"))
                            {
                                SerialPortArduino.DataReceived += new SerialDataReceivedEventHandler(SerialPortArduinoDataReceivedHandler);
                                SerialPortArduino.Write("Conn\n");
                                arduinoPortName = portName;
                                arduinoConnected = true;
                                SavePort("ArduinoPort", portName);
                               // MessageBox.Show($"Arduino connected on {portName}");
                                toolStripStatusLabel2.Text = $"Arduino: connected on {portName}";
                                toolStripStatusLabel2.ForeColor = Color.Green;
                            }
                            else
                            {
                                SerialPortArduino.Close();
                            }
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            MessageBox.Show($"Access to the port '{portName}' is denied: {ex.Message}");
                            SerialPortArduino.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error connecting to port '{portName}': {ex.Message}");
                            SerialPortArduino.Close();
                        }
                    }

                    if (!scaleConnected && portName != arduinoPortName)
                    {
                        SerialPortScale = new SerialPort(portName)
                        {
                            BaudRate = 9600,
                            Parity = Parity.None,
                            DataBits = 8,
                            StopBits = StopBits.One,
                            Handshake = Handshake.None,
                            ReadTimeout = 500,
                            WriteTimeout = 500
                        };

                        if (SerialPortScale.IsOpen)
                        {
                            SerialPortScale.Close();
                        }

                        try
                        {
                            SerialPortScale.Open();
                            SerialPortScale.WriteLine("RQ\r\n");
                            System.Threading.Thread.Sleep(500);
                            string response = SerialPortScale.ReadExisting();
                            if (!string.IsNullOrEmpty(response))
                            {
                                SerialPortScale.DataReceived += new SerialDataReceivedEventHandler(SerialPortScaleDataReceivedHandler);
                                scaleConnected = true;
                                SavePort("ScalePort", portName);
                                MessageBox.Show($"Scale connected on {portName}");
                                timer1.Enabled = false;
                            }
                            else
                            {
                                SerialPortScale.Close();
                            }
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            MessageBox.Show($"Access to the port '{portName}' is denied: {ex.Message}");
                            SerialPortScale.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error connecting to port '{portName}': {ex.Message}");
                            SerialPortScale.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
        }
        private void AutoConnectDevices()
        {
            string arduinoPort = LoadPort("ArduinoPort");
            string scalePort = LoadPort("ScalePort");

            if (!string.IsNullOrEmpty(arduinoPort))
            {
                SerialPortArduino = new SerialPort(arduinoPort)
                {
                    BaudRate = 9600,
                    Parity = Parity.None,
                    DataBits = 8,
                    StopBits = StopBits.One,
                    Handshake = Handshake.None,
                    ReadTimeout = 500,
                    WriteTimeout = 500
                };

                try
                {
                    SerialPortArduino.Open();
                    SerialPortArduino.Write("Conn\n");
                    System.Threading.Thread.Sleep(500);
                    string response = SerialPortArduino.ReadExisting();

                    if (response.Contains("DDK01"))
                    {
                        SerialPortArduino.DataReceived += new SerialDataReceivedEventHandler(SerialPortArduinoDataReceivedHandler);
                        arduinoConnected = true;
                      //  MessageBox.Show($"Arduino connected on {arduinoPort}");
                        toolStripStatusLabel2.Text = $"Arduino: connected on {arduinoPort}";
                        toolStripStatusLabel2.ForeColor = Color.Green;
                    }
                    else
                    {
                        SerialPortArduino.Close();
                    }
                }
                catch (Exception ex)
                {
                 //   MessageBox.Show($"Error connecting to Arduino port '{arduinoPort}': {ex.Message}");
                    toolStripStatusLabel2.Text = $"Arduino: lost connection on {arduinoPort}";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    SerialPortArduino.Close();
                }
            }

            if (!string.IsNullOrEmpty(scalePort) && scalePort != arduinoPort)
            {
                SerialPortScale = new SerialPort(scalePort)
                {
                    BaudRate = 9600,
                    Parity = Parity.None,
                    DataBits = 8,
                    StopBits = StopBits.One,
                    Handshake = Handshake.None,
                    ReadTimeout = 500,
                    WriteTimeout = 500
                };

                try
                {
                    SerialPortScale.Open();
                    SerialPortScale.WriteLine("RQ\r\n");
                    System.Threading.Thread.Sleep(500);
                    string response = SerialPortScale.ReadExisting();
                    if (!string.IsNullOrEmpty(response))
                    {
                        SerialPortScale.DataReceived += new SerialDataReceivedEventHandler(SerialPortScaleDataReceivedHandler);
                        scaleConnected = true;
                      //  MessageBox.Show($"Scale connected on {scalePort}");
                    }
                    else
                    {
                        SerialPortScale.Close();
                    }
                }
                catch (Exception ex)
                {
                  //  MessageBox.Show($"Error connecting to Scale port '{scalePort}': {ex.Message}");
                    SerialPortScale.Close();
                }
            }
        }
        private void SavePort(string deviceName, string portName)
        {
            var settings = new Dictionary<string, string>();

            if (File.Exists(settingsFilePath))
            {
                foreach (var line in File.ReadLines(settingsFilePath))
                {
                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        settings[parts[0]] = parts[1];
                    }
                }
            }

            settings[deviceName] = portName;

            using (var writer = new StreamWriter(settingsFilePath))
            {
                foreach (var kvp in settings)
                {
                    writer.WriteLine($"{kvp.Key}={kvp.Value}");
                }
            }
        }

        private string LoadPort(string deviceName)
        {
            if (File.Exists(settingsFilePath))
            {
                foreach (var line in File.ReadLines(settingsFilePath))
                {
                    var parts = line.Split('=');
                    if (parts.Length == 2 && parts[0] == deviceName)
                    {
                        return parts[1];
                    }
                }
            }

            return null;
        }

        private void SerialPortArduinoDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            if (this.IsDisposed || !this.IsHandleCreated)
            {
                return;
            }

            this.Invoke(new Action(() => ProcessReceivedData(indata)));
            this.Invoke(new System.Windows.Forms.MethodInvoker(delegate
            {
            }));
        }
        private int z = 0;
        private void ProcessReceivedData(string indata)
        {
            if (indata.Trim() == "DDK01")
            {
                timer1.Enabled = false;
            }
            if (indata.Contains("Counter"))
            {
                z++;
                tbQuan.Text = z.ToString();
                SerialPortArduino.WriteLine("Done");
            }
        }
        public delegate void AddDataDelegate(string myString);
        public AddDataDelegate myDelegate;
        private string pendingQuantity;
        private int stableCount = 0;
        private int readCount = 0;
        private List<string> quantityList = new List<string>();

        private void UpdateTextBox(string data)
        {
            if (tbQty.InvokeRequired)
            {
                tbQty.BeginInvoke(new Action(() =>
                {
                    tbQty.Text = data;
                }));
            }
            else
            {
                tbQty.Text = data;
            }
        }

        private void ProcessData(string data)
        {
            lock (bufferLock)
            {

                if (data != "0")
                {
                    quantityList.Add(data);
                    readCount++;
                    if (readCount >= 20) // Doccc
                    {
                        string stableQuantity = GetStableQuantity(quantityList);
                        UpdateTextBox(stableQuantity);
                        quantityList.Clear();
                        readCount = 0;
                    }
                }
                else
                {
                    UpdateTextBox("0");
                    quantityList.Clear();
                    readCount = 0;
                }
            }
        }


        private string GetStableQuantity(List<string> quantities)
        {
            var grouped = quantities.GroupBy(q => q).OrderByDescending(g => g.Count());
            return grouped.First().Key;
        }

        private void SerialPortScaleDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            CheckConnectScale();
            SerialPort sp = (SerialPort)sender;

            string indata = sp.ReadExisting();
            if (this.IsDisposed || !this.IsHandleCreated)
            {
                return;
            }

            lock (bufferLock)
            {
                dataBuffer.Append(indata);
            }

            Task.Run(() => ProcessBuffer());
        }

        private void ProcessBuffer()
        {
            lock (bufferLock)
            {
                string bufferContent = dataBuffer.ToString();
                int startIndex = 0;

                while ((startIndex = bufferContent.IndexOf("Q", startIndex)) != -1)
                {
                    int endIndex = bufferContent.IndexOfAny(new[] { '\r', '\n' }, startIndex);
                    if (endIndex == -1)
                    {
                        break;
                    }

                    string line = bufferContent.Substring(startIndex, endIndex - startIndex);
                    string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (parts[i] == "Q" && i + 1 < parts.Length)
                        {
                            string quantity = parts[i + 1];
                            if (!string.IsNullOrEmpty(quantity))
                            {
                                ProcessData(quantity);
                            }
                            break;
                        }
                    }
                    startIndex = endIndex + 1;
                }
                if (startIndex > 0)
                {
                    dataBuffer.Remove(0, startIndex);
                }
            }
        }

        private void CheckConnectScale()
        {
            toolStripStatusLabel1.Text = "Scale: Connected";
            toolStripStatusLabel1.ForeColor = Color.Green;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (!arduinoConnected)
            {
                index++;
                if (index >= listPort.Count)
                {
                    //MessageBox.Show("Connection Failed");
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "Scale: lost connection.";
                    toolStripStatusLabel2.Text = "Arduino: lost connection on ";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    return;
                }
            }
            else if (!scaleConnected)
            {
                index++;
                if (index >= listPort.Count)
                {
                   // MessageBox.Show("Scale connection Failed");
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    toolStripStatusLabel1.Text = "Scale: lost connection.";
                    toolStripStatusLabel2.Text = "Arduino: lost Connected";
                    toolStripStatusLabel2.ForeColor = Color.Green;
                    return;
                }
            }

            ConnectPort();
            if (!arduinoConnected || !scaleConnected)
            {
                timer1.Enabled = true;
            }
        }
        private void DisconnectPorts()
        {
            if (SerialPortArduino != null)
            {
                try
                {
                    if (SerialPortArduino.IsOpen)
                    {
                        SerialPortArduino.DataReceived -= SerialPortArduinoDataReceivedHandler;
                        SerialPortArduino.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error disconnecting Arduino port: {ex.Message}");
                }
                finally
                {
                    SerialPortArduino.Dispose();
                }
            }
            if (SerialPortScale != null)
            {
                try
                {
                    if (SerialPortScale.IsOpen)
                    {
                        SerialPortScale.DataReceived -= SerialPortScaleDataReceivedHandler;
                        SerialPortScale.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error disconnecting Scale port: {ex.Message}");
                }
                finally
                {
                    SerialPortScale.Dispose();
                }
            }
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SerialPortArduino.Write(Disc);
            if (SerialPortArduino != null && SerialPortArduino.IsOpen)
            {
                DisconnectPorts();
            }
        }

        public void ExportFilteredDataGridViewToExcel(DataGridView dataGridView)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Save an Excel File",
                FileName = "ExcelFile.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileInfo = new FileInfo(saveFileDialog.FileName);
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(fileInfo))
                {
                    string newWorksheetName = "Filtered Data";
                    var existingSheet = package.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == newWorksheetName);
                    if (existingSheet != null)
                    {
                        package.Workbook.Worksheets.Delete(existingSheet);
                    }

                    var worksheet = package.Workbook.Worksheets.Add(newWorksheetName);
                    worksheet.Cells[1, 1].Value = "Date";
                    worksheet.Cells[1, 2].Value = "PO";
                    worksheet.Cells[1, 3].Value = "Q'TY";
                    worksheet.Cells[1, 4].Value = "Q'TY in Box";
                    worksheet.Cells[1, 5].Value = "Box";
                    worksheet.Cells[1, 6].Value = "Status";
                    for (int i = 1; i <= 6; i++)
                    {
                        worksheet.Cells[1, i].Style.Font.Name = "Times New Roman";
                        worksheet.Cells[1, i].Style.Font.Size = 20;
                        worksheet.Column(i).Width = 20;
                    }
                    int rowIndex = 2;
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.Visible)
                        {
                            worksheet.Cells[rowIndex, 1].Value = row.Cells["MAIN_DATE"].Value != null ? Convert.ToDateTime(row.Cells["MAIN_DATE"].Value).ToString("yyyy-MM-dd HH:mm") : "";
                            worksheet.Cells[rowIndex, 2].Value = row.Cells["MAIN_PO"].Value?.ToString();
                            worksheet.Cells[rowIndex, 3].Value = row.Cells["MAIN_QTY"].Value?.ToString();
                            worksheet.Cells[rowIndex, 4].Value = row.Cells["MAIN_STWG"].Value?.ToString();
                            worksheet.Cells[rowIndex, 5].Value = row.Cells["MAIN_BOX"].Value?.ToString();
                            worksheet.Cells[rowIndex, 6].Value = row.Cells["MAIN_STATUS"].Value?.ToString();

                            for (int i = 1; i <= 6; i++)
                            {
                                worksheet.Cells[rowIndex, i].Style.Font.Name = "Times New Roman";
                                worksheet.Cells[rowIndex, i].Style.Font.Size = 16;
                            }
                            rowIndex++;
                        }
                    }

                    worksheet.Cells.AutoFitColumns();
                    package.Save();
                }

                MessageBox.Show("Data exported successfully!", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportFilteredDataGridViewToExcel(dgvMain);
        }

        private void tbPO_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbPO.MaxLength = 18;
        }
        private void CheckPrinterConnection()
        {
            string printerNameToCheck = "SP36 (Copy 1)";//ten may inn
            bool isPrinterConnected = false;

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (printer.Equals(printerNameToCheck, StringComparison.OrdinalIgnoreCase))
                {
                    isPrinterConnected = true;
                    break;
                }
            }

            if (isPrinterConnected)
            {
                toolStripStatusLabel3.ForeColor = Color.Green;
                toolStripStatusLabel3.Text = $"Printer '{printerNameToCheck}': connected.";
            }
            else
            {
                toolStripStatusLabel3.ForeColor = Color.Red;
                toolStripStatusLabel3.Text = $"Printer '{printerNameToCheck}': not connected.";
            }
        }
        private async void btnReprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Setting.savedPdfFilePath) && !string.IsNullOrEmpty(Setting.savedPrinterName))
                {
                    await Setting.EditAndPrintPDFAsync(
                        this,
                        Setting.savedPdfFilePath,
                        Setting.savedPrinterName,
                        //Setting.savedPaperSize, 
                        Setting.savedMarginTop,
                        Setting.savedMarginBottom,
                        Setting.savedMarginLeft,
                        Setting.savedMarginRight,
                        Setting.savedPrintQuantity
                    );
                }
                else
                {
                    MessageBox.Show("There is no information to reprint.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reprinting the PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public string GetTbPOValue()
        {
            return tbPO.Text;
        }
        public string GetTbQtyib()
        {
            return tbQtyib.Text;
        }
        public string GetDateSet()
        {
            return DateTime.Now.ToString("yyyy/MM/dd HH:mm");
        }
        private int RetentionDays = 30;
        private void btnSetting_Click(object sender, EventArgs e)
        {
            using (Set settingsForm = new Set(RetentionDays))
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    RetentionDays = settingsForm.RetentionDays;
                    DeleteOldData();
                    LoadDataIntoGridView();
                }
            }
        }
        private void DeleteOldData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    DateTime retentionDate = DateTime.Now.AddDays(-RetentionDays);
                    string query = "DELETE FROM tbMAIN WHERE MAIN_DATE < @RetentionDate";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RetentionDate", retentionDate);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting old data: " + ex.Message);
                }
            }
            LoadDataIntoGridView();
        }
        private void LoadSettings()
        {
            if (System.IO.File.Exists("settings.txt"))
            {
                int.TryParse(System.IO.File.ReadAllText("settings.txt"), out RetentionDays);
            }
            else
            {
                RetentionDays = 7;
            }
        }
        //private bool isPOChanged = false;
        private bool i = false;
        private bool o = false;
        private void BtnRun_Click(object sender, EventArgs e)
        {
            if (i == false)
            {
                tbPO.Enabled = false;
                tbQtyib.Enabled = false;
                btnSearch.Enabled = false;
                btnSetting.Enabled = false;
                btnReprint.Enabled = false;
                btnPrint.Enabled = false;
                btnDelete.Enabled = false;
                btnConnect.Enabled = false;
                btnExport.Enabled = false;
                i = true;
                btnRun.Text = "END";
                btnRun.BackColor = Color.Sienna;
                btnRun.ForeColor = Color.White;
            }
            else
            {
                tbPO.Enabled = true;
                tbQtyib.Enabled = true;
                btnSearch.Enabled = true;
                btnSetting.Enabled = true;
                btnReprint.Enabled = true;
                btnPrint.Enabled = true;
                btnDelete.Enabled = true;
                btnConnect.Enabled = true;
                btnExport.Enabled = true;
                i = false;
                btnRun.Text = "RUN";
                btnRun.BackColor = Color.DarkSlateGray;
                btnRun.ForeColor = Color.White;
            }

        }
        private void tbPO_TextChanged(object sender, EventArgs e)
        {
            GetTbPOValue();
        }

        private void tbQtyib_TextChanged(object sender, EventArgs e)
        {
            GetTbQtyib();
        }
        private void SearchValueBox()
        {
            int a = 0;
            string selectedPO = cbPO.SelectedItem?.ToString();

            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (row.IsNewRow) continue;

                string rowPO = row.Cells["MAIN_PO"].Value?.ToString();
                string rowStatus = row.Cells["MAIN_STATUS"].Value?.ToString();

                if (rowPO != selectedPO)
                {
                    tbBox.Text = "00";
                    break;
                }

                if (rowPO == selectedPO && rowStatus == "OK")
                {
                    a++;
                }
                tbBox.Text = a.ToString();
            }
        }
        string pdfFilePath = "output.pdf";
        private async Task PrintLabelAsync()
        {
            try
            {
                string printerName = "SP36 (Copy 1)";//Ten may in
                int printQuantity = 1;

                await EditAndPrintPDFAsync(pdfFilePath, printerName, printQuantity);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Check = false;
                OK = false;
            }
        }
        public async Task EditAndPrintPDFAsync(string filePath, string printerName, int printQuantity)
        {
            try
            {
                string copyFilePath = filePath.Replace(".pdf", "_copy.pdf");
                File.Copy(filePath, copyFilePath, true);
                string TbPO = GetTbPOValue();
                string TbQtyib = GetTbQtyib();
                string GetDate = GetDateSet();

                await Task.Run(() => OverlayTextOnPDF(copyFilePath, TbPO, TbQtyib, GetDate));
                await Task.Run(() => PrintPDF(copyFilePath, printerName, printQuantity));
                if (File.Exists(copyFilePath))
                {
                    File.Delete(copyFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while editing or printing the PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void OverlayTextOnPDF(string filePath, string TbPO, string TbQtyib, string GetDate)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found: " + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tempFilePath = filePath + ".temp";

            try
            {
                using (var inputDocument = PdfReader.Open(filePath, PdfDocumentOpenMode.Modify))
                {
                    foreach (var page in inputDocument.Pages)
                    {
                        using (var gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Append))
                        {
                            XFont font = new XFont("Helvetica", 28, XFontStyle.Bold);
                            gfx.DrawString(TbQtyib, font, XBrushes.Red, new XRect(140, 140, page.Width, page.Height), XStringFormats.TopLeft);
                            gfx.DrawString(TbPO, font, XBrushes.Red, new XRect(140, 90, page.Width, page.Height), XStringFormats.TopLeft);
                            gfx.DrawString(GetDate, font, XBrushes.Red, new XRect(140, 190, page.Width, page.Height), XStringFormats.TopLeft);
                        }
                    }
                    inputDocument.Save(tempFilePath);
                }

                File.Delete(filePath);
                File.Move(tempFilePath, filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
            }
        }
        public static void PrintPDF(string pdfFilePath, string printerName, int printQuantity)
        {
            try
            {
                using (var document = PdfiumViewer.PdfDocument.Load(pdfFilePath))
                using (var printDocument = document.CreatePrintDocument())
                {
                    printDocument.PrinterSettings.PrinterName = printerName;
                    PaperSize a7PaperSize = new PaperSize("A7", 283, 410);
                    printDocument.DefaultPageSettings.PaperSize = a7PaperSize;

                    printDocument.PrinterSettings.Copies = (short)printQuantity;
                    printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while printing the PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool OK = false;
        private bool Check = false;
        private string qtyibString = null;
        private int lastQty = -1;
         bool IsStartScale = false;
        int numStable = 0;
        enum StateScale
        {
           
            Putting,
            CheckBlance,
            CheckZero,
            InsertData

        }
        StateScale stateScale = StateScale.Putting;
        bool IsBlance=false;
        bool IsCheckZero = false;
        bool IsStable = false;
        private async void tbQty_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbQty.Text.Trim(), out int qty) && int.TryParse(tbQtyib.Text.Trim(), out int qtyib))
            {
                switch(stateScale)
                {
                    case StateScale.Putting:
                        if (qty != 0)
                            IsStable = true;
                        else
                            IsStable = false;                      
                        break;
                    case StateScale.CheckBlance:
                      
                        if (qty ==qtyib)
                            IsStable = true;
                        else
                            IsStable = false;
                      
                        break;
                    case StateScale.CheckZero:
                        if (qty == 0)
                            IsStable = true;
                        else
                            IsStable = false;
                        break;
                    case StateScale.InsertData:
                       
                        break;
                }
              

            }
            if (stateScale == StateScale.Putting)
                lbStatus.Text = "---";
            else
                lbStatus.Text = stateScale.ToString();
        }
        
      
        private async void timer2_Tick(object sender, EventArgs e)
        {
            if (IsStable)
                numStable++;
            else
                numStable = 0;
            switch (stateScale)
            {
                case StateScale.Putting:
                    tmChecking.Interval = 200;
                   
                    if (numStable > 2)
                    {
                        try
                        {
                            if (SerialPortArduino.IsOpen)
                                SerialPortArduino.WriteLine(Fals);
                        }
                        catch (Exception)
                        {
                        }
                        numStable = 0; IsStable = false;
                        OK = false;
                       
                        stateScale = StateScale.CheckBlance;
                    }
                    break;
                case StateScale.CheckBlance:
                    OK = true;
                    try
                    {
                        if (SerialPortArduino.IsOpen)
                            SerialPortArduino.WriteLine(True);
                    }
                    catch (Exception ex)
                    {

                    }
                    if (numStable > 2)
                    {
                        numStable = 0; IsStable = false;
                        stateScale = StateScale.CheckZero;
                    }
                       
                    
                    break;
                case StateScale.CheckZero:
                    if (numStable > 5)
                    {
                        tmChecking.Interval = 1000;
                        stateScale = StateScale.InsertData;
                        numStable = 0; IsStable = false;
                        qtyibString = tbQtyib.Text.Trim();
                      await PrintLabelAsync();
                        EntryValue();
                        try
                        {
                            if (SerialPortArduino.IsOpen)
                                SerialPortArduino.WriteLine(Fals);
                        }
                        catch (Exception)
                        {
                        }

                    }
                       
                    break;
            }

            if (stateScale == StateScale.Putting)
                lbStatus.Text = "---";
            else
                lbStatus.Text = stateScale.ToString();


        }

    }
}