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
using System.Data.SqlClient;
using Npgsql;

namespace WindowsFormsApp13
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
         
        }

        NpgsqlConnection baglan = new NpgsqlConnection("server = localHost; port = 5432; Database = proje; user Id = Postegres; password = 11");
        private void Form7_Load(object sender, EventArgs e)
        {
            musteriliste();
        }
        void musteriliste()
        {
            string sorgu = "select * from musteri";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
