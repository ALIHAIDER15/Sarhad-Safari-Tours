//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL_business_object_layer_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class tbl_MakeMyTrip
    {
       
        public int ID { get; set; }
        public Nullable<int> Item_ID { get; set; }
        public Nullable<int> Package_ID { get; set; }
        public Nullable<int> Hotel_ID { get; set; }
        public Nullable<int> Guide_ID { get; set; }

        public Nullable<System.DateTime> To { get; set; }
        public Nullable<System.DateTime> From { get; set; }
        public string Adults { get; set; }
        public string Child { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nic { get; set; }
        public string Address { get; set; }
        public string Transport { get; set; }
        public string Guide { get; set; }
        public string Others { get; set; }
        public Nullable<int> test { get; set; }



        public SelectList ItemList { get; set; }
        public string ItemName { get; set; }




        public SelectList PackageList { get; set; }
        public string PackageName { get; set; }




        public SelectList HotelList { get; set; }
        public string HotelName { get; set; }



   
        public SelectList GuideList { get; set; }
        public string GuideName { get; set; }

    }
}
