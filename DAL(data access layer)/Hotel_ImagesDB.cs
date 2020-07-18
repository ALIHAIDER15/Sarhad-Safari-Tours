using BOL_business_object_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_data_access_layer_
{
    public class Hotel_ImagesDB
    {
        

            WebAppEntities db = new WebAppEntities();



            //CRUD OPERATIONS

            public List<tbl_Hotel_images> GetAll()              //get all records
            {
                return db.tbl_Hotel_images.ToList();
            }



            public tbl_Hotel_images GetById(int id)            //get single records
            {
                tbl_Hotel_images Hotel_images = db.tbl_Hotel_images.Find(id);

                return Hotel_images;
            }




            public int Insert(tbl_Hotel_images obj)            //Insert single records
            {
                db.tbl_Hotel_images.Add(obj);

                save();

                int Id = obj.ID;

                return Id;



            }




            public void Upadate(tbl_Hotel_images obj)            //Upadate single records
            {
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;

                save();
            }




            public void Delete(int id)            //Upadate single records
            {
                tbl_Hotel_images Hotel_images = db.tbl_Hotel_images.Find(id);

                db.tbl_Hotel_images.Remove(Hotel_images);

                save();

            }



            //SAVE FUNTIONALITY

            public void save()
            {
                db.SaveChanges();
            }




        
    }
}
