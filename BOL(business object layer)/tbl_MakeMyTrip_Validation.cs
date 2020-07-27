using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_business_object_layer_
{
    public class tbl_MakeMyTrip_Validation
    {


        public int ID { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        public Nullable<System.DateTime> To { get; set; }

        [Required(ErrorMessage = "This  Filed Is Required")]
        public Nullable<System.DateTime> From { get; set; }

        [Required(ErrorMessage = "Adults  Filed Is Required")]
        public string Adults { get; set; }

        [Required(ErrorMessage = "Child  Filed Is Required")]
        public string Child { get; set; }

        [Required(ErrorMessage = "Name  Filed Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email  Filed Is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone  Filed Is Required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Nic  Filed Is Required")]
        public string Nic { get; set; }

        [Required(ErrorMessage = "Address  Filed Is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Transport  Filed Is Required")]
        public string Transport { get; set; }

        [Required(ErrorMessage = "Guide  Filed Is Required")]
        public string Guide { get; set; }

      
        public string Others { get; set; }




    }

    [MetadataType(typeof(tbl_MakeMyTrip_Validation))]
    public partial class tbl_MakeMyTrip
    {
    }
}
