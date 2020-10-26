using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mixed_Models
{
    public class CrawelCustomModel
    {

        //constructor of model
        public CrawelCustomModel()
        {
            NameList = new List<Name>();

            NumOfDayList = new List<NumOfDay>();

            MonthsList = new List<Month>();

            ImagesList = new List<ImageModel>();
        }
        public List<BOL_business_object_layer_.tbl_Packages> Packages { get; set; }
        public  List<Name> NameList { get; set; }
        public List<NumOfDay> NumOfDayList { get; set; }

        public List<Month> MonthsList { get; set; }

        public List<ImageModel> ImagesList { get; set; }



    }

    public class Name
    {

        public  string names { get; set; }
    }


    public class NumOfDay
    {
        public string NumOfDays { get; set; }
    }



    public class Month
    {
        public string Months { get; set; }
    }


    public class ImageModel
    {
        public string Images { get; set; }
    }


}