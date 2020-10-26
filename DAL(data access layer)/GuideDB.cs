using BOL_business_object_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_data_access_layer_
{
    public class GuideDB
    {
        

            WebAppEntities db = new WebAppEntities();



            //CRUD OPERATIONS

            public List<tbl_Guide> GetAll()              //get all records
            {
                return db.tbl_Guide.ToList();
            }



            public tbl_Guide GetById(int id)            //get single records
            {
                tbl_Guide Guide = db.tbl_Guide.Find(id);

                return Guide;
            }


             public string GetByIdForName(int id)            //get single records for names
             {
           
           
                 string Name = db.tbl_Guide.Where(item => item.ID == id).Select(item => item.Name).SingleOrDefault();
           
           
                 return Name;
             }
           

            public int Insert(tbl_Guide obj)            //Insert single records
            {
                db.tbl_Guide.Add(obj);

                save();

                int Id = obj.ID;

                return Id;



            }




            public void Upadate(tbl_Guide obj)            //Upadate single records
            {
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;

                save();
            }




            public void Delete(int id)            //Upadate single records
            {
                tbl_Guide Guide = db.tbl_Guide.Find(id);

                db.tbl_Guide.Remove(Guide);

                save();

            }



            //SAVE FUNTIONALITY

            public void save()
            {
                db.SaveChanges();
            }



        
    }
}
