using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace deneme
{
    public partial class SifreForm : Form
    {
        public SifreForm()
        {
            InitializeComponent();
        }
        private void find_pass_Click(object sender, EventArgs e)
        {
            SqlConnection temp_connect = new SqlConnection(Global.connectionString);//bağlantı oluştur
            temp_connect.Open();//bağlantıyı aç
            SqlCommand tmp_com = new SqlCommand("select PASSWORD from PASSWORDS where username =" + "'" + textBox1.Text + "'", temp_connect);
            //ilgili username tabloda var mı sorgusu
            tmp_com.ExecuteNonQuery();//execute et
            SqlDataReader reader = tmp_com.ExecuteReader();
            if (reader.Read())//reader.Read() true ise sorgu vardır ve şifre textBox'a yazılır
                textBox2.Text = reader["PASSWORD"].ToString();
            else//yoksa hata verilir
                MessageBox.Show("Bu programa kayıtlı değilsiniz");
            reader.Close();//reader kapat   
            temp_connect.Close();//connection kapat
        }
    }
}
