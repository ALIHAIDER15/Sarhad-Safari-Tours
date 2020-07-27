using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_business_object_layer_
{
    public class tbl_ContactUs_Validtaion
    {
        public int ID { get; set; }


        [Required(ErrorMessage ="Name Field Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Field Is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject Field Is Required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message Field Is Required")]
        public string Message { get; set; }
    }

    [MetadataType(typeof(tbl_ContactUs_Validtaion))]
    public partial class tbl_ContactUs
    {
    }
}
