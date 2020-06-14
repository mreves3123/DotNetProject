using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using DAL;
using BL;
namespace PL
//{
{
    class Program
    {
        //        static public bool condition(Contract c)
        //        {
        //            return c.Singning && c.Meeting;
        //        }

        static void Main(string[] args)
        {

            BE.Nanny nanny;
            BL.IBL bl;

            nanny = new BE.Nanny();

            bl = BL.FactoryBL.GetBL();

            //    bl.IsHaveFriend(new BE.Child);

            //Time a = new Time();
            //a.StartOcloc = TimeSpan.Parse("08:30");

            //Nanny nanny = new Nanny(1, "", "", "5.4.1998");
            //nanny.eduction = Eduction.EducationOffice;
            //nanny.Address = "Kineret,Haifa,Israel";
            //nanny.Experience = 2;
            //nanny.Family = "winter";
            //nanny.Floor = 3;
            //nanny.Hour = 25;
            //bool[] workDays = new bool[6] { true, false, true, false, true, true };
            //nanny.IsWork = workDays;
            //int[,] workHours = new int[2, 6]
            //{ { 0800, 0900, 0000, 1100, 0000, 0000 },
            //        { 1400,1600,0000,1700,0000,0000}};
            //nanny.NumWorkHours = new Time[6];
            //nanny.IfHour = true;
            //nanny.IsLift = true;
            //nanny.MaxAgeMounth = 6;
            //nanny.MaxChild = 3;
            //nanny.Name = "hana";
            //nanny.Phone = 07653456;
            //nanny.IfPrepareFood = true;


        }
    }
}
//            Child child = new Child(1, Gender.female, DateTime.Parse("28.04.1998"));
//            child.Name = "mayshar";
//            child.IsSpecielNeed = false;
//            child.MotherId = 654321;
//            child.NumSleepHours = 3;

//            Nanny nanny = new Nanny(1, "", "", "5.4.1998");
//            nanny.eduction = Eduction.EducationOffice;
//            nanny.Address = "Kineret,Haifa,Israel";
//            nanny.Experience = 2;
//            nanny.Family = "winter";
//            nanny.Floor = 3;
//            nanny.Hour = 25;
//            bool[] workDays = new bool[6] { true, false, true, false, true, true };
//            nanny.IsWork = workDays;
//            int[,] workHours = new int[2, 6]
//            { { 0800, 0900, 0000, 1100, 0000, 0000 },
//            { 1400,1600,0000,1700,0000,0000}};
//            nanny.NumWorkHours = workHours;
//            nanny.IfHour = true;
//            nanny.IsLift = true;
//            nanny.MaxAgeMounth = 6;
//            nanny.MaxChild = 3;
//            nanny.Name = "hana";
//            nanny.Phone = 07653456;
//            nanny.IfPrepareFood = true;

//            Mother mother = new Mother(654321);
//            mother.Name = "Tova";
//            mother.MobilePhone = 82765354;
//            mother.Note = "I need nanny with responsible";
//            mother.WantedMinAge = 22;
//            mother.WantedMinExperience = 3;
//            mother.Address = "Halisa,Haifa,Israel";
//            mother.AddressAround = "Yosef,Haifa,Israel";
//            bool[] needDays = new bool[6] { true, true, false, true, false, false };
//            mother.IfNeed = needDays;
//            int[,] needHours = new int[2, 6]
//            { {0900, 0900, 0000, 1100, 0000, 0000 },
//            { 1400,1300,0000,1700,0000,0000}};
//            mother.NumNeedHours = needHours;
//            mother.IsBringFood = true;
//            mother.Family = "Yasmin";

//            Mother mother2 = new Mother(65432);
//            mother2.Address = "Halisa,Haifa,Israel";
//            mother2.AddressAround = "Pevzner,Haifa,Israel";
//            Mother mother3 = new Mother(6543);
//            mother3.Address = "Halisa,Haifa,Israel";
//            mother3.AddressAround = "Geula,Haifa,Israel";

//            Contract contarct = new Contract(1, 1, "1.1.2018", "7.10.2018");
//            contarct.AccordingHour = true;
//            contarct.AccordingMounth = false;
//            //contarct.EndDate = "7.10.2018";
//            //contarct.IdChild = 1;
//            //contarct.IdNanny = 1;
//            contarct.Meeting = true;
//            contarct.SalaryPerHour = 23;
//            contarct.Singning = true;
//            contarct.IsIncludeFood = true;
//            //contarct.StartingDate = "1.1.2018";

//            Contract contarct2 = new Contract(2, 2, "1.1.2018", "7.10.2018");
//            contarct2.AccordingHour = true;
//            contarct2.AccordingMounth = false;
//            //contarct2.EndDate = "7.10.2018";
//            //contarct2.IdChild = 2;
//            //contarct2.IdNanny = 2;
//            contarct2.Meeting = true;
//            contarct2.SalaryPerHour = 23;
//            contarct2.IsIncludeFood = true;
//            contarct2.Singning = true;
//            //contarct2.StartingDate = "1.1.2018";

//            Contract contarct3 = new Contract(3, 3, "1.1.2018", "7.10.2018");
//            contarct3.AccordingHour = true;
//            contarct3.AccordingMounth = false;
//            //contarct3.EndDate = "7.10.2018";
//            //contarct3.IdChild = 3;
//            //contarct3.IdNanny = 3;
//            contarct3.Meeting = true;
//            contarct3.SalaryPerHour = 23;
//            contarct3.Singning = true;
//            contarct3.IsIncludeFood = true;
//            //contarct3.StartingDate = "1.1.2018";

//            Contract contarct4 = new Contract(4, 4, "1.1.2018", "7.10.2018");
//            contarct4.AccordingHour = true;
//            contarct4.AccordingMounth = false;
//            //contarct4.EndDate = "7.10.2018";
//            //contarct4.IdChild = 4;
//            //contarct4.IdNanny = 4;
//            contarct4.Meeting = true;
//            contarct4.SalaryPerHour = 23;
//            contarct4.Singning = true;
//            contarct4.IsIncludeFood = true;
//            //contarct4.StartingDate = "1.1.2018";

//            Nanny nanny2 = new Nanny(2, "", "", "26.04.1998");

//            workDays = new bool[6] { false, true, true, false, true, true };
//            nanny2.IsWork = workDays;
//            workHours = new int[2, 6]
//             { { 0800, 0000, 0000, 1100, 0000, 0000 },
//            { 1400,000,0000,1700,0000,0000}};
//            nanny2.NumWorkHours = workHours;
//            // nanny2.Age = 20;
//            nanny2.MaxChild = 2;
//            nanny2.MaxAgeMounth = 3;
//            nanny2.IfPrepareFood = true;
//            nanny2.Address = "Kineret,Haifa,Israel";

//            Nanny nanny3 = new Nanny(3, "", "", "26.04.1995");
//            //nanny3.Age = 20;
//            nanny3.MaxChild = 2;
//            nanny3.MaxAgeMounth = 9;
//            workDays = new bool[6] { false, false, false, false, true, true };
//            nanny3.IsWork = workDays;
//            workHours = new int[2, 6]
//             { { 0800, 0000, 0000, 1100, 0000, 0000 },
//            { 1400,000,0000,1700,0000,0000}};
//            nanny3.IfPrepareFood = true;
//            nanny3.NumWorkHours = workHours;
//            nanny3.Address = "Kineret,Haifa,Israel";

//            Nanny nanny4 = new Nanny(4, "", "", "26.04.1980");
//            // nanny4.Age = 20;
//            nanny4.MaxChild = 2;
//            nanny4.MaxAgeMounth = 20;
//            workDays = new bool[6] { false, false, true, true, true, true };
//            nanny4.IsWork = workDays;
//            workHours = new int[2, 6]
//             { { 0800, 0000, 0000, 1100, 0000, 0000 },
//            { 1400,000,0000,1700,0000,0000}};
//            nanny4.NumWorkHours = workHours;
//            nanny4.IfPrepareFood = true;
//            nanny4.Address = "Kineret,Haifa,Israel";

//            Nanny nanny5 = new Nanny(5, "", "", "28.04.1998");
//            nanny5.MaxAgeMounth = 22;
//            // nanny5.Age = 20;
//            workDays = new bool[6] { true, true, false, true, false, false };
//            nanny5.IsWork = workDays;
//            workHours = new int[2, 6]
//          { {0900, 0900, 0000, 1100, 0000, 0000 },
//            { 1400,1300,0000,1700,0000,0000}};
//            nanny5.NumWorkHours = workHours;
//            nanny5.MaxChild = 2;
//            nanny5.Address = "Kineret,Haifa,Israel";
//            nanny5.IfPrepareFood = true; ;

//            Child child2 = new Child(2, Gender.male, DateTime.Parse("5.9.2016"));
//            child2.MotherId = 65432;
//            Child child3 = new Child(3, Gender.female, DateTime.Parse("2.7.2017"));
//            child3.MotherId = 654321;
//            Child child4 = new Child(4, Gender.female, DateTime.Parse("22.3.2016"));

//            child4.MotherId = 654321;
//            Bl_imp myBl_imp = new Bl_imp();
//            Dal_imp MyDal_imp = new Dal_imp();
//            try
//            {
//                myBl_imp.addMother(mother);
//                myBl_imp.addMother(mother2);
//                myBl_imp.addMother(mother3);
//                myBl_imp.addChild(child);
//                myBl_imp.addChild(child2);
//                myBl_imp.addChild(child3);
//                myBl_imp.addChild(child4);
//                myBl_imp.addNanny(nanny);
//                myBl_imp.addNanny(nanny2);
//                myBl_imp.addNanny(nanny3);
//                myBl_imp.addNanny(nanny4);
//                myBl_imp.addNanny(nanny5);
//                myBl_imp.addContract(contarct);
//                myBl_imp.addContract(contarct2);
//                myBl_imp.addContract(contarct3);
//                myBl_imp.addContract(contarct4);

//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }

//            var v = myBl_imp.NanAcordChildAge(true, true);


//            foreach (var item in v)
//            {
//                Console.WriteLine("{0}-{1} : \n", item.Key * 3, (item.Key + 1) * 3);
//                foreach (var n in item)
//                {
//                    Console.Write("{0}, ", n);
//                    Console.WriteLine("\n");
//                }
//            }

//            var r = myBl_imp.MomAcordNumChild();
//            foreach (var item in r)
//            {
//                Console.WriteLine("{0}: \n", item.Key);
//                foreach (var n in item)
//                {
//                    Console.Write("{0}, ", n);
//                    Console.WriteLine("\n");
//                }
//            }

//            var v1 = myBl_imp.ContractAcordDistance(true);
//            foreach (var item in v1)
//            {
//                Console.WriteLine("{0}-{1} : \n", item.Key * 5, (item.Key + 1) * 5);
//                foreach (var n in item)
//                {
//                    Console.Write("{0}, ", n);
//                    Console.WriteLine("\n");
//                }
//            }

//            MyDal_imp.Children();

//            Bl_imp.someDelegate myDelegat = new Bl_imp.someDelegate(condition);
//            List<Contract> myConntract = myBl_imp.AllContract(myDelegat);
//            int a = myBl_imp.NumContract(myDelegat);
//            Console.WriteLine(a);
//            foreach (Contract item in myConntract)
//            {
//                Console.WriteLine(item);
//            }

//            Console.ReadKey();
//        }
//    }
//}
