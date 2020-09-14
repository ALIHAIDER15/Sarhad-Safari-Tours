using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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


        public Nullable<int> Item_ID { get; set; }
        public SelectList ItemList { get; set; }
        public string ItemName { get; set; }



        public string Package_ID { get; set; }
        public SelectList PackageList { get; set; }
        public string PackageName { get; set; }



        public string Hotel_ID { get; set; }
        public SelectList HotelList { get; set; }
        public string HotelName { get; set; }



        public string Guide_ID { get; set; }
        public SelectList GuideList { get; set; }
        public string GuideName { get; set; }

        //public List<tbl_Itemscopy> items { get; set; }
    }

      //public class tbl_Itemscopy
      //{
      //    public int ID { get; set; }
      //    public string Name { get; set; }
      
      //    public bool Ischecked { get; set; }
      //}

    [MetadataType(typeof(tbl_MakeMyTrip_Validation))]
    public partial class tbl_MakeMyTrip
    {
    }
}
