using Bacchus.dao;
using System;

namespace Bacchus.model
{
    class Family
    {
        public int RefFamily { get; set; }
        public String NameFamily { get; set; }

        /// <summary>
        /// Créé une nouvelle famille vide
        /// </summary>
        public Family()
        {
            RefFamily = -1;
        }

        /// <summary>
        /// Créé une famille à partir de son nom et son id
        /// </summary>
        /// <param name="RefFamilyToSet"></param>
        /// <param name="NameFamilyToSet"></param>
        public Family(int RefFamilyToSet, String NameFamilyToSet)
        {
            RefFamily = RefFamilyToSet;
            NameFamily = NameFamilyToSet;
        }

        /// <summary>
        /// Créé une famille à partir de son nom
        /// </summary>
        /// <param name="NameFamilyToSet"></param>
        public Family(String NameFamilyToSet)
        {
            NameFamily = NameFamilyToSet;
            RefFamily = -1;

            int TestRef = -1;

            // Recherche d'un id inutilisé
            while (RefFamily == -1)
            {
                TestRef++;
                
                if (FamilyDAO.GetFamilyById(TestRef) == null)
                {
                    RefFamily = TestRef;
                }
            }
        }

        /// <summary>
        /// Transforme une famille en chaine de caractere
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return NameFamily;
        }
    }
}
