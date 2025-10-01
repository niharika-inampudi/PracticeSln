using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeSln
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadDatafromTxt();
            string connectionString = ConfigurationManager.ConnectionStrings["Practice"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM StudentInfo;";
                using(SqlCommand command = new SqlCommand(query, conn))
                {
                    using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        foreach(DataRow item in dataTable.Rows)
                        {
                            Students stdn = new Students(item[0].ToString(), Convert.ToInt16(item[1]), item[2].ToString(), item[3].ToString(), Convert.ToInt64(item[4]));
                            stdn.StudentDetails();
                        }
                        // 'dataTable' now contains the data from 'YourTableName'
                    }
                }
                conn.Close();

            }
        }

        private static void ReadDatafromTxt()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\StudentDetails.txt";

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                string connectionString = ConfigurationManager.ConnectionStrings["Practice"].ConnectionString;

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach(string line in lines)
                    {
                        if (Isvalid(line) && !String.IsNullOrEmpty(line))
                        {
                            string query = "INSERT INTO StudentInfo (Name, Age,Program,FatherName,Mobile) VALUES (@Name,@Age,@Program, @FatherName,@Mobile)";

                            SqlCommand command = new SqlCommand(query, conn);
                            command.Parameters.AddWithValue("@Name", line.Split(',')[0]);
                            command.Parameters.AddWithValue("@Age", line.Split(',')[1]);
                            command.Parameters.AddWithValue("@Program", line.Split(',')[2]);
                            command.Parameters.AddWithValue("@FatherName", line.Split(',')[3]);
                            command.Parameters.AddWithValue("@Mobile", line.Split(',')[4]);

                            command.ExecuteNonQuery();
                        }

                    }
                    conn.Close();
                }
            }
            catch(IOException e)
            {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
        }

        private static bool Isvalid(string line)
        {
            try
            {
                if (line.Split(',').Length==5)
                {
                    int.TryParse(line.Split(',')[1], out int ageResult);
                    long number;
                    bool isNumerical = long.TryParse(line.Split(',')[4], out number);
                    if ((line.Split(',')[0] is string) && ageResult > 0 && (line.Split(',')[2] is string) &&
                        (line.Split(',')[3] is string) && isNumerical)
                    {
                        return true;
                    }
                }
                

            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
    }
    public class Students
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Program { get; set; }
        public string FatherName { get; set; }
        public long MobileNo { get; set; }
        public Students(string name, int age, string program, string fatherName, long mobileNo)
        {
            Name = name;
            Age = age;
            Program = program;
            FatherName = fatherName;
            MobileNo = mobileNo;
        }

        public void StudentDetails()
        {
            Console.WriteLine($"Name:{Name},Age:{Age}, Program:{Program},FatherName:{FatherName},MobileNo:{MobileNo}");
        }

    }
}



