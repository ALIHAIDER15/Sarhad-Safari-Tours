using BOL_business_object_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_data_access_layer_
{
    
    public class MemberShipDB
    {

        WebAppEntities db = new WebAppEntities();







        //CRUD OPERATIONS

        public List<tbl_MemberShip> GetAll()              //get all records
        {
            return db.tbl_MemberShip.ToList();
        }



        public tbl_MemberShip GetById(int id)            //get single records
        {
            tbl_MemberShip MemberShip = db.tbl_MemberShip.Find(id);

            return MemberShip;
        }




        public int Insert(tbl_MemberShip obj)            //Insert single records
        {
            db.tbl_MemberShip.Add(obj);

            save();

            int Id = obj.ID;

            return Id;



        }




        public void Upadate(tbl_MemberShip obj)            //Upadate single records
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;

            save();
        }




        public void Delete(int id)            //Upadate single records
        {
            tbl_MemberShip MemberShip = db.tbl_MemberShip.Find(id);

            db.tbl_MemberShip.Remove(MemberShip);

            save();

        }






        //SAVE FUNTIONALITY

        public void save()
        {
            db.SaveChanges();
        }



    }
}
