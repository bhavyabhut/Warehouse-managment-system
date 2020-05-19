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

namespace WarehouseAssignment2
{
    public partial class UpdateProduct : Form
    {
        public UpdateProduct()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cmd;
        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
            con.Open();
            da = new SqlDataAdapter("select * from Item", con);

            ds = new System.Data.DataSet();
            da.Fill(ds, "Item");
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommandBuilder(da);
            da.Update(ds, "Item");
            MessageBox.Show("Update Successfull");
            
        }
    }
}
