namespace WorldOfNinja.Interfaces
{
    using System.Collections.Generic;

    public interface IHero : IRegenerable
    {
        int Cash { get; }

        IList<ISkill> ListOfMentalSkills { get; }

        IList<ISkill> ListOfFightingSkills { get; }

        IList<ICommercialItem> BagOfItems { get; }

        void GetCash(int cash); 

        bool PayCash(int cash);
        
        bool GetItem(IUsable item);

        void UseItem(IUsable item);

        bool UpMentalLevel();

        bool UpForceLevel();
    }
}
