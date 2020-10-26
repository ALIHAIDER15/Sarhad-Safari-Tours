using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_business_object_layer_
{

    //MODEL FOR GETTING DATA FROM  <<Hotle_Images_Custom_Model >>
    public class Hotle_Images_Custom_Model2
    {

        //constructor of model
        public Hotle_Images_Custom_Model2()
        {

            Images = new List<ImagePath2>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Gov_License { get; set; }
        public string Standard { get; set; }

        public string Charges { get; set; }

        public string ImagePath { get; set; }


        public List<ImagePath2> Images { get; set; }

    }



    public class ImagePath2
    {
        public string Images { get; set; }
    }

  
}
