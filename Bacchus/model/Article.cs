﻿using System;

namespace Bacchus.model
{
    class Article
    { 
        public String RefArticle { get; set; }
        public String Description { get; set; }
        public SubFamily RefSubFamily { get; set; }
        public Brand RefBrand { get; set; }
        public float PriceHT { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// Créé un Article vide
        /// </summary>
        public Article()
        {
        }
        
        /// <summary>
        /// Constructeur d'article
        /// </summary>
        /// <param name="ParamRefArticle"></param>
        /// <param name="ParamDescription"></param>
        /// <param name="ParamRefSubFamily"></param>
        /// <param name="ParamRefBrand"></param>
        /// <param name="ParamPriceHT"></param>
        /// <param name="ParamQuantity"></param>
        public Article(String ParamRefArticle, String ParamDescription, SubFamily ParamRefSubFamily, Brand ParamRefBrand, float ParamPriceHT, int ParamQuantity)
        {
            this.RefArticle = ParamRefArticle;
            this.Description = ParamDescription;
            this.RefSubFamily = ParamRefSubFamily;
            this.RefBrand = ParamRefBrand;
            this.PriceHT = ParamPriceHT;
            this.Quantity = ParamQuantity;
        }

        /// <summary>
        /// Renvoie le prix sous forme d'un String compatible avec les requetes sql
        /// </summary>
        /// <returns></returns>
        public String GetPriceToString()
        {
            String StringToReturn = "" ;

            String[] PriceStr = PriceHT.ToString().Split(',');

            StringToReturn += PriceStr[0];

            if(PriceStr.Length == 2)
            {
                StringToReturn += "." + PriceStr[1];
            }
    
            return StringToReturn;
        }

    }
}
