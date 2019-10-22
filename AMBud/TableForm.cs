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
    public partial class TableForm : Form
    {

        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public TableForm()
        {
            InitializeComponent();
        }

        private void TableForm_Load(object sender, EventArgs e)
        {

            dataGridView1.AutoSize = true;
            dataGridView1.AutoGenerateColumns = true;
            GetData("select * from Output");
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void budgetDatabaseDataSet1BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            
        }




        private void GetData(String selectCommand)
        {
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=W:\\Desktop\\Budgeting\\BudgetProgram\\AMBud\\AMBud\\BudgetDatabase.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(selectCommand, con);
                DataSet DS = new DataSet();  
                da.Fill(DS, "OutPut");

                con.Close();
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "OutPut";
                

            }
        }
    }
}
