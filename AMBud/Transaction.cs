using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace AMBud
{
    class Transaction
    {
        //Transactoion class
        string date;
        string description;
        int category;
        decimal amount;

        public Transaction(string da, string de, string am, string ca)
        {
            date = da;
            description = de;
            category = int.Parse(ca);
            amount = decimal.Parse(am);
        }

        public string Print()
        {
            string line = date + ',' + amount + ',' + description + ',' + category;
           
                return line + '\n';
        }

        public void PrintToFile()
        {
            using (SqlConnection Conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=W:\\Desktop\\Budgeting\\BudgetProgram\\AMBud\\AMBud\\BudgetDatabase.mdf;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Transaction] (Date, Description, Amount, Category_Id) VALUES (@Date, @Description, @Amount, @Category_Id)", Conn);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@Category_ID", category);

                Conn.Open();
                command.ExecuteNonQuery();




            }


            /*string path = System.IO.Path.Combine("..\\..\\..\\..\\Data", year );
            System.IO.Directory.CreateDirectory(path);

            path = System.IO.Path.Combine(path, month + ".csv");

            
                using (StreamWriter file = new StreamWriter(path, true))
                {
                    file.Write(this.Print());
                }
                */
        }
    }
}
