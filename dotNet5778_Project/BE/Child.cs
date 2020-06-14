using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
         
        public int Id { get; set; }
        public Gender ChildGender { get; set; }
        public int MotherId { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public int AgeMounth { get { return ((DateTime.Today.Year - Birth.Year) * 12 + DateTime.Today.Month - Birth.Month); } }
        public int AgeYear { get { return AgeMounth/12; } }
        public bool IsSpecielNeed { get; set; }
        public string SpecielNeed { get; set; }
        public int NumSleepHours { get; set; }
        public bool IsDiaper { get; set; }
        public TimeSpan TheLastReplaceDiaper { get; set; }

        public string Elergy { get; set; }
        public string LikedFood { get; set; }
        public string Plays { get; set; }
        public bool KnowToWalk { get; set; }
        public bool pacifier { get; set; }
        public override string ToString()
        {
            return  '\n' + "Name: " + Name
              + '\n' + "Identity number: " + Id + '\n' + "Date of birthday: " + Birth.Day+"."+Birth.Month+"."+Birth.Year + '\t'+'\n';
        }

        public Child(int myId=0,Gender myGender=0,/*DateTime myBirth= DateTime.Today.Date,*/ int myMotherId=0,String MyName=null,bool myIsSpecielNeed=false, string mySpecielNeed= "",int myNumSleepHours =0,bool myIsDiaper = false)
        {
            Id = myId;
            ChildGender = myGender;
           // birth = myBirth;
            MotherId = myMotherId;
            Name = MyName;
            IsSpecielNeed = myIsSpecielNeed;
           SpecielNeed = mySpecielNeed;
            NumSleepHours = myNumSleepHours;
            IsDiaper = myIsDiaper;
        }
        
    }
}
