using System;

namespace Bacchus.model
{
    class Family
    {
        public int RefFamily { get; set; }
        public String NameFamily { get; set; }

        public Family()
        {

        }

        public Family(int RefFamilyToSet, String NameFamilyToSet)
        {
            RefFamily = RefFamilyToSet;
            NameFamily = NameFamilyToSet;
        }
    }
}
