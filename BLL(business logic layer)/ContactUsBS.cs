using BOL_business_object_layer_;
using DAL_data_access_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_business_logic_layer_
{
   public class ContactUsBS
    {
         
           ContactUsDB db = new ContactUsDB();             //obj of db class


           public List<tbl_ContactUs> GetAll()            //get all records
            {
               return db.GetAll();


            }
           
           
       
           
            public tbl_ContactUs GetById(int id)           //get single records
            {
                return db.GetById(id);
            }
          
          
          
          
            public void Insert(tbl_ContactUs obj)          //Insert single records
            {
                db.Insert(obj);
        


            }
          
          
          
            public void Delete(int id)         //Delete  records
            {
               db.Delete(id);
            }        
            
        


}
}
