using System;
using System.Collections.Generic;
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
            string connectionString = "Data Source=SASIDHAR;Initial Catalog=Practice;Integrated Security=True;";

            using(var conn = new SqlConnection(connectionString))
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

            }
            //Students stdns=new Students("Nihith",2,"InterMediate","Sasidhar",7323306686);
            //stdns.StudentDetails();
            //Students stdns1 = new Students("Virat", 3, "InterMediate", "Bala", 7323306686);
            //stdns1.StudentDetails();
            //Students stdns2 = new Students("Chaitra", 5, "KinderGarden", "Bala", 7323306686);
            //stdns2.StudentDetails();
            //Students stdns3 = new Students("Niharika", 6, "1st Grade", "Rama", 7323306686);
            //stdns3.StudentDetails();
        }

        private static void ReadDatafromTxt()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\StudentDetails.txt";

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                string connectionString = "Data Source=SASIDHAR;Initial Catalog=Practice;Integrated Security=True;";

                using(var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach(string line in lines)
                    {

                        String query = "INSERT INTO StudentInfo (Name, Age,Program,FatherName,Mobile) VALUES (@Name,@Age,@Program, @FatherName,@Mobile)";

                        SqlCommand command = new SqlCommand(query, conn);
                        command.Parameters.Add("@Name", line.Split(',')[0]);
                        command.Parameters.Add("@Age", line.Split(',')[1]);
                        command.Parameters.Add("@Program", line.Split(',')[2]);
                        command.Parameters.Add("@FatherName", line.Split(',')[3]);
                        command.Parameters.Add("@Mobile", line.Split(',')[4]);
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
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



