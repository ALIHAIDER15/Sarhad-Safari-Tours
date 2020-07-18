using BOL_business_object_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_data_access_layer_
{
     public class PackagesDB
    {

        WebAppEntities db = new WebAppEntities();







        //CRUD OPERATIONS

        public List<tbl_Packages> GetAll()              //get all records
        {
            return db.tbl_Packages.ToList();
        }



        public tbl_Packages GetById(int id)            //get single records
        {
            tbl_Packages Packages = db.tbl_Packages.Find(id);

            return Packages;
        }




        public int Insert(tbl_Packages obj)            //Insert single records
        {
            db.tbl_Packages.Add(obj);

            save();

            int Id = obj.ID;

            return Id;



        }




        public void Upadate(tbl_Packages obj)            //Upadate single records
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;

            save();
        }




        public void Delete(int id)            //Upadate single records
        {
            tbl_Packages Packages = db.tbl_Packages.Find(id);

            db.tbl_Packages.Remove(Packages);

            save();

        }












        //SAVE FUNTIONALITY

        public void save()
        {
            db.SaveChanges();
        }
    }
}
