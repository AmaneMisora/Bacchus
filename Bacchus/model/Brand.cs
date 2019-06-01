using Bacchus.dao;
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

        public Brand(String NameBrandToSet)
        {
            NameBrand = NameBrandToSet;
            RefBrand = -1;

            int testRef = -1;

            while(RefBrand == -1)
            {
                testRef++;

                if(BrandDAO.getBrandById(testRef) == null)
                {
                    RefBrand = testRef;
                }
            }
        }
       
    }
}
