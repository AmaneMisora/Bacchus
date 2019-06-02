using Bacchus.dao;
using System;

namespace Bacchus.model
{
    class Family
    {
        public int RefFamily { get; set; }
        public String NameFamily { get; set; }

        /// <summary>
        /// Create a new empty family
        /// </summary>
        public Family()
        {
            RefFamily = -1;
        }

        /// <summary>
        /// Create a new family using the reference and the name
        /// </summary>
        /// <param name="RefFamilyToSet"></param>
        /// <param name="NameFamilyToSet"></param>
        public Family(int RefFamilyToSet, String NameFamilyToSet)
        {
            RefFamily = RefFamilyToSet;
            NameFamily = NameFamilyToSet;
        }

        /// <summary>
        /// Create a new family using the reference and the name
        /// </summary>
        /// <param name="NameFamilyToSet"></param>
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

        /// <summary>
        /// Transforme une famille en chaine de caractere
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return NameFamily;
        }
    }
}
