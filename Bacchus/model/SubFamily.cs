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
        /// Create a new empty SubFamily 
        /// </summary>
        public SubFamily()
        {

        }

        /// <summary>
        /// Create a new SubFamily using the reference of the subFamily,
        /// the name of the family and name of the subFamily
        /// </summary>
        /// <param name="RefSubFamilyToSet"></param>
        /// <param name="NameFamilyToSet"></param>
        /// <param name="NameSubFamilyToSet"></param>
        public SubFamily(int RefSubFamilyToSet, String NameFamilyToSet, String NameSubFamilyToSet)
        {
            RefSubFamily = RefSubFamilyToSet;
            NameSubFamily = NameSubFamilyToSet;

            if(FamilyDAO.getFamilyByName(NameFamilyToSet) == null)
            {
                FamilyDAO.addFamily(new Family(NameFamilyToSet));
            }
            else
            {
                RefFamily = FamilyDAO.getFamilyByName(NameFamilyToSet);
            }
        }
    }
}
