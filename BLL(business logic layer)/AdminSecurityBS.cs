using BOL_business_object_layer_;
using DAL_data_access_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_business_logic_layer_
{
    public  class AdminSecurityBS
    {

        AdminSecurityDB objDB = new AdminSecurityDB();









        //CRUD OPERATIONS

        public List<tbl_Admin> GetAll()              //get all records
        {
            return objDB.GetAll();
        }



        public tbl_Admin GetById(int id)            //get single records
        {
            return objDB.GetById( id);
        }



        public int Insert(tbl_Admin obj)            //Insert single records
        {
           int Id = objDB.Insert( obj);

            return Id;
        }




        public void Upadate(tbl_Admin obj)            //Upadate single records
        {
            objDB.Upadate(obj);

        }




        public void Delete(tbl_user obj)            //Upadate single recordsm
        {
            objDB.Delete(obj);

       

        }














        //LOGIN FUNCTIONALITY

        public int Login(tbl_Admin obj)                               //Login and only getting number of user
        {

           return  objDB.Login(obj);

        

        }




        public tbl_Admin LoginGettingUser(tbl_Admin obj)            //Login and only getting number of user
        {

            return objDB.LoginGettingUser(obj);

         
        }



    }
}
