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
    
    public partial class tbl_Packages
    {
        public int ID { get; set; }
        public string PackageName { get; set; }
        public string PackageDescription { get; set; }
        public Nullable<int> NoOfDays { get; set; }
        public string Location { get; set; }
        public string Standard { get; set; }
        public string SpotSiteSeeing { get; set; }
        public string Contact { get; set; }
        public string ImagePath { get; set; }
        public string Month { get; set; }
        public Nullable<int> Date { get; set; }
    }
}