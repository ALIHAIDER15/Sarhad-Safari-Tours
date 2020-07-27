using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_business_object_layer_
{
    public class tbl_MemeberShip_Validation
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title Filed Is Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price Filed Is Required")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Monthly Cost Filed Is Required")]
        public string Monthly_Cost { get; set; }

        [Required(ErrorMessage = "Monthly Souvenirs Filed Is Required")]
        public string Monthly_Souvenirs { get; set; }

        [Required(ErrorMessage = "Trekking Equipment  Filed Is Required")]
        public string Trekking_Equipment { get; set; }


        public string Extra_Field1 { get; set; }
        public string Extra_Field2 { get; set; }
    }

    [MetadataType(typeof(tbl_MemeberShip_Validation))]
    public partial class tbl_MemberShip
    {
    }

}
