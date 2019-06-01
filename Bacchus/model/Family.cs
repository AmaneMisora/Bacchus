using Bacchus.dao;
using System;

namespace Bacchus.model
{
    class Family
    {
        public int RefFamily { get; set; }
        public String NameFamily { get; set; }

        /**
         * Create a new empty family
         */
        public Family()
        {
            RefFamily = -1;
        }

        /**
         * Create a new family using the reference and the name
         * param name="RefFamilyToSet" : The reference to set
         * param name="param name="NameFamilyToSet" : The name to set
         */
        public Family(int RefFamilyToSet, String NameFamilyToSet)
        {
            RefFamily = RefFamilyToSet;
            NameFamily = NameFamilyToSet;
        }

        /**
         * Create a new family using the reference and the name
         * param name="RefFamilyToSet" : The reference to set
         * param name="param name="NameFamilyToSet" : The name to set
         */
        public Family(String NameFamilyToSet)
        {
            NameFamily = NameFamilyToSet;
            RefFamily = -1;

            int TestRef = -1;

            while (RefFamily == -1)
            {
                TestRef++;
                
                if (FamilyDAO.getFamilyById(TestRef) == null)
                {
                    RefFamily = TestRef;
                }
            }


        }
    }
}
