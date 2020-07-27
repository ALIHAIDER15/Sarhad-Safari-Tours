
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_business_object_layer_
{
    public class tbl_Admin_Validation
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Name  Filed Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email  Filed Is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password  Filed Is Required")]
        public string Password { get; set; }

      
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Admin_rank  Filed Is Required")]
        public string Admin_rank { get; set; }




    }

    [MetadataType(typeof(tbl_Admin_Validation))]
    public partial class tbl_Admin
    {
    }
}
