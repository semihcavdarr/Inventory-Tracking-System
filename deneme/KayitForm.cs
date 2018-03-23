using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneme
{
    public partial class KayitForm : Form
    {
        public KayitForm()
        {
            InitializeComponent();
        }
        private void save_Click(object sender, EventArgs e)
        {
            SqlConnection temp_connect = null;
            try
            {
                if (txtSifre.Text.ToString() != txtSifreTekrar.Text.ToString())//Girilen şifre ile tekrar girilen şifre aynı mı kontrolü
                {
                    MessageBox.Show("Şifreler uyuşmamaktadır !");
                    return;
                }
                string username = txtKullanici.Text.ToString();//Textbox'tan kullanıcı adını alıp bir değişkene vermek
                string password = txtSifre.Text.ToString();//Textbox'tan şifreyi alıp bir değişkene vermek

                temp_connect = new SqlConnection(Global.connectionString);//bağlantı oluştur.
                temp_connect.Open();//bağlantıyı aç
                SqlCommand temp_com = new SqlCommand("select * from PASSWORDS WHERE USERNAME = " + "'" + username + "'", temp_connect);//Sorguyu oluştur.
                temp_com.ExecuteNonQuery();//Execute et
                using (SqlDataReader reader = temp_com.ExecuteReader())
                {
                    if (reader.Read())//Sql'den veri okunabiliyorsa başka bir kullanıcı adıyla kaydolunması gerekir(Read() methodu boolean döndürür)
                    {
                        MessageBox.Show("Bu kullanıcı adı kullanımda");

                        reader.Close();
                        temp_connect.Close();
                    }
                    else//Sql'den veri okunmamışsa yeni kayıt açılır ve bu kayıt Sql'deki PASSWORDS tablosuna eklenir
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO PASSWORDS(USERNAME,PASSWORD)" + " VALUES('" + username + "' , '" + password + "')", temp_connect);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Kayıt başarılı");
                        temp_connect.Close();
                        this.Hide();//pencereyi sakla
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "HATA");
            }
            finally
            {
                if(temp_connect != null)
                {
                    temp_connect.Close();
                }
            }

            
        }
    }
}
