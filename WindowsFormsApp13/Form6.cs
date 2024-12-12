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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglan = new NpgsqlConnection("server = localHost; port = 5432; Database = proje; user Id = Postegres; password = 11");

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into musteri (musteriAd, musteriSoyad, yas, telefon, mail) values (@p1,@p2,@p3,@p4,@p5)", baglan);
            komut.Parameters.AddWithValue("@p1", textad.Text);
            komut.Parameters.AddWithValue("@p2", textsoyad.Text);
            komut.Parameters.AddWithValue("@p3", textyaş.Text);
            komut.Parameters.AddWithValue("@P4", texttel.Text);
            komut.Parameters.AddWithValue("@P5",textmail.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Kişi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
