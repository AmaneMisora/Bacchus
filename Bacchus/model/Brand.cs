using System;

namespace Bacchus.model
{
    class Brand
    {
        public int RefBrand { get; set; }
        public String NameBrand { get; set; }

        public Brand()
        {

        }

        public Brand(int RefBrandToSet, String NameBrandToSet)
        {
            RefBrand = RefBrandToSet;
            NameBrand = NameBrandToSet;
        }

       
    }
}
