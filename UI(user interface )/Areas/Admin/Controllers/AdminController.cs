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



                    int id = Common_Mapping_model_obj.Insert_Package(packageCM_Obj);


                    if (id > 0)
                    {

                        TempData["Package_added"] = "Package added Successfully";

                    }
                   

                }

            }
            catch(Exception e)
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

                    if (Package_OBJ.Packages.ImagePath == "/images/No_Image_Available.jpg")
                    {

                        Package_OBJ.Packages.ImagePath = null;

                    }


                    Common_Mapping_model_obj.Update_Package(Package_OBJ);



                    TempData["Recored_Edited"] = "REOCORD EDITED SUCCESSFULLY";
                }
            }
            catch (Exception e)
            {
                TempData["Recored_Edited-error"] = "REOCORD IS NOT EDITED " + e.Message;

            }

           

            return RedirectToAction("EditPackage",  new { Packages_Id = Package_OBJ.Packages.ID });

            

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

                 TempData["Recored_Edited"] = "REOCORD EDITED SUCCESSFULLY"+ e.Message;
            }
      

            return RedirectToAction("EditMemebership", new { Memebership_Id = tblMember_Obj.ID });



        }














        //PackageRequests  SECTION FUNCTIOANLITY 
        [HttpGet]
        public ActionResult PackageRequests()
        {
            var  trip_Obj = MyTrip_Obj.GetAll();

            return View(trip_Obj);
        }


        [HttpGet]
        public ActionResult DeletePackageRequests(int id)
        {
             MyTrip_Obj.Delete(id);

            TempData["Delete"] = "Record Deleted  SuccessFully";

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

                    if (Admin_OBJ.Admin.ImagePath == "/images/No_Image_Available.jpg")
                    {
                        Admin_OBJ.Admin.ImagePath = null;
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

                    if (Guide_OBJ.Guide.ImagePath == "/images/No_Image_Available.jpg")
                    {

                        Guide_OBJ.Guide.ImagePath = null;

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

                    int id = Common_Mapping_model_obj.Insert_hotel(Hotels_OBJ);

                    if (id > 0)
                    {
                        TempData["hotel_Created"] = "Hotel Added Successfully";
                    }

                } 

            }
            catch (Exception e)
            {

                TempData["hotel_Not_Created"] = "There Is A Prabblem In Adding New Hotel" +e.Message;
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



            int id = Common_Mapping_model_obj.Insert_hotel(Hotels_OBJ);


            if (id > 0)
            {

                TempData["hotel_Created"] = "Hotel Added Successfully";

            }
            else if (id <= 0)
            {
                TempData["hotel_Not_Created"] = "There Is A Prabblem In Adding New Hotel";

            }

            return RedirectToAction("CurrentHotels", "Admin", new { area = "Admin" });
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
