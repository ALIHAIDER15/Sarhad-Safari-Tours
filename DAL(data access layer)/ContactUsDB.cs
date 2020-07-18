using BOL_business_object_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_data_access_layer_
{
    public class ContactUsDB
    {

        WebAppEntities db = new WebAppEntities();
        
        //CRUD OPERATIONS

        public List<tbl_ContactUs> GetAll()              //get all records
        {
            return db.tbl_ContactUs.ToList();
        }



        public tbl_ContactUs GetById(int id)            //get single records
        {
            return db.tbl_ContactUs.Find(id);
        }



        public void Insert(tbl_ContactUs obj)            //Insert single records
        {
            db.tbl_ContactUs.Add(obj);

            save();

            
        }



        public void Delete(int id)            //Delete single records
        {

                tbl_ContactUs user = db.tbl_ContactUs.Find(id);
                db.tbl_ContactUs.Remove(user);

                save();
            
        }



        //SAVE FUNTIONALITY

        public void save()
        {
            db.SaveChanges();
        }



        //public void Upadate(tbl_ContactUs obj)            //Upadate single records
        //{
        //    db.Entry(obj).State = System.Data.Entity.EntityState.Modified;

        //    save();
        //}







    }
}
