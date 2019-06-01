using Bacchus.dao;
using System;

namespace Bacchus.model
{
    class SubFamily
    {
        public int RefSubFamily { get; set; }
        public Family RefFamily { get; set; }
        public String NameSubFamily { get; set; }

        public SubFamily()
        {

        }

        public SubFamily(int RefSubFamilyToSet, String NameFamilyToSet, String NameSubFamilyToSet)
        {
            RefSubFamily = RefSubFamilyToSet;
            NameSubFamily = NameSubFamilyToSet;

            if(FamilyDAO.getFamilyByName(NameFamilyToSet) == null)
            {

            }
        }
    }
}
