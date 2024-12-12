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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglan = new NpgsqlConnection("server = localHost; port = 5432; Database = proje; user Id = Postegres; password = 11");
        private void Form8_Load(object sender, EventArgs e)
        {
            uzmanliste();
            hizmetliste();
        }
        void uzmanliste()
        {

            string sorgu = "select * from uzman";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        void hizmetliste()
        {
            string sorgu = "select * from hizmet";
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(sorgu, baglan);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            guna2DataGridView1.DataSource = ds1.Tables[0];
        }
    }
}
