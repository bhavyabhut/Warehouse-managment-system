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
    public partial class DisplayItem : Form
    {
        public DisplayItem()
        {
            InitializeComponent();
        }

        private void DisplayItem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet2.Item' table. You can move, or remove it, as needed.
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter("select * from Item",con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = tb;



        }
        Bitmap bit;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int height = dataGridView2.Height;
            dataGridView2.Height = dataGridView2.RowCount * dataGridView2.RowTemplate.Height * 2;
            bit = new Bitmap(dataGridView2.Width, dataGridView2.Height);
            dataGridView2.DrawToBitmap(bit, new Rectangle(0, 0, dataGridView2.Width ,dataGridView2.Height));
            e.Graphics.DrawImage(bit, 0, 0);
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
