using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.Xml.Serialization;
using DAL;
using DS;

namespace DAL
{
    class DAL_XML:Idal
    {
        XElement childRoot;
        string childPath = @"childXml.xml";
        string motherPath = @"motherXml.xml";
        string nannyPath = @"nannyXml.xml";
        string contractPath = @"contractXml.xml";
        public int code;
        public DAL_XML()
        {
            code = 0;
            if (!File.Exists(childPath))
                CreateFiles();
            else
                LoadData();
            saveListToXML<Mother>(DS.DataSource.mothers, motherPath);
            saveListToXML<Nanny>(DS.DataSource.nannies, nannyPath);
            saveListToXML<Contract>(DS.DataSource.contracs, contractPath);

        }
        protected static DAL_XML instance = null;
        public static DAL_XML GetInstance()
        {
            if (instance == null) instance = new DAL_XML();
            return instance;
        }
        private void CreateFiles()
        {
            childRoot = new XElement("children");
            childRoot.Save(childPath);
        }
        private void LoadData()
        {
            try
            {
                childRoot = XElement.Load(childPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        public void SaveChildrenList(List<Child> childList)
        {
            childRoot = new XElement("children");

            foreach (Child item in childList)
            {
                XElement id = new XElement("id", item.Id);
                XElement childGender = new XElement("childGender", item.ChildGender);
                XElement motherId = new XElement("motherId", item.MotherId);
                XElement name = new XElement("Name", item.Name);
                XElement birth = new XElement("birth", item.Birth);
                XElement ageMounth = new XElement("ageMounth", item.AgeMounth);
                XElement isSpecielNeed = new XElement("isSpecielNeed", item.IsSpecielNeed);
                XElement specielNeed = new XElement("specielNeed", item.SpecielNeed);
                XElement numSleepHours = new XElement("numSleepHours", item.NumSleepHours);
                XElement isDiaper = new XElement("isDiaper", item.IsDiaper);
                XElement theLastReplaceDiaper = new XElement("theLastReplaceDiaper", item.TheLastReplaceDiaper);
                XElement elergy = new XElement("elergy", item.Elergy);
                XElement likedFood = new XElement("likedFood", item.LikedFood);
                XElement plays = new XElement("plays", item.Plays);
                XElement knowToWalk = new XElement("knowToWalk", item.KnowToWalk);
                XElement pacifier = new XElement("pacifier", item.pacifier);
                XElement child = new XElement("child", id, name, motherId, birth, childGender, ageMounth, isSpecielNeed, specielNeed, numSleepHours
                    , isDiaper, theLastReplaceDiaper, elergy, likedFood, plays, knowToWalk, pacifier);
                childRoot.Add(child);
            }

        }


        #region Child Function
        XElement ConvertChild(BE.Child c)
        {
            XElement childElement = new XElement("child");

            foreach (PropertyInfo item in typeof(BE.Child).GetProperties())
               if (item != null)
                {
                    childElement.Add
                   (
                   new XElement(item.Name, item.GetValue(c, null).ToString())
                   );
                }
                    return childElement;
                
        }
        BE.Child ConvertChild(XElement element)
        {
            Child c = new Child();

            foreach (PropertyInfo item in typeof(BE.Child).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                if (item.CanWrite)
                    item.SetValue(c, convertValue);
            }

            return c;
        }
        public void addChild(Child c)
        {
            Child ch = FindacordId(c.Id);
            if (ch != null)
                throw new Exception("child with the same id already exists!");
            childRoot.Add(ConvertChild(c));
            childRoot.Save(childPath);
        }
        public void delChild(Child child)
        {
            XElement toRemove = (from item in childRoot.Elements()
                                 where int.Parse(item.Element("Id").Value) == child.Id
                                 select item).FirstOrDefault();

            if (toRemove == null)
                throw new Exception("Child with the same id not found!");

            toRemove.Remove();

            childRoot.Save(childPath);
            //return true; bool??
        }
        public void updateChild(Child c)
        {
            XElement toUpdate = (from item in childRoot.Elements()
                                 where int.Parse(item.Element("Id").Value) == c.Id
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Child with the same id not found!");

            foreach (PropertyInfo item in typeof(BE.Child).GetProperties())
                toUpdate.Element(item.Name).SetValue(item.GetValue(c).ToString());

            childRoot.Save(childPath);
        }
        public Child FindacordId(int id)
        {
            XElement ch = null;

            try
            {
                ch = (from item in childRoot.Elements()
                      where int.Parse(item.Element("Id").Value) == id
                      select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }

            if (ch == null)
                return null;

            return ConvertChild(ch);
        }
        public IEnumerable<Child> GetAllChildren(Func<Child, bool> predicat = null)
        {
            if (predicat == null)
                if (predicat == null)
                {
                    return from item in childRoot.Elements()
                           select ConvertChild(item);
                }
            return from item in childRoot.Elements()
                   let s = ConvertChild(item)
                   where predicat(s)
                   select s;
        }
        //public IEnumerable<Child> GetAllChildren(Predicate<Child> predicat = null)
        //{

        //    if (predicat == null)
        //    {
        //        return from item in childRoot.Elements()
        //               select ConvertChild(item);
        //    }

        //    return from item in childRoot.Elements()
        //           let s = ConvertChild(item)
        //           where predicat(s)
        //           select s;
        //}


        public bool existChild(int id)
        {
            if (FindacordId(id) != null)
                return true;
            return false;
        }
        #endregion

        #region Nanny Function

        public void addNanny(Nanny n)
        {

            if (existNanny(n.Id))
                throw new Exception("The id is already exist");
            DS.DataSource.nannies.Add(n);

            saveListToXML(DS.DataSource.nannies, nannyPath);
        }
        public void delNanny(Nanny temp)
        {
            // var temp = FindNanAcordId(id);
            if (temp != null)
            {
                if (GetAllContracts(c => c.IdNanny == temp.Id && c.EndDate < DateTime.Today).Any())
                    throw new Exception("The nanny has at least one valid contract.");
                DataSource.nannies.Remove(temp);
                DataSource.contracs.RemoveAll(c => c.IdNanny == temp.Id);//remove old contracts
                saveListToXML(DS.DataSource.nannies, nannyPath);
                saveListToXML(DS.DataSource.contracs, contractPath);
            }
            else
                throw new Exception("There is no such Nanny");
        }

        public void updateNanny(Nanny n)
        {
            int index = DataSource.nannies.FindIndex(x => x.Id == n.Id);
            if (index == -1)
                throw new Exception("There is no such nanny");
            DataSource.nannies[index] = n;
            saveListToXML(DS.DataSource.nannies, nannyPath);
        }
        public Nanny FindNanAcordId(int id)
        {
            DataSource.nannies = (loadListFromXML<Nanny>(nannyPath));
            var temp = DataSource.nannies.Where(n => n.Id == id);
            foreach (var item in temp)
            {
                return item;
            }
            return null;
        }

        public bool existNanny(int id)
        {
            return FindNanAcordId(id) != null;
        }
        #endregion


        #region Mother Function
        public void addMother(Mother m)
        {
            if (existMother(m.Id))
                throw new Exception("The id is already exist");
            DS.DataSource.mothers.Add(m);

            saveListToXML(DS.DataSource.mothers, motherPath);
        }

        public void delMother(Mother m)
        {
            //   var temp = findMother(id);
            if (m != null)
            {
                DataSource.mothers.Remove(m);
                saveListToXML(DS.DataSource.mothers, motherPath);
            }
            else
                throw new Exception("There is no such Mother");
        }

        public void updateMother(Mother m)
        {
            int index = DataSource.mothers.FindIndex(x => x.Id == m.Id);
            if (index == -1)
                throw new Exception("There is no such Mother");
            DataSource.mothers[index] = m;
            saveListToXML(DS.DataSource.mothers, motherPath);
        }

        public Mother findMother(int id)
        {
            DataSource.mothers = (loadListFromXML<Mother>(motherPath));
            var temp = DataSource.mothers.Where(m => m.Id == id);
            foreach (var item in temp)
            {
                return item;
            }
            return null;
        }

        public bool existMother(int id)
        {
            return findMother(id) != null;
        }
        #endregion

        #region contract Function
        public void addContract(Contract c)
        {
            if (code == 99999999)
                throw new Exception("Num of contracts is limited, you cannot add more contracts");
            if (existContract(c.NumContract))
                throw new Exception("The id is already exist");
            if (!existChild(c.IdChild))
                throw new Exception("The child is not exist");
            if (!existNanny(c.IdNanny))
                throw new Exception("The nanny is not exist");
            c.NumContract = ++code;
            DS.DataSource.contracs.Add(c);
            saveListToXML(DS.DataSource.contracs, contractPath);
        }

        public void delContract(Contract c)
        {
            //  var temp = findContract(id);
            if (c != null)
                DataSource.contracs.Remove(c);
            else
                throw new Exception("There is no such Contract");
            saveListToXML(DS.DataSource.contracs, contractPath);
        }

        public void updateContract(Contract c)
        {
            int index = DataSource.contracs.FindIndex(x => x.NumContract == c.NumContract);
            if (index == -1)
                throw new Exception("There is no such contract");
            DataSource.contracs[index] = c;
            saveListToXML(DS.DataSource.contracs, contractPath);
        }

        public Contract findContract(int id)
        {
            var temp = DataSource.contracs.Where(n => n.NumContract == id);
            foreach (var item in temp)
            {
                return item;
            }
            return null;
        }

        public bool existContract(int id)
        {
            return existContract(id);
        }

        #endregion



        public IEnumerable<Nanny> GetAllNannies(Func<Nanny, bool> predicat = null)
        {
            return predicat == null ? (loadListFromXML<Nanny>(nannyPath)) : (loadListFromXML<Nanny>(nannyPath)).FindAll(x=>predicat(x));
        }

        public IEnumerable<Mother> GetAllMothers(Func<Mother, bool> predicat = null)
        {
            return predicat == null ? (loadListFromXML<Mother>(motherPath)) : (loadListFromXML<Mother>(motherPath)).FindAll(x=>predicat(x));
        }

        public IEnumerable<Child> GetChildrenByMother(Mother m)
        {
            return GetAllChildren(c => c.MotherId == m.Id);
        }

        public IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null)
        {
            return predicat == null ? (loadListFromXML<Contract>(contractPath)) : (loadListFromXML<Contract>(contractPath)).FindAll(x=>predicat(x));
        }

        public static void saveListToXML<T>(List<T> list, string Path)
        {
            FileStream file = new FileStream(Path, FileMode.Create);
            XmlSerializer x = new XmlSerializer(list.GetType());
            x.Serialize(file, list);
            file.Close();
        }

        public static List<T> loadListFromXML<T>(string path)
        {
            List<T> list;
            XmlSerializer x = new XmlSerializer(typeof(List<T>));
            FileStream file = new FileStream(path, FileMode.Open);
            list = (List<T>)x.Deserialize(file);
            file.Close();
            return list;
        }

        public List<Contract> Contracs()
        {
            return GetAllContracts().ToList();
        }

        public List<Mother> Mothers()
        {
            return GetAllMothers().ToList();
        }
        public List<Nanny> Nannies()
        {
            return GetAllNannies().ToList();
        }

        public List<Child> Children()
        {
            return GetAllChildren().ToList();
        }
    }
}
