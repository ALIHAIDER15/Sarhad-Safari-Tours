using BOL_business_object_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_data_access_layer_
{
    public class MyTripDB
    {
      
            WebAppEntities db = new WebAppEntities();

            tbl_MakeMyTrip tbl_Obj = new tbl_MakeMyTrip();



        //CRUD OPERATIONS

        public List<tbl_MakeMyTrip> GetAll()              //get all records
            {
                return db.tbl_MakeMyTrip.ToList();
            }

        public tbl_MakeMyTrip GetById(int id)                  //get single records
        {
            tbl_MakeMyTrip Trip = db.tbl_MakeMyTrip.Find(id);

            return Trip;
        }

        public void Insert(tbl_MakeMyTrip obj)            //Insert single records
            {
                db.tbl_MakeMyTrip.Add(obj);

                save();


            }


        public void Delete(int id)                        //Delete single records
            {

                tbl_MakeMyTrip Trip = db.tbl_MakeMyTrip.Find(id);
                db.tbl_MakeMyTrip.Remove(Trip);

                save();

            }

        public tbl_MakeMyTrip GettigUserDataForEmail (int id)                        //Delete single records
        {

            //var data = db.Package_Confirmation_Email1(id);
         

            tbl_MakeMyTrip Trip = new tbl_MakeMyTrip();


            return Trip;



        }
        //public List<tbl_Items> CheckBoxList()            //get single records for names
        //{

        //    //return tbl_Obj.itemsCheckBoxList =  db.tbl_Items.ToList<itemsCheckBoxList>();


        //}



        //SAVE FUNTIONALITY

        public void save()
            {
                db.SaveChanges();
            }
          
          

        






        





    }
}
