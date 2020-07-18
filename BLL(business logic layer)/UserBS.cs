using BOL_business_object_layer_;
using DAL_data_access_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BLL_business_logic_layer_
{

    public class UserDb
    {



        UserDB ObjDB = new UserDB();



     

        public List<tbl_user> GetAll()             //get all records
        {
            return ObjDB.GetAll();


        }





        public tbl_user GetById(int id)            //get single records
        {
            return ObjDB.GetById(id);
        }




        public void Insert(tbl_user obj)            //Insert single records
        {
            ObjDB.Insert(obj);


        }




        public void Upadate(tbl_user obj)            //Upadate single records
        {
            ObjDB.Upadate(obj);


        }




        public void Delete(tbl_user obj)            //dELETE single records
        {
            ObjDB.Delete(obj);



        }



        public int Login(tbl_user obj)            //Login
        {

            int count = ObjDB.Login(obj);



            return count;

        }


        public tbl_user GettingUser(tbl_user obj)            //Login and only getting number of user
        {

            tbl_user user = ObjDB.GettingUser(obj);

            return user;
        }


        public List<tbl_city> GeetingCities()            //Login and only getting number of user
        {
            var cities = ObjDB.GeetingCities();

            return cities;
        }



        public List<tbl_user> SearchFunction(string search)            //Login and only getting number of user
        {

            var AllRecord = ObjDB.SearchFunction(search);


            return AllRecord;
        }






        //ASSENDING DESADNIG AND SORTING SECTION

        public List<tbl_user> GetAllRecordByAssByName()            //Login and only getting number of user
        {

         var AllRecord =  ObjDB.GetAllRecordByAssByName();

            return AllRecord;
        }




        public List<tbl_user> GetAllRecordByDessByName()            //Login and only getting number of user
        {

            var AllRecord = ObjDB.GetAllRecordByDessByName();

            return AllRecord;
        }




        public List<tbl_user> GetAllRecordByAssByEmail()            //Sorting by Email in assendingr
        {

            var AllRecord = ObjDB.GetAllRecordByAssByEmail();

            return AllRecord;
        }




        public List<tbl_user> GetAllRecordByDessByEmail()            //Sorting by Email in desssending
        {

            var AllRecord = ObjDB.GetAllRecordByDessByEmail();

            return AllRecord;
        }

    }
}