using System;

namespace Bacchus.model
{
    class Article
    { 
        public String RefArticle { get; set; }
        public String Description { get; set; }
        public SubFamily RefSubFamily { get; set; }
        public Brand RefBrand { get; set; }
        public double PriceHT { get; set; }
        public double Quantity { get; set; }

        /// <summary>
        /// Create a new empty article
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
        public Article(String ParamRefArticle, String ParamDescription, SubFamily ParamRefSubFamily, Brand ParamRefBrand, double ParamPriceHT, double ParamQuantity)
        {
            this.RefArticle = ParamRefArticle;
            this.Description = ParamDescription;
            this.RefSubFamily = ParamRefSubFamily;
            this.RefBrand = ParamRefBrand;
            this.PriceHT = ParamPriceHT;
            this.Quantity = ParamQuantity;
        }


    }
}
