using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mixed_Models
{
    public class Hotel_imagesCustomModel
    {

        public BOL_business_object_layer_.tbl_Hotels HotelsImages { get; set; }
        public BOL_business_object_layer_.tbl_Hotel_images Hotel_Images { get; set; }


        public HttpPostedFileBase UserImageFiles { get; set; }

    }
}