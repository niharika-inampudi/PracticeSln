using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeSln
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Students stdns=new Students("Nihith",2,"InterMediate","Sasidhar",7323306686);
            stdns.StudentDetails();
            Students stdns1 = new Students("Virat", 3, "InterMediate", "Bala", 7323306686);
            stdns1.StudentDetails();
            Students stdns2 = new Students("Chaitra", 5c, "KinderGarden", "Bala", 7323306686);
            stdns2.StudentDetails();
            Students stdns3 = new Students("Niha", 6, "1st Grade", "Rama", 7323306686);
            stdns3.StudentDetails();
        }
    }
    public class Students
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Program { get; set; }
        public string FatherName { get; set; }
        public long MobileNo { get; set; }
        public Students(string name,int age,string program,string fatherName,long mobileNo)
        {
            Name = name;
            Age=age;
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



