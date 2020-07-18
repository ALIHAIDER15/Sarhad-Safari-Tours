using BOL_business_object_layer_;
using DAL_data_access_layer_;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UI_user_interface__.Areas.Security.Controllers
{
    public class SecurityController : Controller
    {


        // OBJECT OF CUSTOM MODEL
        //MyCustomModelsUi MyCustomModelsUi_obj = new MyCustomModelsUi();



        UserDB UserDB_Obj = new UserDB();





        // GET: Security/Security
        public ActionResult Index()
        {
            return View();
        }







        [AllowAnonymous]
        public ActionResult Login()
        {

            return View();

        }



        [HttpPost, AllowAnonymous]
        public ActionResult Login(tbl_user UserObj)
        {





            var user = UserDB_Obj.Login(UserObj);


            if (user > 0)
            {

                FormsAuthentication.SetAuthCookie(UserObj.Email, false);


                //YE LINE USER KA NAME LE KAR NAVBAR MAI DISPLAY KARAY GI AFTER LOGINED

                //VIEW BAG VIEW MAT DETA LAY JATA HAI BUT LAYOUT PAGE MAI NE IS LEYE HAMNE TempData USE KIA HAI

                //seassion variable say jab tak banda rahta hai login data para rtha hai jb k view or tem mai aisa ni


                var obj = UserDB_Obj.GettingUser(UserObj);

                Session["Name"] = obj.Name;

                return RedirectToAction("Index", "Comman", new { area = "Comman" });

            }

            //else

            else
            {

                return View();
            }
           

        }







        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Security", new { area = "Security" });
        }









        [HttpGet, AllowAnonymous]
        public ActionResult Register()
        {



            var Cities = UserDB_Obj.GeetingCities();

            ViewBag.city = new SelectList(Cities, "CityId", "CityName");



            //view bag wala tarika

            return View();

        }



        //[HttpPost]
        //public ActionResult Register(MyCustomModelsUi objUI, string Csharp, string java, string Python )
        //{

           


        //    //if (ModelState.IsValid && (Csharp == "true" || java == "true" || Python == "true"))
        //    //{

        //    //    objUI.MyUser.Csharp = (Csharp == "true") ? true : false;

        //    //    objUI.MyUser.Java = (java == "true") ? true : false;


        //    //    objUI.MyUser.Python = (Python == "true") ? true : false;



        //        //if (Csharp == "true")
        //        //{

        //        //    obj.Csharp = true;

        //        //}
        //        //else
        //        //{

        //        //    obj.Csharp = false;

        //        //}

        //        //if (java == "true")
        //        //{

        //        //    obj.Java = true;

        //        //}
        //        //else
        //        //{

        //        //    obj.Java = false;

        //        //}

        //        //if (Python == "true")
        //        //{

        //        //    obj.Python = true;

        //        //}
        //        //else
        //        //{

        //        //    obj.Python = false;

        //        //}

        //        if (objUI.UserImageFiles != null)
        //        {

        //            //image name lay rai hn
        //            string fileName = Path.GetFileNameWithoutExtension(objUI.UserImageFiles.FileName);

        //            //image extension
        //            string Extension = Path.GetExtension(objUI.UserImageFiles.FileName);

        //            //unique name
        //            fileName = fileName + DateTime.Now.ToString("yymmssff") + Extension;

        //            //saving path to db
        //            objUI.MyUser.ImagePath = "/images/" + fileName;

          

          
        //      //C: \Users\adasd\Desktop\visual studio\TourAgencyProject\UI(user interface )\imgaes
        //      //creating path from computer path + file name
        //      fileName = Path.Combine(Server.MapPath("~/images/"),fileName);

        //            //obj.userimageFile mai jo image a rai hai usko save kr do folder mai
        //            objUI.UserImageFiles.SaveAs(fileName);


        //        //}




        //        TempData["success"] = "Regisstraion SuccessFull";


        //        //objBS.Insert(obj);






        //        return RedirectToAction("Register", "Security", new { area = "Security" });



        //    }

        //    else

        //    {
        //        if (Csharp == "false" && java == "false" && Python == "false")
        //        {

        //            TempData["CheckBoxError"] = "Plesae Check Alteast One box";


        //        }



        //        //sendging dropdownlist to Post regiter view q k pahle get regiter k view ko send ki thi
        //        //or ab post walay ko knri hai warna error ai ga (view dono ka aik hai but data dono apna apna send krty han)
               
        //        var Cities = UserDB_Obj.GeetingCities();

        //        ViewBag.city = new SelectList(Cities, "CityId", "CityName");

        //        return View();

        //    }

        //}


       

    }
}

