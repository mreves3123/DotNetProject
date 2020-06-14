using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {

        public int Id { get; set; }
        public int Age { get { return (DateTime.Today.Year - Birth.Year); } }
        public string Family { get; set; }
        public string Name { get; set; }

        public DateTime Birth { get; set; }
        public int MobilePhone { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public bool IsLift { get; set; }
        public int Floor { get; set; }
        public int Experience { get; set; }
        public int MaxChild { get; set; }
        public int MinAgeMounth { get; set; }
        public int MaxAgeMounth { get; set; }
        public bool IfHour { get; set; }
        public int Hour { get; set; }
        public int Mounth { get; set; }
        public Day[] DaysWork { get; set; }
        //public bool[] IsWork { get; set; }
        //public Time[] NumWorkHours { get; set; }
        public Eduction eduction { get; set; }
        public string Recommendations { get; set; }
        public string BankAcount { get; set; }
        public bool IfPrepareFood { get; set; }
       public Payment HowToPay { get; set; }

        public override string ToString()
        {
            return  '\n' + "Name: " + Name + " " + Family + '\n' + "Identity number: " + Id + '\n' + "Age: " + Age + '\n' + "Address: " + Address + '\n';
        }
        public Nanny()
        {
            DaysWork = new Day[6] {new Day(), new Day(), new Day(), new Day(), new Day(), new Day() };
        }
        public Nanny(int myId, string myFamily="", string myName="",string myBirth= "01.01.0001", int myMobilePhone=0, int myPhone=0, string myAddress="", bool myIsLift=false, int myFloor=0, int myExperience=0,
                        int myMaxChild=0, int myMinAgeMounth=0, int myMaxAgeMounth=0, bool myIfHour=false, int myHour=0, int myMounth=0, bool[] myIsWork=null, /*Time[] myNumWorkHours=null,*/
                        Eduction myeduction=0, string myRecommendations="", string myBankAcount="", bool myIfPrepareFood=false)
        {
            Id = myId;
            Family = myFamily;
            Name = myName;
            Birth = DateTime.Parse(myBirth);
            MobilePhone = myMobilePhone;
            Phone = myPhone;
            Address = myAddress;
            IsLift = myIsLift;
            Floor = myFloor;
            Experience = myExperience;
            MaxChild = myMaxChild;
            MinAgeMounth = myMinAgeMounth;
            MaxAgeMounth = myMaxAgeMounth;
            IfHour = myIfHour;
            Hour = myHour;
            Mounth = myMounth;
            //IsWork = myIsWork;
            //NumWorkHours = myNumWorkHours;
            eduction = myeduction;
            Recommendations = myRecommendations;
            BankAcount = myBankAcount;
            IfPrepareFood = myIfPrepareFood;



        }

    }
}
