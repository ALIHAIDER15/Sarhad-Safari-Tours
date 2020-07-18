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

            //CRUD OPERATIONS

            public List<tbl_MakeMyTrip> GetAll()              //get all records
            {
                return db.tbl_MakeMyTrip.ToList();
            }



            public void Insert(tbl_MakeMyTrip obj)            //Insert single records
            {
                db.tbl_MakeMyTrip.Add(obj);

                save();


            }



            public void Delete(int id)            //Delete single records
            {

                tbl_MakeMyTrip Trip = db.tbl_MakeMyTrip.Find(id);
                db.tbl_MakeMyTrip.Remove(Trip);

                save();

            }



            //SAVE FUNTIONALITY

            public void save()
            {
                db.SaveChanges();
            }



        






        





    }
}
