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
    public partial class MalzemeForm : Form
    {
        public MalzemeForm()
        {
            InitializeComponent();
        }
        SqlConnection temp_connect = new SqlConnection(Global.connectionString);//bağlantı oluştur
        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                temp_connect.Open();
                if (ListeForm.process_type == 0)//değiştir ise
                {
                    string select_query = " SELECT * FROM ITEMS WHERE LOGICALREF <> " + ListeForm.logical_ref + " AND CODE ='" + MK.Text + "'";//sorguyu hazırla
                    SqlCommand temp = new SqlCommand(select_query, temp_connect);
                    temp.ExecuteNonQuery();//execute et
                    using (SqlDataReader reader = temp.ExecuteReader())
                    {

                        if (reader.Read())//true ise
                        {
                            MessageBox.Show("Bu koda sahip malzeme kartı zaten kullanımda !");

                            temp_connect.Close();

                        }

                        else//bu kod kullanımda değilse
                        {
                            reader.Close();
                            //Update sorgusu
                            string query = "update ITEMS SET CODE = " + "'" + MK.Text + "'" + ", NAME = @name, VAT = @vat, UNITCODE = @unıtcode, " +
                                        "PURCHASE_PRICE = @purchase_price, SALES_PRICE =@sales_price  WHERE  LOGICALREF =@logicalref";
                            //komut oluştur
                            SqlCommand tmp_com = new SqlCommand(query, temp_connect);
                            /*Parametreleri ekle*/
                            tmp_com.Parameters.AddWithValue("@logicalref", ListeForm.logical_ref);                           
                            tmp_com.Parameters.AddWithValue("@code", MK.Text);
                            tmp_com.Parameters.AddWithValue("@name", MA.Text);
                            tmp_com.Parameters.AddWithValue("@vat", Convert.ToDouble(KDV.Text));
                            tmp_com.Parameters.AddWithValue("@unıtcode", BS.Text);
                            tmp_com.Parameters.AddWithValue("@purchase_price", Convert.ToDouble(SAT.Text));
                            tmp_com.Parameters.AddWithValue("@sales_price", Convert.ToDouble(SAF.Text));
                            tmp_com.ExecuteNonQuery();//execute et

                            MessageBox.Show("Güncelleme Başarılı !");

                            this.Hide();

                        }

                    }

                }
                else if (ListeForm.process_type == 1)//Ekle işlemi ise
                {
                    string select_query2 = "SELECT * FROM ITEMS WHERE CODE =" + "'" + MK.Text + "'";//Sorgu
                    SqlCommand tmp_com = new SqlCommand(select_query2, temp_connect);
                    tmp_com.ExecuteNonQuery();//execute et
                    using (SqlDataReader reader = tmp_com.ExecuteReader())
                    {

                        if (reader.Read())//true ise
                        {
                            MessageBox.Show("Bu kod kullanımda !");

                        }
                        else//Böyle bir kod yoksa
                        {
                            reader.Close();
                            //Sorguyu oluştur
                            string insert = "INSERT INTO  ITEMS (CODE, NAME, UNITCODE, VAT, PURCHASE_PRICE, SALES_PRICE) VALUES(@code,@name,@unitcode,@vat,@purchase_price,@sales_price)";
                            //komut oluştur
                            tmp_com = new SqlCommand(insert, temp_connect);
                            /*Parametreleri ekle*/
                            tmp_com.Parameters.AddWithValue("@code", MK.Text);
                            tmp_com.Parameters.AddWithValue("@name", MA.Text);
                            tmp_com.Parameters.AddWithValue("@vat", (KDV.Text));
                            tmp_com.Parameters.AddWithValue("@unitcode", BS.Text);
                            tmp_com.Parameters.AddWithValue("@purchase_price", (SAT.Text));
                            tmp_com.Parameters.AddWithValue("@sales_price", (SAF.Text));

                            tmp_com.ExecuteNonQuery();//execute et

                            MessageBox.Show("Kayıt İşlemi Başarıyla Tamamlanmıştır.");
                            this.Hide();
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "HATA");
            }
            finally
            {
                if (temp_connect != null)
                    temp_connect.Close();
            }
        }
        private void MalzemeForm_Shown(object sender, EventArgs e)
        {
            try
            {
                temp_connect.Open();
                if (ListeForm.process_type == 0)//Case değiştir ise 
                {   
                    //Komut oluştur
                    SqlCommand tmp_com = new SqlCommand("select  CODE,NAME,UNITCODE,VAT,PURCHASE_PRICE,SALES_PRICE from ITEMS where LOGICALREF =" 
                        + ListeForm.logical_ref, temp_connect);
                    tmp_com.ExecuteNonQuery();//execute et
                    using (SqlDataReader reader = tmp_com.ExecuteReader())
                    {

                        if (reader.Read())//true ise
                        {
                            MK.Text = reader["CODE"].ToString();
                            MA.Text = reader["NAME"].ToString();
                            BS.Text = reader["UNITCODE"].ToString();
                            KDV.Text = reader["VAT"].ToString();
                            SAT.Text = reader["PURCHASE_PRICE"].ToString();
                            SAF.Text = reader["SALES_PRICE"].ToString();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "HATA");
            }
            finally
            {
                if (temp_connect != null)
                    temp_connect.Close();
            }
            

        }
        private void cancel_Click(object sender, EventArgs e)
        {
            
            this.Hide();//formu sakla
        }
    }
}
