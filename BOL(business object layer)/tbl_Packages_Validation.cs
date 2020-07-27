using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_business_object_layer_
{
    public class tbl_Packages_Validation
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Package Name Filed is required")]
        public string PackageName { get; set; }

        [Required(ErrorMessage = "Description Filed is required")]
        public string PackageDescription { get; set; }

        [Required(ErrorMessage = "Number Of Days Filed is required")]
        public Nullable<int> NoOfDays { get; set; }

        [Required(ErrorMessage = "Location Filed is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Standard Filed is required")]
        public string Standard { get; set; }

        [Required(ErrorMessage = "SpotSiteS eeing Filed is required")]
        public string SpotSiteSeeing { get; set; }

        [Required(ErrorMessage = "Contact Filed is required")]
        public string Contact { get; set; }


        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Month Filed is required")]
        public string Month { get; set; }


        [Required(ErrorMessage = "Date Filed is required")]
        public Nullable<int> Date { get; set; }
    }

    [MetadataType(typeof(tbl_Packages_Validation))]
    public partial class tbl_Packages
    {
    }

}
