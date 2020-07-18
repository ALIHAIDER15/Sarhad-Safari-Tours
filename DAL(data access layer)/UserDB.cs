using BOL_business_object_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_data_access_layer_
{

    public class UserDB
    {
        WebAppEntities db  = new WebAppEntities();



     




        //CRUD OPERATIONS

        public List<tbl_user> GetAll()              //get all records
        {
            return db.tbl_user.ToList();
        }



        public tbl_user GetById(int id)            //get single records
        {
            return db.tbl_user.Find(id);
        }



        public void Insert(tbl_user obj)            //Insert single records
        {
            db.tbl_user.Add(obj);

            save();
        }




        public void Upadate(tbl_user obj)            //Upadate single records
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;

            save();
        }




        public void Delete(tbl_user obj)            //Upadate single records
        {
            tbl_user user = db.tbl_user.Find(obj);

            db.tbl_user.Remove(user);

            save();

        }












        //LOGIN FUNCTIONALITY

        public int Login(tbl_user obj)            //Login and only getting number of user
        {
          int count =   db.tbl_user.Where(item => item.Email == obj.Email && item.Password == obj.Password).Count();

            return count;
        }




        public tbl_user GettingUser(tbl_user obj)            //Login and only getting number of user
        {
            tbl_user user = db.tbl_user.Where(item => item.Email == obj.Email && item.Password == obj.Password).FirstOrDefault();

            return user;
        }



        public List<tbl_city> GeetingCities()            //Login and only getting number of user
        {
            var cities = db.tbl_city.ToList();

            return cities;
        }









        //SEARCH FUNCTIONALITY
        public List<tbl_user> SearchFunction(string search)            //Login and only getting number of user
        {

            var AllRecord = db.tbl_user.Where(table => table.Name.Contains(search)).ToList();

            return AllRecord;
        }












        //ASSENDING DESADNIG AND SORTING SECTION


        public List<tbl_user> GetAllRecordByAssByName()            //Sorting by name in assending
        {

            var AllRecord = db.tbl_user.OrderBy(table => table.Name).ToList();

            return AllRecord;
        }




        public List<tbl_user> GetAllRecordByDessByName()            //Sorting by name in desssending
        {

            var AllRecord = db.tbl_user.OrderByDescending(table => table.Name).ToList();

            return AllRecord;
        }




        public List<tbl_user> GetAllRecordByAssByEmail()            //Sorting by Email in assendingr
        {

            var AllRecord = db.tbl_user.OrderBy(table => table.Email).ToList();

            return AllRecord;
        }




        public List<tbl_user> GetAllRecordByDessByEmail()            //Sorting by Email in desssending
        {

            var AllRecord = db.tbl_user.OrderBy(table => table.Email).ToList();

            return AllRecord;
        }












        //SAVE FUNTIONALITY

        public void save()
        {
            db.SaveChanges();
        }


 
    
    } 

}



