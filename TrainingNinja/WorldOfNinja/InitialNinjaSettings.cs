namespace WorldOfNinja
{
    using System.Collections.Generic;
    using Interfaces;
    using Item;

    public static class InitialNinjaSettings
    {
        private const int DefaultNinjaMaxForceLevel = 10;
        private const int DefaultNinjaMaxMentalLevel = 10;
        private const int DefaultNinjaInitialStepsToNextLevel = 5;
        
        private const int DefaultNinjaTotalEnergy = 100;
        private const int DefaultNinjaCash = 100050;
        private const int DefaultNinjaInitialForceLevel = 1; 
        private const int DefaultNinjaInitialMentalLevel = 1;

        private static readonly List<ISkill> DefaultNinjaListOfFightingSkills = new List<ISkill>()
        { 
            new Skill(PowerEnum.ForcePower, "Fist Fight", 10, 60) 
        };

        private static readonly List<ISkill> DefaultNinjaListOfMentalSkills = new List<ISkill>() 
        { 
            new Skill(PowerEnum.MentalPower, "Diversion", 10, 80) 
        };

        private static readonly List<ICommercialItem> DefaultNinjaBagOfItems = new List<ICommercialItem>();

        private static int ninjaMaxForceLevel;
        private static int ninjaMaxMentalLevel;
        private static int ninjaInitialStepsToNextLevel;

        private static int ninjaTotalEnergy;
        private static int ninjaCash;
        private static int ninjaInitialForceLevel;
        private static int ninjaInitialMentalLevel;
        private static List<ISkill> ninjaListOfFightingSkills;
        private static List<ISkill> ninjaListOfMentalSkills;
        private static List<ICommercialItem> ninjaBagOfItems;

        public static int NinjaInitialStepsToNextLevel
        {
            get
            {
                return ninjaInitialStepsToNextLevel != 0 ? ninjaInitialStepsToNextLevel : DefaultNinjaInitialStepsToNextLevel;
            }

            set
            {
                if (value < 1)
                {
                    throw new ImproperlyDefinedCreatureException("NinjaInitialStepsToNextLevel must be positive integer");
                }

                ninjaInitialStepsToNextLevel = value;
            }
        }

        public static int NinjaMaxForceLevel
        {
            get
            {
                return ninjaMaxForceLevel != 0 ? ninjaMaxForceLevel : DefaultNinjaInitialForceLevel;
            }

            set
            {
                if (value < 1)
                {
                    throw new ImproperlyDefinedCreatureException("NinjaMaxForceLevel must be positive integer");
                }

                ninjaMaxForceLevel = value;
            }
        }

        public static int NinjaMaxMentalLevel
        {
            get
            {
                return ninjaMaxMentalLevel != 0 ? ninjaMaxMentalLevel : DefaultNinjaMaxMentalLevel;
            }

            set
            {
                if (value < 1)
                {
                    throw new ImproperlyDefinedCreatureException("NinjaMaxMentalLevel must be positive integer");
                }

                ninjaMaxMentalLevel = value;
            }
        }

        public static int NinjaTotalEnergy
        {
            get
            {
                return ninjaTotalEnergy != 0 ? ninjaTotalEnergy : DefaultNinjaTotalEnergy;
            }

            set
            {
                if (value < 1)
                {
                    throw new ImproperlyDefinedCreatureException("NinjaTotalLife must be positive integer");
                }

                ninjaTotalEnergy = value;
            }
        }

        public static int NinjaCash
        {
            get
            {
                return ninjaCash != 0 ? ninjaCash : DefaultNinjaCash;
            }

            set
            {
                if (value < 1)
                {
                    throw new ImproperlyDefinedCreatureException("NinjaCash must be positive integer");
                }

                ninjaCash = value;
            }
        }

        public static int NinjaInitialForceLevel
        {
            get
            {
                return ninjaInitialForceLevel != 0 ? ninjaInitialForceLevel : DefaultNinjaInitialForceLevel;
            }

            set
            {
                if (value < 1)
                {
                    throw new ImproperlyDefinedCreatureException("NinjaInitialForceLevel must be positive integer");
                }

                ninjaInitialForceLevel = value;
            }
        }

        public static int NinjaInitialMentalLevel
        {
            get
            {
                return ninjaInitialMentalLevel != 0 ? ninjaInitialMentalLevel : DefaultNinjaInitialMentalLevel;
            }

            set
            {
                if (value < 1)
                {
                    throw new ImproperlyDefinedCreatureException("NinjaInitialMentalLevel must be positive integer");
                }

                ninjaInitialMentalLevel = value;
            }
        }

        public static List<ISkill> NinjaListOfFightingSkills
        {
            get
            {
                return ninjaListOfFightingSkills != null ? ninjaListOfFightingSkills : new List<ISkill>(DefaultNinjaListOfFightingSkills);
            }

            set
            {
                ninjaListOfFightingSkills = new List<ISkill>(value);
            }
        }

        public static List<ISkill> NinjaListOfMentalSkills 
        {
            get
            {
                return ninjaListOfMentalSkills != null ? ninjaListOfMentalSkills : new List<ISkill>(DefaultNinjaListOfMentalSkills);
            }

            set
            {
                ninjaListOfMentalSkills = new List<ISkill>(value);
            }
        }

        public static List<ICommercialItem> NinjaBagOfItems 
        { 
            get
            {
                return ninjaBagOfItems != null ? ninjaBagOfItems : new List<ICommercialItem>(); 
            }

            set
            {
                ninjaBagOfItems = value;
            }
        }
    }
}
