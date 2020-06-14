using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public interface Idal
    {
        void addNanny(Nanny newNanny);
        void delNanny(Nanny deleteNanny);
        void updateNanny(Nanny existNanny);

        void addMother(Mother newMother);
        void delMother(Mother deleteMother);
        void updateMother(Mother existMother);

        void addChild(Child newChild);
        void delChild(Child deleteChild);
        void updateChild(Child existChild);

        void addContract(Contract newContract);
        void delContract(Contract deleteContract);
        void updateContract(Contract existContract);

        List<BE.Nanny> Nannies();
        List<BE.Mother> Mothers();
        List<BE.Child> Children();
        List<BE.Contract> Contracs();
        IEnumerable<Child> GetAllChildren(Func<Child, bool> predicat = null);
        IEnumerable<Nanny> GetAllNannies(Func<Nanny, bool> predicat = null);
        IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null);
        IEnumerable<Mother> GetAllMothers(Func<Mother, bool> predicat = null);

    }
}
