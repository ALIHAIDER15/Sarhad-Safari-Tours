using BOL_business_object_layer_;
using DAL_data_access_layer_;
using Mixed_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mapping_Models
{
    public class Common_Mapping_model
    {
    

  

        AdminSecurityDB AdminSecurityDB_Obj = new AdminSecurityDB();

        PackagesDB packages_Obj = new PackagesDB();

        GuideDB Guide_Obj = new GuideDB();

        HotelsDB Hotels_obj = new HotelsDB();

        Hotel_ImagesDB Hotel_ImagesDB_Obj = new Hotel_ImagesDB();



       // AdminCustomModel METHODS
        public int Insert_Admin(AdminCustomModel model)
        {

              tbl_Admin admin = model.Admin;

            //AdminCustomModel image_path = model.UserImageFiles;

            int id  =  AdminSecurityDB_Obj.Insert(admin);

            return id;

        }



        public void Update_Admin(AdminCustomModel model)
        {
            tbl_Admin admin = model.Admin;

            AdminSecurityDB_Obj.Upadate(admin);
         
        }









        // PackagesCustomModel METHODS
        public int Insert_Package(PackagesCustomModel model)
        {
            tbl_Packages Packages = model.Packages;

            int id = packages_Obj.Insert(Packages);

            return id;

        }




        public void Update_Package(PackagesCustomModel model)
        {
            tbl_Packages Packages = model.Packages;

            packages_Obj.Upadate(Packages);

        }








        // GuideCustomModel METHODS
        public int Insert_Guide(GuideCustomModel model)
        {

           tbl_Guide Guide = model.Guide;

            int id = Guide_Obj.Insert(Guide);

            return id;

        }



        public void Update_Guide(GuideCustomModel model)
        {
            tbl_Guide Guide = model.Guide;

            Guide_Obj.Upadate(Guide);

        }










        // HotelsCustomModel METHODS
        public int Insert_hotel(HotelsCustomModel model)
        {

            tbl_Hotels Hotel = model.Hotels;

            int id = Hotels_obj.Insert(Hotel);

            return id;

        }



        public void Update_hotel(HotelsCustomModel model)
        {
            tbl_Hotels Hotel = model.Hotels;

            Hotels_obj.Upadate(Hotel);

        }



        public int Update_hotel2(HotelsCustomModel model)
        {
            tbl_Hotels Hotel = model.Hotels;

          int id =  Hotels_obj.Upadate2(Hotel);

            return id;

        }










        // HotelsCustomModel METHODS
        public int Insert_hote_Images(HotelsCustomModel model)
        {

            tbl_Hotel_images Hotelimages = new tbl_Hotel_images();

            Hotelimages.Hotel_ID = model.Hotels.ID;

            Hotelimages.ImagePath = model.Hotels.ImagePath;

            int id = Hotel_ImagesDB_Obj.Insert(Hotelimages);

            return id;

        }



        public void Update_hotel_Images(HotelsCustomModel model)
        {
            tbl_Hotel_images Hotelimages = new tbl_Hotel_images();

            Hotelimages.ID = model.Hotels.ID;

            Hotelimages.ImagePath = model.Hotels.ImagePath;

            Hotel_ImagesDB_Obj.Upadate(Hotelimages);

        }













    }
}
