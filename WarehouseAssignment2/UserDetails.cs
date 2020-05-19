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
    public partial class UserDetails : Form
    {
        public UserDetails()
        {
            InitializeComponent();
        }

        private void UserDetails_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from UserDetails WHERE Email = @email", con);
            cmd.Parameters.AddWithValue("@email", Myglob.email);
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                label9.Text = rd["Name"].ToString();
                label7.Text = rd["Email"].ToString();
                label8.Text = rd["Password"].ToString();
                label12.Text = rd["Number"].ToString();
                label10.Text = rd["City"].ToString();
                label11.Text = rd["Gander"].ToString();


            }
           
        }
    }
}
