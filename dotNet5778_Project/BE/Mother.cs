using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        
        public int Id { get; set; }
        public string Family { get; set; }
        public string Name { get; set; }
        public int MobilePhone { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string AddressAround { get; set; }
      public Day[] DaysNeed { get; set; }
        public int WantedMinAge { get; set; }
        public int WantedMinExperience { get; set; }
        public bool IsBringFood { get; set; }
        public string Note { get; set; }
        public int CountOfChildInNanny { get; set; }
        public override string ToString()
        {
            return '\n' + "Name: " + Name + " " + Family + '\n' + "Identity number: " + Id + '\n' + "Number of phone: "+ MobilePhone+ '\n'+"Address: "+ Address+'\n';
        }
        public Mother()
        {
            DaysNeed = new Day[6] { new Day(), new Day(), new Day(), new Day(), new Day(), new Day() };
    }
        public Mother(int myId, string myFamily = "", string myName = "", int myMobilePhone = 0, int myPhone = 0, string myAddress = "", string myAddressAround = ""/*, bool[] myIfNeed=null, Time[] myNumNeedHours=null*/,
           int myWantedMinAge=18,int myWantedMinExperience=0, bool myIsBringFood=false, string myNote="", int myCountOfChildInNanny=0)
        {
            Id = myId;
            Family= myFamily;
            Name = myName;
            MobilePhone = myMobilePhone;
            Phone = myPhone;
            Address = myAddress;
            AddressAround = myAddressAround;
          //  IfNeed = myIfNeed;
          //  NumNeedHours = myNumNeedHours;
            WantedMinAge = myWantedMinAge;
            WantedMinExperience = myWantedMinExperience;
            IsBringFood=myIsBringFood;
            Note = myNote;
            CountOfChildInNanny = myCountOfChildInNanny;

        }
    }
}
