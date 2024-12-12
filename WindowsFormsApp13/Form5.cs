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
using Npgsql;

namespace WindowsFormsApp13
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server = localHost; port = 5432; Database = proje; user Id = Postegres; password = 11");

        void hizmetliste()
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("Select * From hizmet", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Cmbhizmet.ValueMember = "alanID";
            Cmbhizmet.DisplayMember = "alanAdi";
            Cmbhizmet.DataSource = dt;
        }
        void musteriliste()
        {
            baglanti.Open();
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter("Select * From musteri", baglanti);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            cmbmusteri.ValueMember = "musteriID";
            cmbmusteri.DisplayMember = "musteriID";
            cmbmusteri.DataSource = dt3;
            baglanti.Close();

        }
        void randevuliste() {
            NpgsqlDataAdapter da4 = new NpgsqlDataAdapter("execute Bilgi", baglanti);
            DataSet ds = new DataSet();
            da4.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }



        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Cmbuzman_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void Form5_Load_1(object sender, EventArgs e)
        {
            hizmetliste();
            musteriliste();
            randevuliste();

        }

        private void Cmbhizmet_SelectedIndexChanged(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("Select uzmanID, (uzmanAd + ' ' + uzmanSoyad) AS 'isim' from uzman where alanID=" + Cmbhizmet.SelectedValue, baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            Cmbuzman.ValueMember = "uzmanID";
            Cmbuzman.DisplayMember = "isim";
            Cmbuzman.DataSource = dt2;
        }

        private void cmbmusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into randevu (alanID, uzmanID, musteriID, tarih, saat) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", Cmbhizmet.SelectedValue);
            komut.Parameters.AddWithValue("@p2", Cmbuzman.SelectedValue);
            komut.Parameters.AddWithValue("@p3", cmbmusteri.SelectedValue);
            komut.Parameters.AddWithValue("@P4", maskedTarih.Text);
            komut.Parameters.AddWithValue("@P5", maskedSaat.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Randevu Olusturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
