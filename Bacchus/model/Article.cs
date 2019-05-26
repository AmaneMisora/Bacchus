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

        public Article()
        {
        }
        


    }
}
