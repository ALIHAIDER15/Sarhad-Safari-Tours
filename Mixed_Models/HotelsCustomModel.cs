using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mixed_Models
{
    public class HotelsCustomModel
    {

        public BOL_business_object_layer_.tbl_Hotels Hotels { get; set; }


        public HttpPostedFileBase UserImageFiles { get; set; }


        public List<HttpPostedFileBase> Files { get; set; }

    }
}