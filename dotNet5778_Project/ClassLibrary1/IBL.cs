using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    public interface IBL
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
        List<Nanny> adjusmentPotentioal(Mother mother);
        List<Nanny> NanniesAround(int wantedDistance, Mother myMother);
        List<Nanny> NanAcordingTamat();
        List<Nanny> NanAcordingEducationOffice();
        List<Child> withoutNanny();

        List<Contract> AllContract(Func<Contract, bool> predicat = null);
        int NumContract(Func<Contract, bool> predicat = null);
        IEnumerable<IGrouping<int, Nanny>> NanAcordChildAge(bool ageMax, bool sort = false);
        IEnumerable<IGrouping<double, Contract>> ContractAcordDistance(bool sort = false);

        List<Nanny> NanPrepareFood();
        IEnumerable<IGrouping<int, Mother>> MomAcordNumChild();
        IEnumerable<IGrouping<int, Nanny>> NanAcordSalaryOfHour();
        bool IsHaveFriend(Child myChild);
        TimeSpan ReplaceDiaper(Child myChild);
        void ReplaceNowDiaper(Child myChild);
        int ExistsContracts();
        List<Nanny> PlaceForChild();
        Child FindChilAcordId(int id);
        Contract FindConAcordNum(int NumContract);
        Nanny FindNannyAcordId(int id);
        Mother FindMotherAcordId(int id);
        string FindAcordId(int id);
    }
}
