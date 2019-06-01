using Bacchus.dao;
using System;

namespace Bacchus.model
{
    class Brand
    {
        public int RefBrand { get; set; }
        public String NameBrand { get; set; }

        /// <summary>
        /// Create a new empty Brand
        /// </summary>
        public Brand()
        {

        }

        /// <summary>
        /// Create a new Brand using the reference and the name of the brand
        /// </summary>
        /// <param name="RefBrandToSet"></param>
        /// <param name="NameBrandToSet"></param>
        public Brand(int RefBrandToSet, String NameBrandToSet)
        {
            RefBrand = RefBrandToSet;
            NameBrand = NameBrandToSet;
        }

        /// <summary>
        /// Create a new Brand using the name of the brand
        /// </summary>
        /// <param name="NameBrandToSet"></param>
        public Brand(String NameBrandToSet)
        {
            NameBrand = NameBrandToSet;
            RefBrand = -1;

            int TestRef = -1;

            while(RefBrand == -1)
            {
                TestRef++;

                if(BrandDAO.getBrandById(TestRef) == null)
                {
                    RefBrand = TestRef;
                }
            }
        }
       
    }
}
