using BOL_business_object_layer_;
using DAL_data_access_layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_business_logic_layer_
{
    public class CommonModalBLL
    {

        UserDB USer_ObjDB = new UserDB();

        AdminSecurityDB Admin_ObjDb = new AdminSecurityDB();




        public void Insert(tbl_user obj)            //Insert single records
        {
            USer_ObjDB.Insert(obj);


        }


        public void Insert_Admin(tbl_Admin obj)
        {

            Admin_ObjDb.Insert(obj);






        }

    }
}
