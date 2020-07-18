using BOL_business_object_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_data_access_layer_
{
    public class CityDB
    {

        WebAppEntities db = new WebAppEntities();



     



        public IEnumerable<tbl_city> GetAll()     //get all records
        {
            return db.tbl_city.ToList();
        }





        public tbl_city GetById(int id)            //get single records
        {
            return db.tbl_city.Find(id);
        }




        public void Insert(tbl_city obj)            //Insert single records
        {
            db.tbl_city.Add(obj);

            save();
        }




        public void Upadate(tbl_city obj)            //Upadate single records
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;

            save();
        }




        public void Delete(tbl_city obj)            //Upadate single records
        {
            tbl_city city = db.tbl_city.Find(obj);

            db.tbl_city.Remove(city);

            save();

        }


        public void save()
        {
            db.SaveChanges();
        }


    }
}

