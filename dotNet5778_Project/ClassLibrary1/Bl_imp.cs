using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using DAL;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi;

namespace BL
{
    public class Bl_imp : IBL
    {
        Idal myDal_imp = FactoryDal.GetDal();
        public Bl_imp()
        {
           initList();
        }
        public void addChild(Child newChild)
        {
            if(newChild.Id>(999999999)|| newChild.Id<0)
            { throw new Exception("The identity number is not correct.");  }
            myDal_imp.addChild(newChild);

        }

        public void addContract(Contract newContract)
        {//Check how many contract to the nanny has alraedy.
            if (newContract.IdChild > 99999999 || newContract.IdChild < 0)
                throw new Exception("The identity number of child is not correct.");
            if (newContract.IdNanny > 99999999 || newContract.IdNanny < 0)
                throw new Exception("The identity number of mother is not correct.");
            if (newContract.StartingDate > newContract.EndDate)
                throw new Exception("The end date is before the start day. ");

            Nanny myNanny = new Nanny(newContract.IdNanny);
            var result3 = from item in Nannies()
                          where item.Id == newContract.IdNanny
                          select item;
            //if nnany exist
            if (result3.Count() <= 0)
                throw new Exception("The nanny is not exist ");
            foreach (var item in result3)
            {
                myNanny = item;
            }
            //if child exist
            var result5 = from item in DataSource.children
                          where item.Id == newContract.IdChild
                          select item;
            if (result5.Count() <= 0)
                throw new Exception("The child is not exist ");
            int countOfContracs = 0;
            var result4 = from item in DataSource.contracs
                          where item.IdNanny == newContract.IdNanny
                          select item;
            foreach (var item in result4)
            {
                countOfContracs++;
            }
            if (countOfContracs == myNanny.MaxChild)
            {
                throw new Exception("The nanny can not get more children ");
            }
            int myId;
            Child myChild = null;
            var v = DataSource.children.Where(t => t.Id == newContract.IdChild);
            foreach (var item in v)
            {
                myChild = item;
            }
            if (myChild.AgeMounth < 3)
            {
                throw new Exception("The child is too small.");
            }
            //Check the  match about the food 

            var result6 = from item in DataSource.mothers
                          where item.Id == result5.FirstOrDefault().MotherId
                          select item;
            if (!result6.FirstOrDefault().IsBringFood && !myNanny.IfPrepareFood)
                throw new Exception("The mother no bring food and the nnany can't prepare. ");
            if (!result6.FirstOrDefault().IsBringFood && myNanny.IfPrepareFood)
                newContract.IsIncludeFood = true;
            else
                newContract.IsIncludeFood = false;
            //The salary for the contract
            myId = myChild.MotherId;
            int countOfBrothers = -1;

            var result = from item1 in DataSource.children
                         from item2 in DataSource.contracs
                         where item2.IdNanny == newContract.IdNanny
                         select item1;
            foreach (var item in result)
            {
                countOfBrothers++;
            }
            int salary = 0;
            int numChildOfNan = 0;

            var result2 = from item in DataSource.nannies
                          where newContract.IdNanny == item.Id
                          select item;

            foreach (var item in result2)
            {
                numChildOfNan = item.MaxChild;
                salary = item.Mounth;
            }
            if (newContract.AccordingHour)
            {
                newContract.MounthSalary = (newContract.NumHoursInWeek) * 4;
            }
            if (newContract.AccordingMounth)
            {
                newContract.MounthSalary = salary;
            }
            for (int i = 0; i < countOfBrothers; i++)
            {
                newContract.MounthSalary *= 0.98;
            }
            if (newContract.IsIncludeFood)
            { newContract.MounthSalary += 400; }
            myDal_imp.addContract(newContract);
        }

        public void addMother(Mother newMother)
        {
            if (newMother.Id > 99999999 || newMother.Id < 0)
                throw new Exception("The identity number of mother is not correct.");
            foreach (var item in newMother.DaysNeed)
            {
                if (item.IfWork)
                    timeRight(item.StartClock, item.EndClock);
            }
            myDal_imp.addMother(newMother);
        }

        public void addNanny(Nanny newNanny)
        {
            if (newNanny.Age < 18)
            {
                throw new Exception("The nanny is too small.");
            }
            foreach (var item in newNanny.DaysWork)
            {
                if (item.IfWork)
                    timeRight(item.StartClock, item.EndClock);
            }
            myDal_imp.addNanny(newNanny);
        }

        public List<Child> Children()
        {
            return myDal_imp.Children();
        }
        public IEnumerable<Child> GetAllChildren(Func<Child, bool> predicat = null)//child
        {
            return myDal_imp.GetAllChildren(predicat);
        }
        public IEnumerable<Nanny> GetAllNannies(Func<Nanny, bool> predicat = null)//nanny
        {
            return myDal_imp.GetAllNannies(predicat);

        }
        public IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null)//contract
        {
            return myDal_imp.GetAllContracts(predicat);

        }
        public IEnumerable<Mother> GetAllMothers(Func<Mother, bool> predicat = null)//mother
        {
            return myDal_imp.GetAllMothers(predicat);

        }
        public List<Contract> Contracs()
        {
            return myDal_imp.Contracs();
        }

        public void delChild(Child deleteChild)
        {
            var result = from item in Contracs()
                         where item.IdChild == deleteChild.Id
                         select item;
            foreach (var item in result)
            {
                delContract(item);
            }
            myDal_imp.delChild(deleteChild);
        }

        public void delContract(Contract deleteContract)
        {
            Contract myCont = Contracs().FindAll(x => x.NumContract == deleteContract.NumContract).FirstOrDefault();
            if (myCont != null)
            {
                if (DateTime.Now.CompareTo(deleteContract.EndDate) < 0)
                    throw new Exception("You need to pay compensation becuase the employment has not yet ended");
                else myDal_imp.delContract(deleteContract);

            }
           
        }

        public void delMother(Mother deleteMother)
        {
            //delete the children of the mother
            var result = from item in Children()
                         where item.MotherId == deleteMother.Id
                         select item;
            foreach (var item in result)
            {
                delChild(item);
            }
            myDal_imp.delMother(deleteMother);
        }

        public void delNanny(Nanny deleteNanny)
        {
            var result = from item in Contracs()
                         where item.IdNanny == deleteNanny.Id
                         select item;
            foreach (var item in result)
            {
                delContract(item);
            }
            myDal_imp.delNanny(deleteNanny);
        }

        public List<Mother> Mothers()
        {
            return myDal_imp.Mothers();
        }

        public List<Nanny> Nannies()
        {
            return myDal_imp.Nannies();
        }

        public void updateChild(Child existChild)
        {
            myDal_imp.updateChild(existChild);
        }

        public void updateContract(Contract existContract)
        {
            myDal_imp.updateContract(existContract);
        }

        public void updateMother(Mother existMother)
        {
            foreach (var item in existMother.DaysNeed)
            {
                if (item.IfWork)
                    timeRight(item.StartClock, item.EndClock);
            }
            myDal_imp.updateMother(existMother);
        }

        public void updateNanny(Nanny existNanny)
        {
            foreach (var item in existNanny.DaysWork)
            {
                if (item.IfWork)
                    timeRight(item.StartClock, item.EndClock);
            }
            myDal_imp.updateNanny(existNanny);
        }

        private Leg FromGoogleMaps(string source, string dest)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg;
        }
        public int CalculateDistance(string source, string dest)
        {

            return FromGoogleMaps(source, dest).Distance.Value;
        }
        public List<Nanny> adjusmentPotentioal(Mother mother)  // nanny
        {
            List<Nanny> myNannies = new List<Nanny>();
            List<Nanny> anotherResult = new List<Nanny>();
            bool[] goodDays = new bool[6];
            int k = 0;
            int count;
            bool isAllTrue;
            bool flag = true;
            foreach (Nanny item in DataSource.nannies)
            {
                flag = true;
                for (int i = 0; i < 6; i++)
                {
                    if (item.DaysWork[i] != mother.DaysNeed[i])
                    {
                        flag = false;
                        i = 6;
                    }
                }
                if (flag)
                {
                    for (int i = 0; i < 6; i++)
                        if (item.DaysWork[i].StartClock > mother.DaysNeed[i].StartClock)
                            flag = false;
                    for (int i = 0; i < 6; i++)
                        if (item.DaysWork[i].EndClock < mother.DaysNeed[i].EndClock)
                            flag = false;
                    if (flag)
                    {
                        myNannies.Add(item);
                    }
                }
                else
                {
                    //Improvment of the function. Return five nanny that suitable to the days that the mother need.
                    if (k < 5)
                    {
                        count = 0;
                        for (int i = 0; i < 6; i++)
                        {
                            if (item.DaysWork[i] == mother.DaysNeed[i])
                            {
                                if (!goodDays[i])
                                {
                                    count++;
                                    goodDays[i] = true;
                                }
                            }
                        }
                        isAllTrue = true;
                        for (int i = 0; i < 6; i++)
                        {
                            if (goodDays[i] != true)
                            {
                                isAllTrue = false;
                                break;
                            }
                        }
                        if (count != 0 || isAllTrue)
                        {
                            anotherResult.Add(item);
                        }
                    }
                }
            }
            if (myNannies.Count() != 0)
                return myNannies;
            else
                return anotherResult;
        }
        public List<Nanny> NanniesAround(int wantedDistance, Mother myMother)//nanny
        {
            string AddressAround = myMother.AddressAround;
            if (myMother.AddressAround == "")
            {
                AddressAround = myMother.Address;
            }
            List<Nanny> nanAround = new List<Nanny>();

            var result = from item in Nannies()
                         where CalculateDistance(item.Address, AddressAround) <= wantedDistance
                         select item;
            foreach (var item in result)
            {
                nanAround.Add(item);
            }
            return nanAround;
        }
        public List<Nanny> NanAcordingTamat()//nanny
        {
            List<Nanny> myNanny = new List<Nanny>();
            var result = from item in Nannies()
                         where item.eduction == Eduction.Tamat
                         select item;
            foreach (var item in result)
            {
                myNanny.Add(item);
            }
            return myNanny;
        }
        public List<Nanny> NanAcordingEducationOffice()//nanny
        {
            List<Nanny> myNanny = new List<Nanny>();
            var result = from item in Nannies()
                         where item.eduction == Eduction.EducationOffice
                         select item;
            foreach (var item in result)
            {
                myNanny.Add(item);
            }
            return myNanny;
        }
        public List<Child> withoutNanny()//child
        {
            List<Child> myChild = new List<Child>();
            bool has;
            foreach (Child item in Children())
            {
                has = false;
                var result = from item2 in Contracs()
                             where item2.IdChild == item.Id
                             select item2;
                foreach (var item2 in result)
                {
                    has = true;
                }
                if (!has)
                {
                    myChild.Add(item);
                }
            }
            return myChild;
        }
        public delegate bool Predicate(Contract cont);
        public List<Contract> AllContract(Func<Contract, bool> predicat = null)
        {
            List<Contract> myContract = new List<Contract>();
            var result = from item in Contracs()
                         where predicat(item)
                         select item;
            foreach (var item in result)
            {
                myContract.Add(item);
            }
            return myContract;
        }
        public int NumContract(Func<Contract, bool> predicat = null)//contract
        {
            int count = 0;
            var result = from item in Contracs()
                         where predicat(item)
                         select item;
            foreach (var item in result)
            {
                count++;
            }
            return count;
        }
        public IEnumerable<IGrouping<int, Nanny>> NanAcordChildAge(bool ageMax, bool sort = false)//nanny
        {
            IEnumerable<IGrouping<int, Nanny>> result;
            if (ageMax)
            {
                result = from item in Nannies()
                         group item by item.MaxAgeMounth / 3;
            }
            else
            {
                result = from item in Nannies()
                         group item by item.MinAgeMounth / 3;
            }
            if (sort)
            {
                result = result.OrderBy(x => x.Key);
            }
            return result;
        }

        public IEnumerable<IGrouping<double, Contract>> ContractAcordDistance(bool sort = false)//contract
        {
            IEnumerable<IGrouping<double, Contract>> result;
            foreach (var item in Contracs())
            {
                var result1 = ((Nannies()).Where(x => x.Id == item.IdNanny)).ToList();
                var result2 = ((Children()).Where(x => x.Id == item.IdChild)).ToList();
                var result3 = ((Mothers()).Where(x => x.Id == result2[0].MotherId)).ToList();
                item.Distance = (CalculateDistance(result1[0].Address, result3[0].AddressAround)) / 1000;
            }
            result = from item in Contracs()
                     group item by item.Distance / 5;

            if (sort)
            {
                result = result.OrderBy(x => x.Key);
            }
            return result;
        }
        // return list of nanies that prepare food
        public List<Nanny> NanPrepareFood()//nanny
        {
            List<Nanny> myNanny = new List<Nanny>();
            var result = from item in Nannies()
                         where item.IfPrepareFood
                         select item;
            foreach (var item in result)
            {
                myNanny.Add(item);
            }
            if (myNanny.Count == 0)
                return null;
            return myNanny;
        }

        // return groups of mothers according to the numbers of chilren
        public IEnumerable<IGrouping<int, Mother>> MomAcordNumChild()//mother
        {
            IEnumerable<IGrouping<int, Mother>> result;

            var result1 = from item in Mothers()
                          from item2 in Children()
                          where item.Id == item2.MotherId
                          select item;
            foreach (var item in result1)
            {
                item.CountOfChildInNanny++;

            }
            result = from item in result1
                     group item by item.CountOfChildInNanny;

            result = result.OrderBy(x => x.Key);
            return result;
        }
        ///This function makes groups of Nanny according the  payment that they require (Within a range of 10)-hour.
        public IEnumerable<IGrouping<int, Nanny>> NanAcordSalaryOfHour()//nanny
        {


            var result1 = from item in Nannies()
                          group item by item.Hour / 10;
            result1 = result1.OrderBy(x => x.Key);
            return result1;
        }

        //This function checks if the child have friend at his nanny( whith a age a range of 6 mounth) 
        public bool IsHaveFriend(Child myChild)//child
        {//contract
            var result = from item in Contracs()
                         where myChild.Id == item.IdChild
                         select item;
            //nanny
            if (result.FirstOrDefault() != null)

            {
                int NanId = result.FirstOrDefault().IdNanny;

                //the contracts of this nanny
                List<Contract> myContracts = ((Contracs()).Where(X => (X.IdNanny == NanId))).ToList();

                foreach (Contract item in myContracts)
                {
                    var result1 = from child in Children()
                                  where child.Id == item.IdChild && child.Id != myChild.Id
                                  select child;
                    foreach (var item1 in result1)
                    {
                        if (item1.AgeMounth > myChild.AgeMounth - 3 && item1.AgeMounth < myChild.AgeMounth + 3)
                            return true;

                    }
                }
            }
            return false;

        }
        //Diaper
        public TimeSpan ReplaceDiaper(Child myChild)//child
        {
            //int temp = (DateTime.Now.Hour - myChild.TheLastReplaceDiaper.Hour) * 60 + (DateTime.Now.Minute - myChild.TheLastReplaceDiaper.Minute);

            //return "The diaper was replace before" + temp / 60 + "hour and " + temp % 60 + "minute";
            return TimeSpan.Parse((DateTime.Now).ToShortTimeString()) - myChild.TheLastReplaceDiaper;
        }
        public void ReplaceNowDiaper(Child myChild)//child
        {
            myChild.TheLastReplaceDiaper = TimeSpan.Parse((DateTime.Now).ToShortTimeString());
        }
        //How mutch contract exist
        public int ExistsContracts()//contract
        {
            return Contracs().Count;

        }
        //Return where there is  place to insert child 
        public List<Nanny> PlaceForChild()//nanny
        {
            List<Nanny> myNannies = new List<Nanny>();
            foreach (Nanny item in Nannies())
            {
                int count = ((Contracs().Where(x => x.IdNanny == item.Id)).ToList()).Count;
                if (count < item.MaxChild)
                {
                    myNannies.Add(item);
                }
            }
            return myNannies;
        }
        public Child FindChilAcordId(int id)//child
        {
            var result = (from item in Children()
                          where item.Id == id
                          select item).ToList().FirstOrDefault();

            return (Child)result;
        }
        // Contract FindConAcordNum(int NumContract);
        public Contract FindConAcordNum(int NumContract)//contract
        {
            var result = (from item in Contracs()
                          where item.NumContract == NumContract
                          select item).ToList().FirstOrDefault();

            return (Contract)result;
        }
        public Nanny FindNannyAcordId(int id)//nanny
        {
            var result = (from item in Nannies()
                          where item.Id == id
                          select item).ToList().FirstOrDefault();

            return (Nanny)result;
        }
        public Mother FindMotherAcordId(int id)//mother
        {
            var result = (from item in Mothers()
                          where item.Id == id
                          select item).ToList().FirstOrDefault();

            return (Mother)result;
        }
        /// <summary>
        /// This function find a person acordint to id.
        /// </summary>
        public string FindAcordId(int id)//main
        {
            var result1 = from item in Nannies()
                          where item.Id == id
                          select item;
            var result2 = from item in Children()
                          where item.Id == id
                          select item;
            var result3 = from item in Mothers()
                          where item.Id == id
                          select item;
            foreach (var item in result1)
            {
                return item.ToString();
            }
            foreach (var item in result2)
            {
                return item.ToString();
            }
            foreach (var item in result3)
            {
                return item.ToString();
            }
            return null;
        }
        public bool timeRight(TimeSpan start,TimeSpan end)
        {
            if (end < start)
                throw new Exception("The time is not valid. \n");
            return true;
        }
        void initList()
        {
            this.addChild(new Child
            {
                Id = 123,
                IsDiaper = true,
                Birth = DateTime.Parse("11.12.88"),
                Name = "ron",
                MotherId = 1235243,
                ChildGender = Gender.male
            });
            this.addChild(new Child
            {
                Id = 456,
                IsDiaper = true,
                Birth = DateTime.Parse("07.10.93"),
                Name = "dan",
                MotherId = 1235243,
                ChildGender = Gender.male
            });
            this.addChild(new Child
            {
                Id = 478,
                IsDiaper = false,
                Birth = DateTime.Parse("10.05.95"),
                Name = "dora",
                MotherId = 1235243,
                ChildGender = Gender.female
            });
            this.addChild(new Child
            {
                Id = 984,
                IsDiaper = true,
                Birth = DateTime.Parse("07.04.91"),
                Name = "dina",
                MotherId = 3425674,
                ChildGender = Gender.female
            });

            this.addMother(new Mother
            {
                Id = 1235243,
                Name = "Tova",
                Family = "Cohen",
                //   DaysNeed = new Day(StartClock=TimeSpan.Parse("08:00"), TimeSpan.Parse("16:00"), true);


            });

            this.addMother(new Mother
            {
                Id = 3425674,
                Name = "Chana",
                Family = "Levi",
                IsBringFood = true
            });

            this.addMother(new Mother
            {
                Id = 6379,
                Name = "Miri",
                Family = "Mor",
            });

            this.addMother(new Mother
            {
                Id = 872513,
                Name = "Sara",
                Family = "Man",
            });



            this.addNanny(new Nanny
            {
                Id = 84343453,
                Name = "Zipi",
                Family = "Gal",
                MaxChild = 3
            });

            this.addNanny(new Nanny
            {
                Id = 1725341,
                Name = "Chani",
                Family = "Shalom",
                IfPrepareFood=true
            });

            this.addNanny(new Nanny
            {
                Id = 4245,
                Name = "Sima",
                Family = "Abo",
            });
            this.addNanny(new Nanny
            {
                Id = 73452,
                Name = "Rachel",
                Family = "Shevach",
            });



            //add nanny
            //this.AddCourse(new Course { CourseId = 153007, CourseName = "dot net" });
            //this.AddCourse(new Course { CourseId = 153006, CourseName = "c++" });
            //this.AddCourse(new Course { CourseId = 153005, CourseName = "java" });
        }
    }
}