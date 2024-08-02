using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;

using System.Drawing.Printing;
using App1;
using PdfSharpCore.Pdf.IO;

namespace ELECTRONIC_SCARE
{
    public partial class Setting : System.Windows.Forms.Form
    {
        private Main mainForm;
        public static string savedPdfFilePath = "C:\\ELECTRONIC_SCARE\\ELECTRONIC_SCARE\\bin\\Release\\output.pdff";
        public static int savedMarginTop;
        public static int savedMarginBottom;
        public static int savedMarginLeft;
        public static int savedMarginRight;
        public static string savedPrinterName;
        public static int savedPrintQuantity;
        //public static string savedPaperSize;

        private int printQuantity;
        private string pdfFilePath = "C:\\ELECTRONIC_SCARE\\ELECTRONIC_SCARE\\bin\\Release\\output.pdf";
        private int marginTop;
        private int marginBottom;
        private int marginLeft;
        private int marginRight;

        public Setting()
        {
            InitializeComponent();
            marginTop = 0;
            marginBottom = 0;
            marginLeft = 0;
            marginRight = 0;
        }

        public Setting(Main main)
        {
            InitializeComponent();
            mainForm = main;
            marginTop = 0;
            marginBottom = 0;
            marginLeft = 0;
            marginRight = 0;
        }

        private void tbMTop_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbPQT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbMLeft_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbMRight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbMBot_KeyPress(object sender, KeyPressEventArgs e)
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

        public Data properties;

        private async void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                marginTop = Convert.ToInt32(tbMTop.Text.Trim());
                marginBottom = Convert.ToInt32(tbMBot.Text.Trim());
                marginLeft = Convert.ToInt32(tbMLeft.Text.Trim());
                marginRight = Convert.ToInt32(tbMRight.Text.Trim());
                string printerName = cbPName.SelectedItem.ToString();

                if (!int.TryParse(tbPQT.Text, out printQuantity) || printQuantity <= 0)
                {
                    MessageBox.Show("Please enter a valid print quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                savedPdfFilePath = pdfFilePath;
                savedMarginTop = marginTop;
                savedMarginBottom = marginBottom;
                savedMarginLeft = marginLeft;
                savedMarginRight = marginRight;
                savedPrinterName = printerName;
                savedPrintQuantity = printQuantity;

                await EditAndPrintPDFAsync(mainForm, pdfFilePath, printerName, marginTop, marginBottom, marginLeft, marginRight, printQuantity);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbPName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTPaper.Items.Clear();
            cbTPaper.Items.Add("Loading...");
            cbTPaper.SelectedIndex = 0;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument p = new System.Drawing.Printing.PrintDocument();
            p.PrinterSettings.PrinterName = cbPName.SelectedItem.ToString();

            int c = p.PrinterSettings.PaperSizes.Count;
            if (c == 0)
            {
                MessageBox.Show("No printers are installed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer2.Enabled = false;
                return;
            }
            System.Drawing.Printing.PrinterSettings.PaperSizeCollection paper = p.PrinterSettings.PaperSizes;
            string[] pages = new string[c];
            for (int i = 0; i < c; i++) pages[i] = paper[i].PaperName;
            cbTPaper.Items.Clear();
            cbTPaper.Items.AddRange(pages);
            if (properties.data.PageSizeID < c)
                cbTPaper.SelectedIndex = properties.data.PageSizeID;
            else cbTPaper.SelectedIndex = 0;
            timer1.Enabled = false;
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            properties = new Data();
            properties.Load(System.IO.Directory.GetCurrentDirectory(), "data");
            int c = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count;
            string[] names = new string[c];
            for (int i = 0; i < c; i++) names[i] = System.Drawing.Printing.PrinterSettings.InstalledPrinters[i];
            cbPName.Items.AddRange(names);
            cbPName.SelectedItem = properties.data.PrinterName;

            System.Drawing.Printing.PrintDocument p = new System.Drawing.Printing.PrintDocument();
            try
            {
                if (cbPName.SelectedItem != null)
                    p.PrinterSettings.PrinterName = cbPName.SelectedItem.ToString();
                else
                {
                    p.PrinterSettings.PrinterName = System.Drawing.Printing.PrinterSettings.InstalledPrinters[0];
                    cbPName.SelectedItem = p.PrinterSettings.PrinterName;
                }
            }
            catch
            {
                p.PrinterSettings.PrinterName = System.Drawing.Printing.PrinterSettings.InstalledPrinters[0];
            }
            cbTPaper.Items.Clear();
            cbTPaper.Items.Add("Loading...");
            cbTPaper.SelectedIndex = 0;
            timer1.Enabled = true;
            tbMTop.Text = Convert.ToString(properties.data.MarginsY1);
            tbMBot.Text = Convert.ToString(properties.data.MarginsY2);
            tbMLeft.Text = Convert.ToString(properties.data.MarginsX1);
            tbMRight.Text = Convert.ToString(properties.data.MarginsX2);
            timer2.Enabled = false;
        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (properties != null)
            {
                properties.data.PrinterName = cbPName.SelectedItem?.ToString();
                properties.data.PageSizeID = cbTPaper.SelectedIndex;
                properties.data.MarginsY1 = Convert.ToInt32(tbMTop.Text.Trim());
                properties.data.MarginsY2 = Convert.ToInt32(tbMBot.Text.Trim());
                properties.data.MarginsX1 = Convert.ToInt32(tbMLeft.Text.Trim());
                properties.data.MarginsX2 = Convert.ToInt32(tbMRight.Text.Trim());
                properties.Save();
            }
        }

        public static async Task EditAndPrintPDFAsync(Main mainForm, string filePath, string printerName, int marginTop, int marginBottom, int marginLeft, int marginRight, int printQuantity)
        {
            try
            {
                string copyFilePath = filePath.Replace(".pdf", "_copy.pdf");
                File.Copy(filePath, copyFilePath, true);
                string TbPO = mainForm.GetTbPOValue();
                string TbQtyib = mainForm.GetTbQtyib();
                string GetDate = mainForm.GetDateSet();

                await Task.Run(() => OverlayTextOnPDF(copyFilePath, TbPO, TbQtyib, GetDate));
                await Task.Run(() => PrintPDF(copyFilePath, printerName, marginTop, marginBottom, marginLeft, marginRight, printQuantity));
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
                using (var inputDocument = PdfSharpCore.Pdf.IO.PdfReader.Open(filePath, PdfDocumentOpenMode.Modify))
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

                MessageBox.Show("PDF content overlaid successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static void PrintPDF(string pdfFilePath, string printerName, int marginTop, int marginBottom, int marginLeft, int marginRight, int printQuantity)
        {
            try
            {
                using (var document = PdfiumViewer.PdfDocument.Load(pdfFilePath))
                using (var printDocument = document.CreatePrintDocument())
                {
                    printDocument.PrinterSettings.PrinterName = printerName;
                    PaperSize a7PaperSize = new PaperSize("A7", 283, 410); 
                    printDocument.DefaultPageSettings.PaperSize = a7PaperSize;
                    printDocument.DefaultPageSettings.Margins = new Margins(marginLeft, marginRight, marginTop, marginBottom);

                    printDocument.PrinterSettings.Copies = (short)printQuantity;
                    printDocument.Print();
                    MessageBox.Show("Print job sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while printing the PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void WaitForFile(string filePath)
        {
            int retries = 10;
            int delay = 500; 

            while (IsFileLocked(filePath) && retries > 0)
            {
                Thread.Sleep(delay);
                retries--;
            }
        }

        public static bool IsFileLocked(string filePath)
        {
            FileStream stream = null;

            try
            {
                stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                stream?.Close();
            }

            return false;
        }
    }
}
