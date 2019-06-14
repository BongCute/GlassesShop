using System.Web.Mvc;

namespace GlassesShop.Areas.GlassesAdmin
{
    public class GlassesAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GlassesAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GlassesAdmin_default",
                "GlassesAdmin/{controller}/{action}/{id}",
                new {Controller="HomeAdmin", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}