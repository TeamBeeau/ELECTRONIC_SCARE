using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;
//using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Input;

namespace App1
{
    public class Data
    {

        private _data data_;
        private string _path = string.Empty;
        private string _name = string.Empty;
        public Data()
        {
            data_ = new _data();
            currentForm = new _reload();
        }
        public void newD()
        {
            data_ = new _data();
            currentForm = new _reload();
        }
        public _data data
        {
            get { return data_; }
            set { data_ = data; }
        }
        public _reload currentForm;
        public void Save()
        {
            Save(_path, _name);
        }

        public void Save(string path, string name)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                //BinaryFormatter bf = new BinaryFormatter();
                //bf.Serialize(ms, data_);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                File.WriteAllText(path + "//" + name + "1.bin", Convert.ToBase64String(buffer));
                File.Exists(path + "//" + name + "1.bin");
            }
        }
        public void SaveCurrentForm()
        {
            SaveCurrentForm(currentForm._path, currentForm._name);
        }
        public void SaveCurrentForm(string path, string name)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                //BinaryFormatter bf = new BinaryFormatter();
                //bf.Serialize(ms, currentForm);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);

                File.WriteAllText(path + "//" + name + ".bin", Convert.ToBase64String(buffer));
                File.Exists(path + "//" + name + ".bin");
            }
        }
        public void LoadCurrentForm()
        {
            LoadCurrentForm(currentForm._path, currentForm._name);
        }
        public void LoadCurrentForm(string path, string name)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(File.ReadAllText(path + "//" + name + ".bin"))))
                {
                    //BinaryFormatter bf = new BinaryFormatter();
                    //currentForm = (_reload)bf.Deserialize(ms);
                }
            }
            catch (Exception)
            { }
            currentForm._path = path;
            currentForm._name = name;
        }
        public void Load()
        {
            Load(_path, _name);
        }
        public void Load(string path, string name)
        {
            _path = path;
            _name = name;
            try
            {

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(File.ReadAllText(path + "//" + name + "1.bin"))))
                {
                    //BinaryFormatter bf = new BinaryFormatter();
                    //data_ = (_data)bf.Deserialize(ms);
                }

            }
            catch (Exception)
            { }
        }
    }

    [Serializable()]
    public class _reload
    {
        public List<string> contain;
        public string[] Texts;
        public string _path = "";
        public string _name = "";
        public List<float> GW;
        public List<float> NW;
        public List<bool> GW_change;
        public float TL = 0F;
        public float TL2 = 0F;
        public float TL3 = 0F;
        public float TL4 = 0F;
        public int Mode_KhauTru = 0;
        public _reload()
        {
            contain = new List<string>();
            contain.Add("tbCapDo");
            contain.Add("tbDoffNo1");
            contain.Add("tbDoffNo2");
            contain.Add("tbDoffNo3");
            contain.Add("tbF7");
            contain.Add("tbGhiChu");
            contain.Add("tbLoaiMay");
            contain.Add("tbLoaiCuon");
            contain.Add("tbLot");
            contain.Add("tbNamDG");
            contain.Add("tbNamSX");
            contain.Add("tbNgayDG");
            contain.Add("tbNgayNhapKho");
            contain.Add("tbNgaySX");
            contain.Add("tbPhanLoai");
            contain.Add("tbQuyCach");
            contain.Add("tbSoLuongMoiThung");
            contain.Add("tbSoPhieu");
            contain.Add("tbThangDG");
            contain.Add("tbThangSX");
            contain.Add("tbTrongLuongKhauTru");
            contain.Add("tbViTriLuuKho");
            contain.Add("tbPallet");
            contain.Add("tbTongGW");
            contain.Add("tbTongNW");
            Texts = new string[contain.Count];
            GW = new List<float>();
            NW = new List<float>();
            GW_change = new List<bool>();

        }
    }

    [Serializable()]
    public class _data
    {
        public DateTime date;
        public string Dir_Save = string.Empty;
        public int count = -1;
        public string MAC = string.Empty;
        public bool Ac = false;
        public string PortName = string.Empty;
        public int Baudrate = 9600;
        public int DataBit = 8;
        public string Parity = "None";
        public string Stopbit = "One";
        public string PrinterName = "";
        public int PageSizeID = 0;
        public int MarginsX1 = 5;
        public int MarginsX2 = 5;
        public int MarginsY1 = 5;
        public int MarginsY2 = 5;
        public bool Landscape = true;
        public bool Center = false;
        public string GW = "G.W.:";
        public string NW = "N.W.:";
        public string TL = "T:";
        public string version = "";
        public string Port2Name = "";
        public string dir_M1 = "";
        public string dir_reload = "";
        public int sheet_M = 0;
        public List<string> sheet_Data;
        public List<string[]> sheet_label;
        public List<string> sheet_label_diachi;

        public int sheet_T = 0;
        public List<string> sheet_T_Data;
        public List<string[]> sheet_T_label;
        public List<string> sheet_T_label_diachi;
        public int sheettype = 0;

        public int sheet_2 = 0;
        public _data()
        {
            sheet_Data = new List<string>();
            sheet_label = new List<string[]>();
            sheet_label_diachi = new List<string>();
            sheet_T_label = new List<string[]>();
            sheet_T_label_diachi = new List<string>();
        }

    }
}
