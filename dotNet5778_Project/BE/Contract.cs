using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        readonly int numContract;
        public int NumContract { get; set; }
        public int IdNanny { get; set; }
        public int IdChild { get; set; }
        public bool Meeting { get; set; }
        public bool Singning { get; set; }
        public int SalaryPerHour { get; set; }
        public double MounthSalary { get; set; }
        public bool AccordingMounth { get; set; }
        public bool AccordingHour { get; set; }
        public int NumHoursInWeek { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime DateOfSigning { get; set; }
        public DateTime EndDate { get; set; }
        public double Distance { get; set; }
        public bool IsIncludeFood { get; set; }
        public Payment HowToPay { get; set; }

        public override string ToString()
        {
            return  '\n' + "Number Of Contract: " + NumContract + '\n' + "Identity number of the Nanny: " + IdNanny + '\n' + "The identity number of the child: " + IdChild +
                '\n' + "The start date of the contract is: " + StartingDate.Day + "." + StartingDate.Month + "." + StartingDate.Year + '\n' + "The end date of the contract is: " + EndDate.Day + "." + EndDate.Month + "." + EndDate.Year +
                '\n';
        }

        static int code = 10000000;
        public Contract(/*int myIdNanny, int myIdChild, string myStartingDate = "01.01.0001", string myEndDate = "01.01.0001", string myDateOfSigning = "01.01.0001", bool myMeeting = false, bool mySingning = false, int mySalaryPerHour = 26, double myMounthSalary = 0, bool myAccordingMounth = false,
                        bool myAccordingHour = false, int myNumHoursInWeek = 1, bool myIsIncludeFood = false*/)
        {
            numContract = code;
            code++;
            //IdNanny = myIdNanny;
            //IdChild = myIdChild;
            //Meeting = myMeeting;
            //Singning = mySingning;
            //SalaryPerHour = mySalaryPerHour;
            //MounthSalary = myMounthSalary;
            //AccordingMounth = myAccordingMounth;
            //AccordingHour = myAccordingHour;
            //NumHoursInWeek = myNumHoursInWeek;
            // StartingDate = DateTime.Parse(myStartingDate);
            //EndDate = DateTime.Parse(myEndDate);
            //DateOfSigning = DateTime.Parse(myDateOfSigning);
            //IsIncludeFood = myIsIncludeFood;
        }
    }
}
