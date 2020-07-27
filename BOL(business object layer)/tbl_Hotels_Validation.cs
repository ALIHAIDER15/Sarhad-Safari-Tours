using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_business_object_layer_
{
    public class tbl_Hotels_Validation
    {   
          
        public int ID { get; set; }

        [Required(ErrorMessage = "License  Filed Is Required")]
        public string Gov_License { get; set; }

        [Required(ErrorMessage = "Location Filed Is Required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Standard Filed Is Required")]
        public string Standard { get; set; }

        [Required(ErrorMessage = "Charges Filed Is Required")]
        public string Charges { get; set; }

        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Name Filed Is Required")]
        public string Name { get; set; }





    }

    [MetadataType(typeof(tbl_Hotels_Validation))]
    public partial class tbl_Hotels
    {
    }
}
