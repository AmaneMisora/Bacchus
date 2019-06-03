using Bacchus.dao;
using System;

namespace Bacchus.model
{
    class Brand
    {
        public int RefBrand { get; set; }
        public String NameBrand { get; set; }

        /// <summary>
        /// Créé une marque vide
        /// </summary>
        public Brand()
        {

        }

        /// <summary>
        /// Créé une nouvelle marque à partir de son nom et son id
        /// </summary>
        /// <param name="RefBrandToSet"></param>
        /// <param name="NameBrandToSet"></param>
        public Brand(int RefBrandToSet, String NameBrandToSet)
        {
            RefBrand = RefBrandToSet;
            NameBrand = NameBrandToSet;
        }

        /// <summary>
        /// Créé une nouvelle marque à partir de son nom
        /// </summary>
        /// <param name="NameBrandToSet"></param>
        public Brand(String NameBrandToSet)
        {
            NameBrand = NameBrandToSet;
            RefBrand = -1;

            int TestRef = -1;

            // Recherche d'un id inutilisé
            while (RefBrand == -1)
            {
                TestRef++;

                if(BrandDAO.GetBrandById(TestRef) == null)
                {
                    RefBrand = TestRef;
                }
            }
        }

        /// <summary>
        /// Transforme une marque en chaine de caractere
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return NameBrand;
        }

    }
}
