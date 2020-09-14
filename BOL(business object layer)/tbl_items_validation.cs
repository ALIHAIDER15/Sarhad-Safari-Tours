using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL_business_object_layer_
{
    public class tbl_items_validation
    {
        //public partial class tbl_Items
        //{
        //    public int ID { get; set; }
        //    public string Name { get; set; }

        //    public bool Ischecked { get; set; }

        //}
        //public class itmeModel
        //{
        //    public List<tbl_Items> items { get; set; }
        //}



    }


    [MetadataType(typeof(tbl_items_validation))]
    public partial class tbl_Items
    {
    }
}
