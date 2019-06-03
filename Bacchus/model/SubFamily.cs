using Bacchus.dao;
using System;

namespace Bacchus.model
{
    class SubFamily
    {
        public int RefSubFamily { get; set; }
        public Family RefFamily { get; set; }
        public String NameSubFamily { get; set; }

        /// <summary>
        /// Créé une sous-famille vide
        /// </summary>
        public SubFamily()
        {

        }

        /// <summary>
        /// Créer une sous famille à partir de son nom et de sa famille
        /// </summary>
        /// <param name="NameSubFamilyToSet"></param>
        /// <param name="FamilyToSet"></param>
        public SubFamily(String NameSubFamilyToSet, Family FamilyToSet)
        {
            NameSubFamily = NameSubFamilyToSet;
            RefFamily = FamilyToSet;
            RefSubFamily = -1;

            int TestRef = -1;

            while (RefSubFamily == -1)
            {
                TestRef++;

                if (SubFamilyDAO.GetSubFamilyById(TestRef) == null)
                {
                    RefSubFamily = TestRef;
                }
            }
        }

        /// <summary>
        /// Create a new SubFamily using the reference of the subFamily,
        /// the name of the family and name of the subFamily
        /// </summary>
        /// <param name="RefSubFamilyToSet"></param>
        /// <param name="NameSubFamilyToSet"></param>
        /// <param name="FamilyToSet"></param>
        public SubFamily(int RefSubFamilyToSet, String NameSubFamilyToSet, Family FamilyToSet)
        {
            RefSubFamily = RefSubFamilyToSet;
            NameSubFamily = NameSubFamilyToSet;
            RefFamily = FamilyToSet;
        }

        /// <summary>
        /// Transforme une sous famille en chaine de caractere
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return NameSubFamily;
        }

    }
}
