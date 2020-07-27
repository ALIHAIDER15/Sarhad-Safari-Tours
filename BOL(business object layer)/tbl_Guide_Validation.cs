using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_business_object_layer_
{
    public class tbl_Guide_validation
    {
      
        public int ID { get; set; }

        [Required(ErrorMessage = "Age Filed Is Required")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Gender Filed Is Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Name Filed Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Experience Filed Is Required")]
        public string Experience { get; set; }

        [Required(ErrorMessage = "Total Tours Filed Is Required")]
        public string Total_Tours { get; set; }

        [Required(ErrorMessage = "Charges Filed Is Required")]
        public string Charges { get; set; }

        [Required(ErrorMessage = "License Filed Is Required")]
        public string Govt_License { get; set; }

        public string ImagePath { get; set; }
        
    }

    [MetadataType(typeof(tbl_Guide_validation))]
    public partial class tbl_Guide
    {
    }

}
