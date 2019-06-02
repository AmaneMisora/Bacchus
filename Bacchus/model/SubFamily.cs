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
        /// <param name="NameSubFamilyToSet"></param>
        /// <param name="FamilyToSet"></param>
        public SubFamily(int RefSubFamilyToSet, String NameSubFamilyToSet, Family FamilyToSet)
        {
            RefSubFamily = RefSubFamilyToSet;
            NameSubFamily = NameSubFamilyToSet;
            RefFamily = FamilyToSet;
        }
    }
}
