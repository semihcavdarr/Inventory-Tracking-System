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
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
        }
        private void enter_Click(object sender, EventArgs e)//Giriş butonu
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            StringBuilder cmdText = null;

            try
            {
                connection = new SqlConnection(Global.connectionString);//bağlantıyı oluştur
                connection.Open();//bağlantıyı aç
                command = connection.CreateCommand();//bu bağlantıyla komut oluştur.

                cmdText = new StringBuilder();
                cmdText.Append("SELECT COUNT(*) FROM PASSWORDS ");//StringBuilder'a bu string'i ekle
                cmdText.Append("WHERE USERNAME=@USERNAME AND PASSWORD=@PASSWORD ");//StringBuilder'a bu string'i ekle
                command.CommandText = cmdText.ToString();
                command.Parameters.Clear();//parametreleri temizle
                command.Parameters.AddWithValue("USERNAME", txtKullanici.Text);//parametre ekle
                command.Parameters.AddWithValue("PASSWORD", txtSifre.Text);//parametre ekle
                object value = command.ExecuteScalar();//execute et return değerini bir objeye ata

                if (value != null && value != DBNull.Value)//Null kontrolü
                {
                    if (Convert.ToInt16(value) > 0)//Cast to int
                    {
                        ListeForm form_enter = new ListeForm();
                        form_enter.Show();//formu aç
                        this.Hide();//eski formu gizle
                    }
                    else
                    {
                        throw new Exception("Girdiğiniz kullaniciadi veya şifre geçerli değildir.!");
                    }
                }
                else
                {
                    throw new Exception("Girdiğiniz kullaniciadi veya şifre geçerli değildir.!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                return;
            }
            finally
            {
                if (connection!=null)//connection nulldan farklıysa yani açıksa kapat
                {
                    connection.Close();
                }
            }
        }
        private void exit_Click(object sender, EventArgs e)//Çıkış butonu
        {
            Application.Exit();
        }
        private void remember_Click(object sender, EventArgs e)//Şifremi unuttum butonu
        {

            SifreForm remember_password = new SifreForm();
            remember_password.Show();
        }
        private void record_Click(object sender, EventArgs e)//Kaydol butonu
        {
            KayitForm register = new KayitForm();
            register.Show();
        }
    }
}
