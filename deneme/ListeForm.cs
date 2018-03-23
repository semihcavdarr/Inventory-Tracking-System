using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace deneme
{

    public partial class ListeForm : Form
    {
        DataTable datatable = null;
        public static String logical_ref = "0";//Sql tablodaki Referans kodu
        public static byte process_type = 0;//FLAG
        public ListeForm()
        {
            InitializeComponent();
        }
        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                process_type = 1;//process_type = 1 ekle işlemi için bir flag'tir.
                MalzemeForm form_add = new MalzemeForm();
                form_add.ShowDialog();//pencereyi aç
                List();//datagridview'i güncelle
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "Hata");
            }
        }
        private void InitializeData()
        {
            datatable = new DataTable();//Datatable referansı oluştur.
            /*Datatable'a gerekli parametreleri ekle*/
            datatable.Columns.Add("CHECK_", typeof(Int32));
            datatable.Columns.Add("LOGICALREF", typeof(Int32));
            datatable.Columns.Add("CODE", typeof(string));
            datatable.Columns.Add("NAME", typeof(string));
            datatable.Columns.Add("UNITCODE", typeof(string));
            datatable.Columns.Add("VAT", typeof(double));
            datatable.Columns.Add("PURCHASE_PRICE", typeof(double));
            datatable.Columns.Add("SALES_PRICE", typeof(double));
        }
        private void InitializeGrid()
        {
            grid.ReadOnly = true;//Sadece okunabilir

            /*Datagridview'in column'larının ayarlanması*/
            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();
            colCheck.Width = 25;
            colCheck.FalseValue = 0;
            colCheck.TrueValue = 1;
            colCheck.DataPropertyName = "CHECK_";
            colCheck.HeaderText = "...";
            colCheck.ReadOnly = false;
            grid.Columns.Add(colCheck);

            DataGridViewTextBoxColumn colLogicalref = new DataGridViewTextBoxColumn();
            colLogicalref.Width = 100;
            colLogicalref.DataPropertyName = "LOGICALREF";
            colLogicalref.HeaderText = "Referans";
            colLogicalref.ReadOnly = true;
            grid.Columns.Add(colLogicalref);

            DataGridViewTextBoxColumn colCode = new DataGridViewTextBoxColumn();
            colCode.Width = 100;
            colCode.DataPropertyName = "CODE";
            colCode.HeaderText = "Malzeme Kodu";
            colCode.ReadOnly = true;
            grid.Columns.Add(colCode);

            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.Width = 150;
            colName.DataPropertyName = "NAME";
            colName.HeaderText = "Malzeme Adı";
            colName.ReadOnly = true;
            grid.Columns.Add(colName);

            DataGridViewTextBoxColumn colUnitCode = new DataGridViewTextBoxColumn();
            colUnitCode.Width = 50;
            colUnitCode.DataPropertyName = "UNITCODE";
            colUnitCode.HeaderText = "Birim Seti";
            colUnitCode.ReadOnly = true;
            grid.Columns.Add(colUnitCode);

            DataGridViewTextBoxColumn colVat = new DataGridViewTextBoxColumn();
            colVat.Width = 50;
            colVat.DataPropertyName = "VAT";
            colVat.HeaderText = "KDV Oranı";
            colVat.ReadOnly = true;
            grid.Columns.Add(colVat);

            DataGridViewTextBoxColumn colPurchPrice = new DataGridViewTextBoxColumn();
            colPurchPrice.Width = 100;
            colPurchPrice.DataPropertyName = "PURCHASE_PRICE";
            colPurchPrice.HeaderText = "Satınalma Fiyatı";
            colPurchPrice.ReadOnly = true;
            grid.Columns.Add(colPurchPrice);

            DataGridViewTextBoxColumn colSalesPrice = new DataGridViewTextBoxColumn();
            colSalesPrice.Width = 100;
            colSalesPrice.DataPropertyName = "SALES_PRICE";
            colSalesPrice.HeaderText = "Satış Fiyatı";
            colSalesPrice.ReadOnly = true;
            grid.Columns.Add(colSalesPrice);
        }
        private void List()
        {

            /*Her işlemden sonra datagridview'i tek tek güncellemek yerine bunu bir method haline getirdim ve 
             her işlem bittiğinde bu methodu çağırdım böylece datagridview güncellenmiş oldu.
             Kullanıcı her işlemden sonra Sql'deki yeni tabloyu görebilir.*/
            SqlConnection connection = null;
            SqlCommand command = null;
            StringBuilder cmdText = null;

            try
            {
                connection = new SqlConnection(Global.connectionString);
                connection.Open();
                command = connection.CreateCommand();

                datatable.Clear();

                cmdText = new StringBuilder();
                cmdText.Append("SELECT 0 CHECK_,I.* FROM ITEMS I ");
                command.CommandText = cmdText.ToString();
                datatable.Load(command.ExecuteReader());
                datatable.AcceptChanges();
                grid.DataSource = null;
                grid.DataSource = datatable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                return;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        public void ListeForm_Load(object sender, EventArgs e)
        {
            /*Form her açıldığında bu metodlar gerçekleşir*/
            InitializeData();
            InitializeGrid();
            List();
            

        }
        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grid.SelectedRows)
                {
                    logical_ref = Convert.ToString(row.Cells[1].Value);//cast işlemi

                    if (logical_ref != "0")//LOGICALREF 0'dan farklı ise değiştir işlemi için gerekli pencere açılır
                    {
                        process_type = 0;//process_type = 0 değiştir işlemi için bir flag'tir.
                        MalzemeForm form = new MalzemeForm();
                        form.ShowDialog();//pencereyi aç
                        List();//datagridview'i güncelle
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                return;
            }

        }
        private void delete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Global.connectionString);//bağlantı oluştur

            try
            {

                DialogResult dialogResult = MessageBox.Show("Silmek istediğinizden emin misiniz ?", "Malzeme Sil", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    List<string> selectedItem = new List<string>();
                    DataGridViewRow drow = new DataGridViewRow();
                    for (int i = 0; i <= grid.Rows.Count - 1; i++)
                    {
                        drow = grid.Rows[i];
                        if (Convert.ToBoolean(drow.Cells[0].Value) == true) //checkbox seçiliyse 
                        {
                            string id = drow.Cells[1].Value.ToString();
                            selectedItem.Add(id); //seçiliyse listeye ekle
                        }
                    }
                    if (selectedItem.Count == 0)//Eğer tablodan bir veri seçilmediyse
                    {
                        MessageBox.Show("Tablodan veri seçemeden seçme işlemi gerçekleştirilemez !");
                    }
                    else
                    {
                        connection.Open();//bağlantıyı aç
                        foreach (string s in selectedItem) //çoklu silme işlemi gerçekleşiyor
                        {
                            SqlCommand cmd = new SqlCommand("delete from ITEMS where LOGICALREF='" + s + "'", connection);
                            cmd.ExecuteNonQuery();
                        }
                        
                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                return;
            }
            
            finally
            {
                if (connection != null)
                {
                    connection.Close();//balantıyı kapat
                }
                List();
            }

        }
        private void ListeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logical_ref = "0";
            Application.Exit();
        }
        private void grid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            grid.CurrentCell.Value = true;//checkbox'a tik koy
        }
        private void grid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            grid.CurrentCell.Value = false;//checkbox'tan tiki kaldır
        }
        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchBox.Text))//textbox metni null yada boşsa
            {
                (grid.DataSource as DataTable).DefaultView.RowFilter = string.Empty;//datagrid'in rowlarını boşalt
            }
            else//değilse
            {
                (grid.DataSource as DataTable).DefaultView.RowFilter = string.Format("CODE='{0}'", searchBox.Text);//bulduğunu yaz
            }
        }
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            (grid.DataSource as DataTable).DefaultView.RowFilter = string.Format("CODE LIKE '{0}%'", searchBox.Text);//Search işlemi
        }
        private void excel_aktar_Click(object sender, EventArgs e)
        {

            /*http://www.c-sharpcorner.com/UploadFile/c5c6e2/export-datagridview-data-to-excel-in-C-Sharp-without-saving-to-fi/ 
             Excel'e aktarma kodu bu siteden alınmıştır.*/
            if (grid.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < grid.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = grid.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    for (int j = 0; j < grid.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = grid.Rows[i].Cells[j].Value.ToString();
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }
        }
    }
}
