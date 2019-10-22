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

namespace AMBud
{
    public partial class EnterForm : Form
    {
        public EnterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(DescriptionTextBox.Text))
            {
                textBox1.Text = "Description must not be null";
                return ;
            }
            if (String.IsNullOrEmpty(CategoryTextBox.Text))
            {
                textBox1.Text = "Please select the closest category";
                return;
            }

          

            Transaction TR = new Transaction(monthCalendar1.SelectionStart.ToString("yyyyMMdd"),  DescriptionTextBox.Text, AmountBox.Value.ToString(), CategoryTextBox.SelectedValue.ToString());
            TR.PrintToFile();

            textBox1.Text = "Transaction written to file";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CategoryTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EnterForm_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            using (SqlConnection Conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=W:\\Desktop\\Budgeting\\BudgetProgram\\AMBud\\AMBud\\BudgetDatabase.mdf;Integrated Security=True"))
            {
                Conn.Open();
                SqlCommand sc = new SqlCommand("select * from Category", Conn);
                SqlDataReader reader;

                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("Title", typeof(string));
                dt.Load(reader);

                CategoryTextBox.ValueMember = "Id";
                CategoryTextBox.DisplayMember = "Title";
                CategoryTextBox.DataSource = dt;



            }
        }
    }
}
