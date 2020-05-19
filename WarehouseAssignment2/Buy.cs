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
    public partial class Buy : Form
    {
        public Buy()
        {
            InitializeComponent();
        }
        
        private void Buy_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlDataAdapter cmd = new SqlDataAdapter("Select * from Item", con);

            cmd.Fill(database1DataSet4.Item);
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox4.Text = "1";
            textBox1.Text = "1";

        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Item Where Name = @name ", con);
            if(comboBox1.SelectedValue!=null)
            {
                cmd.Parameters.AddWithValue("@name", comboBox1.SelectedValue.ToString());
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    textBox5.Text = rd["Category"].ToString();
                    textBox1.Text = rd["Price"].ToString();
                    textBox2.Text = rd["Available"].ToString();
                }
            }
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4 == null && textBox1 == null)
            {
                textBox4.Text = "1";
                textBox1.Text = "1";
            }
            else
            {
                int x = Convert.ToInt32(textBox1.Text);
                int y = Convert.ToInt32(textBox4.Text);
                int z = x * y;
                textBox3.Text = z.ToString();
            }
            string money ="Total Money" +""+ textBox3.Text.ToString();
           DialogResult d = MessageBox.Show(money, "Confirm", MessageBoxButtons.YesNo);
            if(d == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
                con.Open();

                SqlCommand cmd1 = new SqlCommand("insert into [Order] (ItemName,Quantity,Price,TotalPrice,Email) VALUES (@name,@quantity,@price,@totalprice,@email)", con);

                cmd1.Parameters.AddWithValue("@name", comboBox1.SelectedValue.ToString());
                cmd1.Parameters.AddWithValue("@quantity", textBox4.Text);
                cmd1.Parameters.AddWithValue("@price", textBox1.Text);
                cmd1.Parameters.AddWithValue("@totalprice", textBox3.Text);
                cmd1.Parameters.AddWithValue("@email", Myglob.email);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Congratulation");
            }
            

        }

       

       

       

        private void Buy_Click(object sender, EventArgs e)
        {
            if (textBox4 == null && textBox1 == null)
            {
                textBox4.Text = "1";
                textBox1.Text = "1";
            }

            else
            {
                int x = Convert.ToInt32(textBox1.Text);
                int y = Convert.ToInt32(textBox4.Text);
                int z = x * y;
                textBox3.Text = z.ToString();
            }
        }

       

       
    }
}
