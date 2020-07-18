Using BOL_business_object_layer_;
Using DAL_data_access_layer_;
Using DAL_data_access_layer_;
Using Mixed_Models;
Using System;
Using System.Collections.Generic;
Using System.Linq;
Using System.Text;
Using System.Threading.Tasks;


Namespace Mapping_Models
{
    Public Class Common_Mapping_model
    {

        AdminCustomModel AdminCustomMode_Obj = New AdminCustomModel();

        AdminCustomMode_Obj.UserImageFiles

        //UserDB UserDB_Obj = New UserDB();

        AdminSecurityDB AdminSecurityDB_Obj = New AdminSecurityDB();




        //public void Insert_User(MyCustomModelsUi model)
        //{

        //    tbl_user user = model.MyUser;

        //    user.CityId = model.MyCity.CityId;

        //    //tbl_city city = model.MyCity;


        //    UserDB_Obj.Insert(user);


        //}



        Public void Insert_Admin(AdminCustomMode_Obj model)
        {

            tbl_Admin admin = model.Admin;


            AdminSecurityDB_Obj.Insert(admin);



        }


    }
}
