using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
namespace DAL
{
    public class Dal_imp : Idal
    {
        public void addChild(Child newChild)
        {
            bool flag = true;
            var result = (DataSource.children.Where(x => x.Id == newChild.Id)).ToList();
            foreach (var item in result)
            {
                flag = false;
            }
            if (flag)//now we can add the child
            {
                DataSource.children.Add(newChild);
            }
            else
            {
                throw new Exception("The child is already exist");
            }
        }

        public void addContract(Contract newContract)
        {
            bool flagNanny = false;
            bool flagChild = false;
            var result = (DataSource.nannies.Where(x => x.Id == newContract.IdNanny)).ToList();

            foreach (var item in result)
            {
                flagNanny = true;
            }
            Child myChild = null;
            var result1 = (DataSource.children.Where(x => x.Id == newContract.IdChild)).ToList();
            foreach (var item in result1)
            {
                flagChild = true;
                myChild = item;

            }
            if (!flagNanny && !flagChild)
            {
                throw new Exception("The nanny and the child are not exist.");
            }
            if (!flagNanny)
            {
                throw new Exception("The nanny is not exist.");
            }
            if (!flagChild)
            {
                throw new Exception("The mother and the child are not exist.");
            }
            DataSource.contracs.Add(newContract);
        }

        public void addMother(Mother newMother)
        {
            bool flag = true;
            var result = from item in DataSource.mothers
                         where newMother.Id == item.Id
                         select item;
            foreach (var item in result)
            {
                flag = false;
            }
            if (!flag)
            {
                throw new Exception("The mother is already exist.");
            }
            else
            {
                DataSource.mothers.Add(newMother);
            }
        }
        
        public void addNanny(Nanny newNanny)
        {

            bool flag = true;
            var result = from item in DataSource.nannies
                         where newNanny.Id == item.Id
                         select item;
            foreach (Nanny item in result)
            {
                flag = false;
            }
            if (!flag)
            {
                throw new Exception("The nanny is already exist.");
            }
            else
            {
                DataSource.nannies.Add(newNanny);
            }
        }

        ///  <summery>
        ///  return list of children according the mothers
        ///  </summery>
        public List<Child> Children()
        {
            List<Child> childOfMom = new List<Child>();
            foreach (Mother item in DataSource.mothers)
            {

                var result = from item1 in DataSource.children
                             where item1.MotherId == item.Id
                             select item1;
                foreach (var item2 in result)
                {
                    childOfMom.Add(item2);
                }
            }
            return childOfMom;
        }

        public IEnumerable<Child> GetAllChildren(Func<Child, bool> predicat = null)
        {
            if (predicat == null)
                return DataSource.children.AsEnumerable();

            return DataSource.children.Where(predicat);
        }
        public IEnumerable<Nanny> GetAllNannies(Func<Nanny, bool> predicat = null)
        {
            if (predicat == null)
                return DataSource.nannies.AsEnumerable();

            return DataSource.nannies.Where(predicat);
        }
        public IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null)
        {
            if (predicat == null)
                return DataSource.contracs.AsEnumerable();

            return DataSource.contracs.Where(predicat);
        }
        public IEnumerable<Mother> GetAllMothers(Func<Mother, bool> predicat = null)
        {
            if (predicat == null)
                return DataSource.mothers.AsEnumerable();

            return DataSource.mothers.Where(predicat);
        }

        public List<Contract> Contracs()
        {
            return DataSource.contracs;
        }

        public List<Mother> Mothers()
        {
            return DataSource.mothers;
        }

        public List<Nanny> Nannies()
        {
            return DataSource.nannies;
        }


        public void delChild(Child deleteChild)
        {
            bool flag = false;
            var result = from item in DataSource.children
                         where deleteChild.Id == item.Id
                         select item;
            foreach (var item in result)
            {
                flag = true;
            }
            if (flag)
            {
                DataSource.children.Remove(deleteChild);
            }

            else
                throw new Exception("The child to delete could not found");
        }

        public void delContract(Contract deleteContract)
        {
            bool flag = false;
            var result = from item in DataSource.contracs
                         where deleteContract.NumContract == item.NumContract
                         select item;
            foreach (var item in result)
            {
                flag = true;
            }
            if (flag)
            {
                DataSource.contracs.Remove(deleteContract);
            }
            else
                throw new Exception("The contract to delete could not found");
        }

        public void delMother(Mother deleteMother)
        {

            bool flag = false;
            var result = from item in DataSource.mothers
                         where deleteMother.Id == item.Id
                         select item;
            foreach (var item in result)
            {
                flag = true;
            }
            if (flag)
            {
                DataSource.mothers.Remove(deleteMother);
            }
            else
                throw new Exception("The mother to delete could not found");
        }

        public void delNanny(Nanny deleteNanny)
        {
            bool flag = false;
            var result = from item in DataSource.nannies
                         where deleteNanny.Id == item.Id
                         select item;
            foreach (var item in result)
            {
                flag = true;
            }
            if (flag)
            {
                DataSource.nannies.Remove(deleteNanny);
            }
            else
            throw new Exception("The nanny to delete could not found");
        }

        public void updateChild(Child existChild)
        {
            bool flag = false;
            var result = from item in DataSource.children
                         where existChild.Id == item.Id
                         select item;
            foreach (var item in result)
            {
                flag = true;
                DataSource.children.Remove(item);
                DataSource.children.Add(existChild);
                break;
            }
            if (!flag)
            {
                throw new Exception("The child for update is not exist");
            }
        }

        public void updateContract(Contract existContract)
        {
            bool flag = false;
            var result = from item in DataSource.contracs
                         select item;
            foreach (var item in result)
            {
                flag = true;
                DataSource.contracs.Remove(item);
                DataSource.contracs.Add(existContract);
                break;
            }
            if (!flag)
            {
                throw new Exception("The contract for update is not exist");
            }
        }

        public void updateMother(Mother existMother)
        {
            bool flag = false;
            var result = from item in DataSource.mothers
                         where existMother.Id == item.Id
                         select item;
            foreach (var item in result)
            {
                flag = true;
                DataSource.mothers.Remove(item);
                DataSource.mothers.Add(existMother);
                break;
            }
            if (!flag)
            {
                throw new Exception("The mother for update is not exist");
            }
        }
    
        public void updateNanny(Nanny existNanny)
        {
            bool flag = false;
            var result = from item in DataSource.nannies
                         where existNanny.Id == item.Id
                         select item;
            foreach (var item in result)
            {
                    flag = true;
                    DataSource.nannies.Remove(item);
                    DataSource.nannies.Add(existNanny);
                break;
            }
            if (!flag)
            {
                throw new Exception("The nanny for update is not exist");
            }
        }
    }
}
