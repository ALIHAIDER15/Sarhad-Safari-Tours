using BOL_business_object_layer_;
using DAL_data_access_layer_;
using Mapping_Models;
using Mixed_Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Mail;


namespace UI_user_interface__.Areas.Admin.Controllers
{


    public class AdminController : Controller
    {


        ////User section db ka object
        UserDB UserDB_OBJ = new UserDB();



        //ContactUs for admin section db ka object
        ContactUsDB ContactusDB_OBJ = new ContactUsDB();


        //Admin section ka object
        AdminSecurityDB SecurityDB_OBJ = new AdminSecurityDB();




        //PackagesDB  ka object
        PackagesDB PackagesDB_Obj = new PackagesDB();


        //MyTripDB  ka object
        MyTripDB MyTrip_Obj = new MyTripDB();

        //ye db ka object hai is ko nahe banana controller mai never
        //tbl_Admin TBL_ADMINOJB = new tbl_Admin();

        //MemberShipDB  ka object
        MemberShipDB Membership_Obj = new MemberShipDB();

        //GuideDB  ka object
        GuideDB GuideDB_Obj = new GuideDB();


        //HotelsDB  ka object
        HotelsDB Hotels_Obj = new HotelsDB();

        //Hotel_ImagesDB  ka object
        Hotel_ImagesDB Hotel_ImagesDB_Obj = new Hotel_ImagesDB();




        //Mixed model  mai AdminCustomModel  ka object
        AdminCustomModel AdminCustomModel_Obj = new AdminCustomModel();


        //Mixed model  mai PackagesCustomModel  ka object
        PackagesCustomModel packagesCustomModel_Obj = new PackagesCustomModel();



        //Mixed model  mai PackagesCustomModel  ka object
        GuideCustomModel GuideCustomModel_Obj = new GuideCustomModel();


        //Mixed model  mai HotelsCustomModel  ka object
        HotelsCustomModel HotelsCustomModel_Obj = new HotelsCustomModel();


        //Mixed model  mai Hotel_imagesCustomModel  ka object
        Hotel_imagesCustomModel Hotel_imagesCustomModel_Obj = new Hotel_imagesCustomModel();


        // Common_Mapping_model jahan mixed model mapp hotay hn us ka object
        Common_Mapping_model Common_Mapping_model_obj = new Common_Mapping_model();

        // tbl_MakeMyTrip  ka object
        tbl_MakeMyTrip tbl_MakeMyTrip_Obj = new tbl_MakeMyTrip();

        // ItemsDB  ka object
        ItemsDB ItemsDB_Obj = new ItemsDB();


        Hotle_Images_Custom_Model hotle_Images_Custom_Model_Obj = new Hotle_Images_Custom_Model();

        Hotle_Images_Custom_Model2 hotle_Images_Custom_Model2_Obj = new Hotle_Images_Custom_Model2();



        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }































        //Packages SECTION FUNCTIOANLITY 
        [HttpGet]
        public ActionResult CurrentPackage()
        {

            var PackagesList = PackagesDB_Obj.GetAll();
            return View(PackagesList);
        }



        [HttpGet]
        public ActionResult AddPackage()
        {


            return View();
        }




        [HttpPost]
        public ActionResult AddPackage(PackagesCustomModel packageCM_Obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    if (packageCM_Obj.UserImageFiles != null)
                    {

                        //image name lay rai hn
                        string fileName = Path.GetFileNameWithoutExtension(packageCM_Obj.UserImageFiles.FileName);

                        //image extension
                        string Extension = Path.GetExtension(packageCM_Obj.UserImageFiles.FileName);

                        //unique name
                        fileName = fileName + DateTime.Now.ToString("yymmssff") + Extension;

                        //saving path to db
                        packageCM_Obj.Packages.ImagePath = "/images/" + fileName;


                        //creating path from computer path + file name
                        fileName = Path.Combine(Server.MapPath("/images/"), fileName);

                        //obj.userimageFile mai jo image a rai hai usko save kr do folder mai
                        packageCM_Obj.UserImageFiles.SaveAs(fileName);


                    }

                    else if (packageCM_Obj.Packages.ImagePath == null)
                    {

                        packageCM_Obj.Packages.ImagePath = "/images/No_Image_Available.jpg";

                    }



                    int id = Common_Mapping_model_obj.Insert_Package(packageCM_Obj);


                    if (id > 0)
                    {

                        TempData["Package_added"] = "Package added Successfully";

                    }


                }

            }
            catch (Exception e)
            {
                TempData["Package_not_added"] = "There Is A Prabblem In Adding New Package" + e.Message;

            }



            return RedirectToAction("AddPackage", "Admin", new { area = "Admin" });

        }




        [HttpGet]
        public ActionResult DeletePackage(int Packages_Id)
        {
            PackagesDB_Obj.Delete(Packages_Id);

            TempData["Packages_Delete"] = "Packages successfully deleted";

            return RedirectToAction("CurrentPackage", "Admin");
        }





        [HttpGet]
        public ActionResult EditPackage(int Packages_Id)
        {
            var Package = PackagesDB_Obj.GetById(Packages_Id);

            if (Package.ImagePath == null)
            {
                Package.ImagePath = "/images/No_Image_Available.jpg";
            }

            packagesCustomModel_Obj.Packages = Package;

            return View(packagesCustomModel_Obj);

        }



        [HttpPost]
        public ActionResult EditPackage(PackagesCustomModel Package_OBJ)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (Package_OBJ.UserImageFiles != null)
                    {

                        //image name lay rai hn
                        string fileName = Path.GetFileNameWithoutExtension(Package_OBJ.UserImageFiles.FileName);

                        //image extension
                        string Extension = Path.GetExtension(Package_OBJ.UserImageFiles.FileName);

                        //unique name
                        fileName = fileName + DateTime.Now.ToString("yymmssff") + Extension;

                        //saving path to db
                        Package_OBJ.Packages.ImagePath = "/images/" + fileName;


                        //creating path from computer path + file name
                        fileName = Path.Combine(Server.MapPath("/images/"), fileName);

                        //obj.userimageFile mai jo image a rai hai usko save kr do folder mai
                        Package_OBJ.UserImageFiles.SaveAs(fileName);


                    }

                    if (Package_OBJ.Packages.ImagePath == null)
                    {

                        Package_OBJ.Packages.ImagePath = "/images/No_Image_Available.jpg";

                    }


                    Common_Mapping_model_obj.Update_Package(Package_OBJ);



                    TempData["Recored_Edited"] = "REOCORD EDITED SUCCESSFULLY";
                }
            }
            catch (Exception e)
            {
                TempData["Recored_Edited-error"] = "REOCORD IS NOT EDITED " + e.Message;

            }



            return RedirectToAction("EditPackage", new { Packages_Id = Package_OBJ.Packages.ID });



        }










        //Membership SECTION FUNCTIOANLITY 

        [HttpGet]
        public ActionResult CurrentMemebership()
        {

            var MemebershipList = Membership_Obj.GetAll();

            return View(MemebershipList);

        }





        [HttpGet]
        public ActionResult AddMemebership()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AddMemebership(tbl_MemberShip tblMember_Obj)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    int id = Membership_Obj.Insert(tblMember_Obj);
                    //is code ki zarort ni wasie , Exception iska kam kr rai hai 
                    if (id > 0)
                    {
                        TempData["Memebership_added"] = "Memebership_added added Successfully";

                        return View();
                    }
                }
                else
                {
                    return View();

                }

                return View();
            }
            catch (Exception e)
            {

                TempData["Memebership_added"] = "There Is A Prabblem In Adding New Memebership_added" + e.Message;

                return View();


            }



        }





        [HttpGet]
        public ActionResult DeleteMemebership(int Memebership_Id)
        {
            Membership_Obj.Delete(Memebership_Id);

            TempData["Memebership_Delete"] = "Memebership successfully deleted";

            return RedirectToAction("CurrentMemebership", "Admin");
        }




        [HttpGet]
        public ActionResult EditMemebership(int Memebership_Id)
        {

            var Memebership = Membership_Obj.GetById(Memebership_Id);


            return View(Memebership);

        }




        [HttpPost]

        public ActionResult EditMemebership(tbl_MemberShip tblMember_Obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Membership_Obj.Upadate(tblMember_Obj);


                    TempData["Recored_Edited"] = "REOCORD EDITED SUCCESSFULLY";
                }

            }
            catch (Exception e)
            {

                TempData["Recored_Edited"] = "REOCORD EDITED SUCCESSFULLY" + e.Message;
            }


            return RedirectToAction("EditMemebership", new { Memebership_Id = tblMember_Obj.ID });



        }














        //PackageRequests  SECTION FUNCTIOANLITY 
        [HttpGet]
        public ActionResult PackageRequests()
        {
            var trip_Obj = MyTrip_Obj.GetAll();


            //fetching item name (from package table) againt package id () to display in package request table
            for (int k = 0; k < trip_Obj.Count(); k++)
            {
                int id = Convert.ToInt32(trip_Obj[k].Item_ID);
                string ItemName = ItemsDB_Obj.GetByIdForName(id);

                trip_Obj[k].ItemName = ItemName;

            }


            //fetching package name (from package table) againt package id () to display in package request table
            for (int k = 0; k < trip_Obj.Count(); k++)
            {
                int id = Convert.ToInt32(trip_Obj[k].Package_ID);
                string PackageName = PackagesDB_Obj.GetByIdForName(id);

                trip_Obj[k].PackageName = PackageName;

            }



            //fetching package name (from package table) againt package id () to display in package request table
            for (int k = 0; k < trip_Obj.Count(); k++)
            {
                int id = Convert.ToInt32(trip_Obj[k].Hotel_ID);
                string HotelName = Hotels_Obj.GetByIdForName(id);

                trip_Obj[k].HotelName = HotelName;

            }


            //fetching package name (from package table) againt package id () to display in package request table
            for (int k = 0; k < trip_Obj.Count(); k++)
            {
                int id = Convert.ToInt32(trip_Obj[k].Guide_ID);
                string GuideName = GuideDB_Obj.GetByIdForName(id);

                trip_Obj[k].GuideName = GuideName;

            }


            return View(trip_Obj);
        }


        [HttpGet]
        public ActionResult DeletePackageRequests(int id)
        {
            MyTrip_Obj.Delete(id);

            TempData["Delete"] = "Record Deleted  SuccessFully";

            return RedirectToAction("PackageRequests");


        }

        [HttpGet]
        public ActionResult ConfirmPackageRequests(int id)
        {
            var Confrim = MyTrip_Obj.GetById(id);

            int Package_ID = Convert.ToInt32(Confrim.Package_ID);
            int Hotel_ID = Convert.ToInt32(Confrim.Hotel_ID);
            int Guide_ID = Convert.ToInt32(Confrim.Guide_ID);

            string Packages_Name = PackagesDB_Obj.GetByIdForName(Package_ID);
            string Hotel_Name = Hotels_Obj.GetByIdForName(Hotel_ID);
            string Guide_Name = GuideDB_Obj.GetByIdForName(Guide_ID);

            //var Confrim2 =  MyTrip_Obj.GettigUserDataForEmail(id);

            //SENDING EMAIL TO CUSTOMER , sending emails using gmail you have to turn on => allow less sucre app to access this mail
            string from = "alihaiderwm15@gmail.com";
            string to = "alihaiderwm15@gmail.com"; /*= Confrim.Email*/
            MailMessage MailMessage = new MailMessage(from, to);
            MailMessage.Subject = "Package Booking Confirmed ";

            MailMessage.Body = "Thank You , Your Booking Has Been Confirmed" + Environment.NewLine + "Your Booking Details" + Environment.NewLine +
                                "Package  :" + Packages_Name + Environment.NewLine +
                                "Hotel  :" + Hotel_Name + Environment.NewLine +
                                "Guider :" + Guide_Name + Environment.NewLine +
                                "From :" + Confrim.From + Environment.NewLine +
                                 "To :" + Confrim.To + Environment.NewLine +
                                 "Adult :" + Confrim.Adults + Environment.NewLine +
                                 "Child :" + Confrim.Child + Environment.NewLine +
                                 "" + Environment.NewLine + "IF YOU WANT TO CHANGE OR CANNCEL THE BOOKING KINDLY CONTACT AT THIS NUMBER 03319186108.";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(MailMessage);

            TempData["Email-Sent"] = "Emial Has   SuccessFully Sent To Customer";

            return RedirectToAction("PackageRequests");


        }


























        //CONTACT US SECTION FUNCTIOANLITY 

        [HttpGet]
        public ActionResult ContactUs()
        {
            var USerContactUs = ContactusDB_OBJ.GetAll();

            return View(USerContactUs);
        }

        [HttpGet]
        public ActionResult ContactUsDeleteRecord(int id)
        {
            ContactusDB_OBJ.Delete(id);

            TempData["Delete"] = "Record Deleted  SuccessFully";

            return RedirectToAction("ContactUs");
        }

















        //ADMINS SEETTING AND PAGIES



        [HttpGet, AllowAnonymous]
        public ActionResult AdminLogin()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult AdminLogin(tbl_Admin Admin_OBJ)
        {
            var Count = SecurityDB_OBJ.Login(Admin_OBJ);

            if (Count > 0)
            {
                FormsAuthentication.SetAuthCookie(Admin_OBJ.Email, false);

                var obj = SecurityDB_OBJ.LoginGettingUser(Admin_OBJ);


                Session["User_Id"] = obj.ID;

                Session["Name"] = obj.Name;

                Session["Image"] = obj.ImagePath;

                return RedirectToAction("Index", "Admin", new { area = "Admin" });

            }

            TempData["LoginFailed"] = "Email or Password is incorrect";

            return View();
        }



        [HttpGet]
        public ActionResult AdminProfile()
        {
            int Id = Int32.Parse(Session["User_Id"].ToString());

            var Admin = SecurityDB_OBJ.GetById(Id);


            return View(Admin);
        }




        [HttpGet, Authorize(Roles = "A")]
        public ActionResult AdminCreate()
        {
            return View();
        }





        [HttpPost, Authorize(Roles = "A")]
        public ActionResult AdminCreate(AdminCustomModel Admin_OBJ)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Admin_OBJ.UserImageFiles != null)
                    {

                        //image name lay rai hn
                        string fileName = Path.GetFileNameWithoutExtension(Admin_OBJ.UserImageFiles.FileName);

                        //image extension
                        string Extension = Path.GetExtension(Admin_OBJ.UserImageFiles.FileName);

                        //unique name
                        fileName = fileName + DateTime.Now.ToString("yymmssff") + Extension;

                        //saving path to db
                        Admin_OBJ.Admin.ImagePath = "/images/" + fileName;


                        //creating path from computer path + file name
                        fileName = Path.Combine(Server.MapPath("/images/"), fileName);

                        //obj.userimageFile mai jo image a rai hai usko save kr do folder mai
                        Admin_OBJ.UserImageFiles.SaveAs(fileName);


                    }

                    int id = Common_Mapping_model_obj.Insert_Admin(Admin_OBJ);

                    if (id > 0)
                    {

                        TempData["Adim_Created"] = "Role Created Successfully";

                    }
                }


            }
            catch (Exception e)
            {

                TempData["Adim_Not_Created"] = "There Is A Prabblem In Adding New Role" + e.Message;
            }



            return RedirectToAction("AdminCreate", "Admin", new { area = "Admin" });
        }




        [HttpGet, Authorize(Roles = "A")]
        public ActionResult GetAllAdmins()
        {
            var AdminsList = SecurityDB_OBJ.GetAll();
            return View(AdminsList);
        }




        [HttpGet, Authorize(Roles = "A")]
        public ActionResult AdminEdit(int id)
        {



            var AdminData = SecurityDB_OBJ.GetById(id);




            if (AdminData.ImagePath == null)
            {

                AdminData.ImagePath = "/images/No_Image_Available.jpg";

            }

            AdminCustomModel_Obj.Admin = AdminData;



            return View(AdminCustomModel_Obj);

        }



        [HttpPost, Authorize(Roles = "A")]
        public ActionResult AdminEdit(AdminCustomModel Admin_OBJ)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (Admin_OBJ.UserImageFiles != null)
                    {

                        //image name lay rai hn
                        string fileName = Path.GetFileNameWithoutExtension(Admin_OBJ.UserImageFiles.FileName);

                        //image extension
                        string Extension = Path.GetExtension(Admin_OBJ.UserImageFiles.FileName);

                        //unique name
                        fileName = fileName + DateTime.Now.ToString("yymmssff") + Extension;

                        //saving path to db
                        Admin_OBJ.Admin.ImagePath = "/images/" + fileName;


                        //creating path from computer path + file name
                        fileName = Path.Combine(Server.MapPath("/images/"), fileName);

                        //obj.userimageFile mai jo image a rai hai usko save kr do folder mai
                        Admin_OBJ.UserImageFiles.SaveAs(fileName);


                    }

                    if (Admin_OBJ.Admin.ImagePath == null)
                    {
                        Admin_OBJ.Admin.ImagePath = "/images/No_Image_Available.jpg";
                    }

                    Common_Mapping_model_obj.Update_Admin(Admin_OBJ);

                    TempData["Recored_Edited"] = "REOCORD EDITED SUCCESSFULLY";

                }

            }

            catch (Exception e)
            {


                TempData["Recored_Edited"] = "REOCORD IS NOT EDITED " + e.Message;
            }


            return RedirectToAction("AdminEdit", "Admin", new { area = "Admin" });




        }



        [HttpGet, Authorize(Roles = "A")]
        public ActionResult DeleteAdmins(int id)
        {
            SecurityDB_OBJ.Delete(id);

            TempData["Admin_Delete"] = "Record successfully deleted";

            return RedirectToAction("GetAllAdmins", "Admin");
        }








        public ActionResult AdminLogout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("AdminLogin");
        }













        //GUIDE SEETTING AND PAGIES

        [HttpGet]
        public ActionResult GuideCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuideCreate(GuideCustomModel Guide_OBJ)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (Guide_OBJ.UserImageFiles != null)
                    {

                        //image name lay rai hn
                        string fileName = Path.GetFileNameWithoutExtension(Guide_OBJ.UserImageFiles.FileName);

                        //image extension
                        string Extension = Path.GetExtension(Guide_OBJ.UserImageFiles.FileName);

                        //unique name
                        fileName = fileName + DateTime.Now.ToString("yymmssff") + Extension;

                        //saving path to db
                        Guide_OBJ.Guide.ImagePath = "/images/" + fileName;


                        //creating path from computer path + file name
                        fileName = Path.Combine(Server.MapPath("/images/"), fileName);

                        //obj.userimageFile mai jo image a rai hai usko save kr do folder mai
                        Guide_OBJ.UserImageFiles.SaveAs(fileName);


                    }
                    else if (Guide_OBJ.Guide.ImagePath == null)
                    {

                        Guide_OBJ.Guide.ImagePath = "/images/No_Image_Available.jpg";

                    }



                    int id = Common_Mapping_model_obj.Insert_Guide(Guide_OBJ);


                    if (id > 0)
                    {

                        TempData["Guide_Created"] = "Guide Created Successfully";

                    }


                }
            }
            catch (Exception e)
            {


                TempData["Guide_Not_Created"] = "There Is A Prabblem In Adding New Guide" + e.Message;
            }



            return RedirectToAction("GuideCreate", "Admin", new { area = "Admin" });
        }



        [HttpGet]
        public ActionResult CurrentGuide()
        {
            var GuideList = GuideDB_Obj.GetAll();
            return View(GuideList);
        }



        [HttpGet]
        public ActionResult EditGuide(int id)
        {



            var GuideData = GuideDB_Obj.GetById(id);




            if (GuideData.ImagePath == null)
            {

                GuideData.ImagePath = "/images/No_Image_Available.jpg";

            }

            GuideCustomModel_Obj.Guide = GuideData;



            return View(GuideCustomModel_Obj);

        }





        [HttpPost]
        public ActionResult EditGuide(GuideCustomModel Guide_OBJ)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (Guide_OBJ.UserImageFiles != null)
                    {

                        //image name lay rai hn
                        string fileName = Path.GetFileNameWithoutExtension(Guide_OBJ.UserImageFiles.FileName);

                        //image extension
                        string Extension = Path.GetExtension(Guide_OBJ.UserImageFiles.FileName);

                        //unique name
                        fileName = fileName + DateTime.Now.ToString("yymmssff") + Extension;

                        //saving path to db
                        Guide_OBJ.Guide.ImagePath = "/images/" + fileName;


                        //creating path from computer path + file name
                        fileName = Path.Combine(Server.MapPath("/images/"), fileName);

                        //obj.userimageFile mai jo image a rai hai usko save kr do folder mai
                        Guide_OBJ.UserImageFiles.SaveAs(fileName);


                    }
                    else if (Guide_OBJ.Guide.ImagePath == null)
                    {

                        Guide_OBJ.Guide.ImagePath = "/images/No_Image_Available.jpg"; ;

                    }


                    Common_Mapping_model_obj.Update_Guide(Guide_OBJ);

                    TempData["Recored_Edited"] = "REOCOR IS NOT EDITED SUCCESSFULLY";



                }
            }
            catch (Exception e)
            {

                TempData["Recored_Edited"] = "REOCOR  EDITED SUCCESSFULLY" + e.Message;
            }



            return RedirectToAction("EditGuide", "Admin", new { area = "Admin" });




        }





        [HttpGet]
        public ActionResult DeleteGuide(int id)
        {
            GuideDB_Obj.Delete(id);

            TempData["Guide_Delete"] = "Record successfully deleted";

            return RedirectToAction("CurrentGuide", "Admin");
        }



















        //Hotels SEETTING AND PAGIES

        [HttpGet]
        public ActionResult CreateHotels()
        {
            return View();
        }




        [HttpPost]
        public ActionResult CreateHotels(HotelsCustomModel Hotels_OBJ)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Hotels_OBJ.UserImageFiles != null)
                    {

                        //image name lay rai hn
                        string fileName = Path.GetFileNameWithoutExtension(Hotels_OBJ.UserImageFiles.FileName);

                        //image extension
                        string Extension = Path.GetExtension(Hotels_OBJ.UserImageFiles.FileName);

                        //unique name
                        fileName = fileName + DateTime.Now.ToString("yymmssff") + Extension;

                        //saving path to db
                        Hotels_OBJ.Hotels.ImagePath = "/images/" + fileName;


                        //creating path from computer path + file name
                        fileName = Path.Combine(Server.MapPath("/images/"), fileName);

                        //obj.userimageFile mai jo image a rai hai usko save kr do folder mai
                        Hotels_OBJ.UserImageFiles.SaveAs(fileName);


                    }
                    else if (Hotels_OBJ.Hotels.ImagePath == null)
                    {

                        Hotels_OBJ.Hotels.ImagePath = "/images/No_Image_Available.jpg";

                    }


                    int id = Common_Mapping_model_obj.Insert_hotel(Hotels_OBJ);

                    if (id > 0)
                    {
                        TempData["hotel_Created"] = "Hotel Added Successfully";
                    }

                }

            }
            catch (Exception e)
            {

                TempData["hotel_Not_Created"] = "There Is A Prabblem In Adding New Hotel" + e.Message;
            }




            return RedirectToAction("CurrentHotels", "Admin", new { area = "Admin" });
        }







        [HttpGet]
        public ActionResult CurrentHotels()
        {
            var HotelsList = Hotels_Obj.GetAll();
            return View(HotelsList);
        }





        [HttpGet]
        public ActionResult EditHotels(int id)
        {

            var HotelsData = Hotels_Obj.GetById(id);

            if (HotelsData.ImagePath == null)
            {
                HotelsData.ImagePath = "/images/No_Image_Available.jpg";
            }

            HotelsCustomModel_Obj.Hotels = HotelsData;

            return View(HotelsCustomModel_Obj);
        }





        [HttpPost]
        public ActionResult EditHotels(HotelsCustomModel Hotels_OBJ)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Hotels_OBJ.UserImageFiles != null)
                    {

                        //image name lay rai hn
                        string fileName = Path.GetFileNameWithoutExtension(Hotels_OBJ.UserImageFiles.FileName);

                        //image extension
                        string Extension = Path.GetExtension(Hotels_OBJ.UserImageFiles.FileName);

                        //unique name
                        fileName = fileName + DateTime.Now.ToString("yymmssff") + Extension;

                        //saving path to db
                        Hotels_OBJ.Hotels.ImagePath = "/images/" + fileName;


                        //creating path from computer path + file name
                        fileName = Path.Combine(Server.MapPath("/images/"), fileName);

                        //obj.userimageFile mai jo image a rai hai usko save kr do folder mai
                        Hotels_OBJ.UserImageFiles.SaveAs(fileName);


                    }

                    if (Hotels_OBJ.Hotels.ImagePath == "/images/No_Image_Available.jpg")
                    {
                        Hotels_OBJ.Hotels.ImagePath = null;
                    }

                    Common_Mapping_model_obj.Update_hotel(Hotels_OBJ);

                    TempData["Recored_Edited"] = "REOCORD EDITED SUCCESSFULLY";

                }

            }

            catch (Exception e)
            {
                TempData["Recored_Edited"] = "REOCORD EDITED SUCCESSFULLY" + e.Message;
            }


            return RedirectToAction("EditHotels", "Admin", new { area = "Admin" });




        }




        [HttpGet]
        public ActionResult DeleteHotels(int id)
        {
            Hotels_Obj.Delete(id);

            TempData["Hotels_Delete"] = "Record successfully deleted";

            return RedirectToAction("CurrentHotels", "Admin");
        }

















        //Hotels SEETTING AND PAGIES

        [HttpGet]
        public ActionResult CreateHotels2()
        {
            return View();
        }




        [HttpPost]
        public ActionResult CreateHotels2(HotelsCustomModel Hotels_OBJ)
        {
            try
            {

                //Adding hotel information in database firts so we can get hotel id , which will use in hotel-image table
                int id = Common_Mapping_model_obj.Insert_hotel(Hotels_OBJ);

                foreach (var file in Hotels_OBJ.Files)
                {


                    if (file != null && file.ContentLength > 0)
                    {

                        //image name lay rai hn
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName);

                        //image extension
                        string Extension = Path.GetExtension(file.FileName);

                        //unique name
                        fileName = fileName + DateTime.Now.ToString("yymmssff") + Extension;

                        //saving path to db
                        Hotels_OBJ.Hotels.ImagePath = "/images/" + fileName;


                        //creating path from computer path + file name
                        fileName = Path.Combine(Server.MapPath("/images/"), fileName);

                        //obj.userimageFile mai jo image a rai hai usko save kr do folder mai
                        file.SaveAs(fileName);



                        //storing hotel id into obj to use in hotel image table
                        Hotels_OBJ.Hotels.ID = id;


                        //Adding hotel images  in database
                        Common_Mapping_model_obj.Insert_hote_Images(Hotels_OBJ);

                        TempData["hotel_Created"] = "Hotel Added Successfully";
                    }


                }

            }


            catch (Exception e)
            {

                TempData["hotel_Not_Created"] = "There Is A Prabblem In Adding New Hotel" + e.Message;
            }

            return View();

        }





        [HttpGet]
        public ActionResult CurrentHotels2()
        {
            List<Hotle_Images_Custom_Model2> hotle_Images_Custom_Model2LIst = new List<Hotle_Images_Custom_Model2>();

            var Hotels_info = Hotels_Obj.GetAllWithAllImages();


            //SELECTING UNQIUE ID
            foreach (var item in Hotels_info.Select(R => R.ID).Distinct())
            {
                Hotle_Images_Custom_Model2 hotle_Images_Custom_Model2 = new Hotle_Images_Custom_Model2();

                //SELECTING UNQIUE REOCRD BASED ON UNIQUE ID    
                var hoteninfo = Hotels_info.Where(x => x.ID == item).FirstOrDefault();

                hotle_Images_Custom_Model2.ID = hoteninfo.ID;
                hotle_Images_Custom_Model2.Name = hoteninfo.Name;
                hotle_Images_Custom_Model2.Standard = hoteninfo.Standard;
                hotle_Images_Custom_Model2.Charges= hoteninfo.Charges;
                hotle_Images_Custom_Model2.Location = hoteninfo.Location;              
                hotle_Images_Custom_Model2.Gov_License = hoteninfo.Gov_License;

                var images = Hotels_info.Where(i => i.ID == item).Select(y => new ImagePath2() { Images = y.ImagePath });

                hotle_Images_Custom_Model2.Images.AddRange(images);


                hotle_Images_Custom_Model2LIst.Add(hotle_Images_Custom_Model2);
            }

            return View(hotle_Images_Custom_Model2LIst);

        }





        [HttpGet]
        public ActionResult EditHotels2(int id)
        {

            var Hotels_info = Hotels_Obj.GetByIdWithImages(id);

            hotle_Images_Custom_Model_Obj.ID = Hotels_info[0].ID;
            hotle_Images_Custom_Model_Obj.Name = Hotels_info[0].Name;    
            hotle_Images_Custom_Model_Obj.Location = Hotels_info[0].Location;
            hotle_Images_Custom_Model_Obj.Gov_License = Hotels_info[0].Gov_License;
            hotle_Images_Custom_Model_Obj.Standard = Hotels_info[0].Standard;
            hotle_Images_Custom_Model_Obj.Charges = Hotels_info[0].Charges;

            foreach (var item in Hotels_info)
            {
                hotle_Images_Custom_Model_Obj.Images.Add(new ImagePath() { Images = item.ImagePath });

            }

            return View(hotle_Images_Custom_Model_Obj);
        }






        [HttpPost]
        public ActionResult EditHotels2(HotelsCustomModel Hotels_OBJ, int ID, string Name, string Location, string Gov_License, string Standard, string Charges)
        {
            try
            {

                //Adding hotel information in database firts so we can get hotel id , which will use in hotel-image table

                //Hotels_OBJ.Hotels.ID = ID;
                //Hotels_OBJ.Hotels.Name = Name;
                //Hotels_OBJ.Hotels.Location = Location;
                //Hotels_OBJ.Hotels.Gov_License = Gov_License;
                //Hotels_OBJ.Hotels.Standard = Standard;
                //Hotels_OBJ.Hotels.Charges = Charges;
                int id = 1013;
                    //Common_Mapping_model_obj.Update_hotel2(Hotels_OBJ);

                foreach (var file in Hotels_OBJ.Files)
                {


                    if (file != null && file.ContentLength > 0)
                    {

                        //image name lay rai hn
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName);

                        //image extension
                        string Extension = Path.GetExtension(file.FileName);

                        //unique name
                        fileName = fileName + DateTime.Now.ToString("yymmssff") + Extension;

                        //saving path to db
                        Hotels_OBJ.Hotels.ImagePath = "/images/" + fileName;


                        //creating path from computer path + file name
                        fileName = Path.Combine(Server.MapPath("/images/"), fileName);

                        //obj.userimageFile mai jo image a rai hai usko save kr do folder mai
                        file.SaveAs(fileName);



                        //storing hotel id into obj to use in hotel image table
                        Hotels_OBJ.Hotels.ID = id;


                        //Adding hotel images  in database
                        Common_Mapping_model_obj.Insert_hote_Images(Hotels_OBJ);

                        TempData["hotel_Created"] = "Hotel Updated Successfully";
                    }


                }

            }


            catch (Exception e)
            {

                TempData["hotel_Not_Created"] = "There Is A Prabblem In Adding New Hotel" + e.Message;
            }

            return View();

        }

        [HttpGet]
        public ActionResult DeleteHotels2(int id)
        {
            Hotels_Obj.Delete(id);

            TempData["Hotels_Delete"] = "Record successfully deleted";

            return RedirectToAction("CurrentHotels", "Admin");
        }









































        //EXTRA FUNCTIONALITY


        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
       public ActionResult AllReocrd(string search, string SortOrder, string SortBy, int PageNumber = 1, int SerialNo = 0)
    {



        ViewBag.Sortorder = SortOrder;

        ViewBag.SortBy = SortBy;

        ViewBag.PageNumber = PageNumber;

        ViewBag.SerialNo = SerialNo;

        var AllRecord = UserDB_OBJ.GetAll();



        //SEARCH BAR FUNCTIONALITY
        if (search != null)
        {

            //SEARCHING FOR EXACT MATCH
            //AllRecord = db.tbl_user.Where(table => table.Name == search).ToList();


            //SEARCHING FOR LIKELY MATCH


            AllRecord = UserDB_OBJ.SearchFunction(search);

            //HAVE TO IMPROVE LOGIC Q K SORTING KRO TO WO SAB RESULT LE ATA HAI
            //AllRecord = ApplySorting(SortOrder, SortBy, AllRecord, db);


            AllRecord = ApplyPagination(AllRecord, PageNumber);




        }

        else
        {

            AllRecord = ApplySorting(SortOrder, SortBy, AllRecord);

            AllRecord = ApplyPagination(AllRecord, PageNumber);


        }

        return View(AllRecord);

    }
       
       
       
       
       //SORRING FUNCTION
       public List<tbl_user> ApplySorting(string SortOrder, string SortBy, List<tbl_user> AllRecord)
    {

        switch (SortBy)
        {

            case "Name":
                {
                    switch (SortOrder)
                    {

                        case "Asc":
                            {

                                AllRecord = UserDB_OBJ.GetAllRecordByAssByName();
                                break;
                            }


                        case "Desc":
                            {

                                AllRecord = UserDB_OBJ.GetAllRecordByDessByName();
                                break;
                            }

                        default:
                            {
                                AllRecord = UserDB_OBJ.GetAllRecordByAssByName();
                                break;
                            }


                    }

                    break;
                }


            case "Email":
                {
                    switch (SortOrder)
                    {

                        case "Asc":
                            {
                                AllRecord = UserDB_OBJ.GetAllRecordByAssByEmail();
                                break;
                            }


                        case "Desc":
                            {

                                AllRecord = UserDB_OBJ.GetAllRecordByDessByEmail();
                                break;
                            }

                        default:
                            {
                                AllRecord = UserDB_OBJ.GetAllRecordByAssByEmail();
                                break;
                            }


                    }

                    break;
                }

            default:
                {
                    AllRecord = UserDB_OBJ.GetAllRecordByDessByEmail();
                    break;
                }


        }

        return AllRecord;


    }
       
       
       
       
       
       //PAGINATION FUNCTION
       public List<tbl_user> ApplyPagination(List<tbl_user> AllRecord, int PageNumber = 1)

    {


        ViewBag.PageNumber = PageNumber;

        ViewBag.TotalPages = Math.Ceiling(AllRecord.Count() / 5.0);

        AllRecord = AllRecord.Skip((PageNumber - 1) * 5).Take(5).ToList();


        return AllRecord;


    }
       
    }

}






   


















