using BOL_business_object_layer_;
using DAL_data_access_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_business_logic_layer_
{
    public class CityBS
    {

        CityDB   ObjDB = new CityDB();

    

      


        public IEnumerable<tbl_city> GetAll()     //get all records
        {
            return ObjDB.GetAll();
        }





        public tbl_city GetById(int id)            //get single records
        {
            return ObjDB.GetById(id);
        }




        public void Insert(tbl_city obj)            //Insert single records
        {
            ObjDB.Insert(obj);


        }




        public void Upadate(tbl_city obj)            //Upadate single records
        {
            ObjDB.Upadate(obj);


        }




        public void Delete(tbl_city obj)            //Upadate single records
        {
            ObjDB.Delete(obj);



        }

    }
}
