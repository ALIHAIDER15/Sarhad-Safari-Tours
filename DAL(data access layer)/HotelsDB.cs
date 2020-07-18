using BOL_business_object_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_data_access_layer_
{
    
        public class HotelsDB
        {


            WebAppEntities db = new WebAppEntities();



            //CRUD OPERATIONS

            public List<tbl_Hotels> GetAll()              //get all records
            {
                return db.tbl_Hotels.ToList();
            }



            public tbl_Hotels GetById(int id)            //get single records
            {
                tbl_Hotels Hotels = db.tbl_Hotels.Find(id);

                return Hotels;
            }




            public int Insert(tbl_Hotels obj)            //Insert single records
            {
                db.tbl_Hotels.Add(obj);

                save();

                int Id = obj.ID;

                return Id;



            }




            public void Upadate(tbl_Hotels obj)            //Upadate single records
            {
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;

                save();
            }




            public void Delete(int id)            //Upadate single records
            {
                tbl_Hotels Hotels = db.tbl_Hotels.Find(id);

                db.tbl_Hotels.Remove(Hotels);

                save();

            }



            //SAVE FUNTIONALITY

            public void save()
            {
                db.SaveChanges();
            }




        }
}

