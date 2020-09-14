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


            ////SQL LIKE QUERY EXPRSSSION METHOD 
            ////raneg varibale (tbl_Hotels )
            //var A = from tbl_Hotels in db.tbl_Hotels where tbl_Hotels.ID == 1 select tbl_Hotels;


            ////Lambda EXPRSSSION METHOD      
            //var B = db.tbl_Hotels.Where(x => x.ID == 1).Select(x => x.ID); 



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


        public string GetByIdForName(int id)            //get single records for names
        {


            string Name = db.tbl_Hotels.Where(item => item.ID == id).Select(item => item.Name).SingleOrDefault();


            return Name;
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




        // GETTING DATA WITH LINQ USING JOINS ....



        //all record 1 image for main user page
        public List<Hotle_Images_Custom_Model> GetAllWithImages()                                  //get all records With images
        {


            return (from H in db.tbl_Hotels

                    join img in db.tbl_Hotel_images on H.ID equals img.Hotel_ID

                    let p = db.tbl_Hotel_images.Where(i => i.Hotel_ID == H.ID).Select(x => x.ID).FirstOrDefault()

                    where img.ID == p
                    select new Hotle_Images_Custom_Model()
                    {
                        ID=H.ID,
                        Name=H.Name,
                        Location = H.Location,
                        Gov_License = H.Gov_License,
                        Standard = H.Standard,                     
                        ImagePath =img.ImagePath                 

                    }).ToList();



            //Above statement sql queery
            //select* from tbl_Hotels as AD INNER JOIN tbl_Hotel_images as Img on AD.ID = Img.Hotel_ID
            //WHERE Img.ID = (select top 1  M.id from tbl_Hotel_images as M where M.Hotel_ID = Img.Hotel_ID order by M.ID asc  ) 


      


            //var a = db.tbl_Hotels.Join(db.tbl_Hotel_images,        
            //e => e.ID, d => d.ID, (tbl_Hotels, tbl_Hotel_images) => new
            //{
            //    ID = tbl_Hotels.ID,
            //    Name = tbl_Hotels.Name,
            //    Location = tbl_Hotels.Location,
            //    Gov_License = tbl_Hotels.Gov_License,
            //    Standard = tbl_Hotels.Standard,
            //    Charges = tbl_Hotels.Charges,
            //    ImagePath = tbl_Hotel_images.ImagePath         
            //});



            ////LINQ QUERY  METHOD 
            ////raneg varibale (tbl_Hotels )
            //var A = from tbl_Hotels in db.tbl_Hotels where tbl_Hotels.ID == 1 select tbl_Hotels;

            ////Lambda EXPRSSSION METHOD      
            //var B = db.tbl_Hotels.Where(x => x.ID == 1).Select(x => x.ID); 



        }





        //1 reocrd all images for detail page
        public List<Hotle_Images_Custom_Model> GetByIdWithImages(int id)                              //get single records With images
        {

            return (from H in db.tbl_Hotels

                    join img in db.tbl_Hotel_images on H.ID equals img.Hotel_ID

                    where H.ID == id

                    select new Hotle_Images_Custom_Model()
                    {


                        ID = H.ID,
                        Name = H.Name,
                        Location = H.Location,
                        Gov_License = H.Gov_License,
                        Standard = H.Standard,
                        Charges = H.Charges,
                        ImagePath = img.ImagePath,


                    }).ToList();



        }





        //all record all image for admin pannel
        public List<Hotle_Images_Custom_Model> GetAllWithAllImages()                                  //get all records With images
        {
            

            return (from H in db.tbl_Hotels

                    join img in db.tbl_Hotel_images on H.ID equals img.Hotel_ID

                  

                    select new Hotle_Images_Custom_Model()
                    {


                        ID = H.ID,
                        Name = H.Name,
                        Location = H.Location,
                        Gov_License = H.Gov_License,
                        Standard = H.Standard,
                        Charges = H.Charges,
                        ImagePath = img.ImagePath,


                    }).ToList();


        }





        public int Upadate2(tbl_Hotels obj)            //Upadate single records
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;

            save();

            return obj.ID;
        }


        //SAVE FUNTIONALITY

        public void save()
        {
            db.SaveChanges();
        }




    }





}
