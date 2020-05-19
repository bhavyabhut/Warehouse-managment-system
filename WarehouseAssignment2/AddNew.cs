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
    public partial class AddNew : Form
    {
        public AddNew()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Item (Name,Category,Available,Company,Price,Manufacture_Date) VALUES (@Name,@Category,@Available,@Company,@Price,@Manufacture_Date)", con);
            cmd.Parameters.AddWithValue("@Name",textBox1.Text);
            cmd.Parameters.AddWithValue("@Category", comboBox1.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@Available", textBox2.Text);
            textBox1.Text = comboBox1.SelectedValue.ToString();
            cmd.Parameters.AddWithValue("@Company", textBox4.Text);
            cmd.Parameters.AddWithValue("@Price", textBox3.Text);
            cmd.Parameters.AddWithValue("@Manufacture_Date", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfull Add New Item");
        }

       

       

        private void zzz(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlDataAdapter sp = new SqlDataAdapter("Select * from Category", con);
            sp.Fill(database1DataSet5.Category);
        }

        private void AddNew_Load(object sender, EventArgs e)
        {
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
