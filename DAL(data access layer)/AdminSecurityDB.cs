using BOL_business_object_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_data_access_layer_
{
    public class AdminSecurityDB
    {

        WebAppEntities db = new WebAppEntities();



        //CRUD OPERATIONS

        public List<tbl_Admin> GetAll()              //get all records
        {
            return db.tbl_Admin.ToList();
        }



        public tbl_Admin GetById(int id)            //get single records
        {
             tbl_Admin admin = db.tbl_Admin.Find(id);

            return admin;
        }




        public int Insert(tbl_Admin obj)            //Insert single records
        {
            db.tbl_Admin.Add(obj);

            save();

            int Id = obj.ID;

            return Id;



        }




        public void Upadate(tbl_Admin obj)            //Upadate single records
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;

            save();
        }




        public void Delete(int id)            //Upadate single records
        {
            tbl_Admin admin = db.tbl_Admin.Find(id);

            db.tbl_Admin.Remove(admin);

            save();

        }








        //LOGIN FUNCTIONALITY

        public int Login(tbl_Admin obj)            //Login and only getting number of user
        {
            int count = db.tbl_Admin.Where(item => item.Email == obj.Email && item.Password == obj.Password).Count();

            return count;
        }




        public tbl_Admin LoginGettingUser(tbl_Admin obj)            //Login and only getting number of user
        {
            tbl_Admin user = db.tbl_Admin.Where(item => item.Email == obj.Email && item.Password == obj.Password).FirstOrDefault();

            return user;
        }






        //SAVE FUNTIONALITY

        public void save()
        {
            db.SaveChanges();
        }



    }
}
