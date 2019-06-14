using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GlassesShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Danh sach danh muc",
                url: "GlassesAdmin/Category/ListCategory",
                defaults: new { controller = "Category", action = "ListCategory", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Them danh muc",
                url: "GlassesAdmin/AdminProduct/AddProduct",
                defaults: new { Controller = "Category", Action = "AddCategory", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name:"Sửa danh mục",
                url: "GlassesAdmin/AdminProduct/EditCategory",
                defaults: new {Controller="Category",Action="EditCategory", id = UrlParameter.Optional }
                );
            routes.MapRoute(
               name: "Danh sach san pham",
               url: "GlassesAdmin/AdminProduct/ListProduct",
               defaults: new { controller = "AdminProduct", action = "ListProduct", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Thêm  san pham",
               url: "GlassesAdmin/AdminProduct/AddProduct",
               defaults: new { controller = "AdminProduct", action = "ListProduct", id = UrlParameter.Optional }
           );
            routes.MapRoute(
             name: "Sửa  san pham",
             url: "GlassesAdmin/AdminProduct/EditProduct",
             defaults: new { controller = "AdminProduct", action = "ListProduct", id = UrlParameter.Optional }
         );
            routes.MapRoute(
                name:"Danh sach nguoi dung",
                url: "GlassesAdmin/User/ListUser",
                defaults: new {Console="User",Action="ListUser", id = UrlParameter.Optional }
                );

            routes.MapRoute(
               name: "Them nguoi dung",
               url: "GlassesAdmin/User/AddUser",
               defaults: new { Console = "User", Action = "ListUser", id = UrlParameter.Optional }
               );

            routes.MapRoute(
              name: "Sua nguoi dung",
              url: "GlassesAdmin/User/EditUser",
              defaults: new { Console = "User", Action = "ListUser", id = UrlParameter.Optional }
              );

            routes.MapRoute(
               name: "Danh sach hóa đơn",
               url: "GlassesAdmin/Invoice/ListUser",
               defaults: new { Console = "User", Action = "ListInvoice", id = UrlParameter.Optional }
               );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
