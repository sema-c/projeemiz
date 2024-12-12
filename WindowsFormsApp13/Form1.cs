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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server = localHost; port = 5432; Database = proje; user ID = postegres; password = ssema.7.");
        private void Form1_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
            {
                MessageBox.Show("Lutfen bos alanları doldurun");
            }

            else
            {
                baglanti.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from kullanici where kullaniciAdi = @P1 AND sifre = @P2", baglanti);
                cmd.Parameters.AddWithValue("@P1", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@P2", guna2TextBox2.Text);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Hatali bilgi girisi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }


            }

            }
        
            private void guna2TextBox2_TextChanged(object sender, EventArgs e)
            {
                guna2TextBox2.UseSystemPasswordChar = true;

            }

            private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
            {

            }
        }
    }

