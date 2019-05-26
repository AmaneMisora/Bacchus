using System;

namespace Bacchus.model
{
    class Brand
    {
        public String RefBrand { get; set; }
        public String NameBrand { get; set; }

        public Brand()
        {

        }

        public Brand(String RefBrandToSet, String NameBrandToSet)
        {
            RefBrand = RefBrandToSet;
            NameBrand = NameBrandToSet;
        }
    }
}
