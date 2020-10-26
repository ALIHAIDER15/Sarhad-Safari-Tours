using BOL_business_object_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_data_access_layer_
{
    public class ItemsDB
    {



            WebAppEntities db = new WebAppEntities();


        //itmeModelForCheckBox ItmeModel_Obj = new itmeModelForCheckBox();

        //CRUD OPERATIONS

        public List<tbl_Items> GetAll()              //get all records
        {
            return db.tbl_Items.ToList();
        }

        public tbl_Items GetById(int id)            //get single records
            {
                tbl_Items Item = db.tbl_Items.Find(id);

                return Item;
            }




            public int Insert(tbl_Items obj)            //Insert single records
            {
                db.tbl_Items.Add(obj);

                save();

                int Id = obj.ID;

                return Id;



            }




            public void Upadate(tbl_Items obj)            //Upadate single records
            {
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;

                save();
            }




            public void Delete(int id)            //Upadate single records
            {
                tbl_Items Item = db.tbl_Items.Find(id);

                db.tbl_Items.Remove(Item);

                save();

            }




             public string GetByIdForName(int id)            //get single records for names
             {


              string Name = db.tbl_Items.Where(item => item.ID == id).Select(item => item.Name).SingleOrDefault();
             
             
              return Name;
             }

          
        //     public List<tbl_Items> CheckBoxList()            //get single records for names
        //{

        //    //return ItmeModel_Obj.items = db.tbl_Items.ToList<tbl_Items>();


        //}






              //SAVE FUNTIONALITY

                public void save()
            {
                db.SaveChanges();
            }
           



        

    }
}
