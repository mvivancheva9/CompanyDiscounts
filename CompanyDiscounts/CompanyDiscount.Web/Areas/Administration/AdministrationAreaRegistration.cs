using System.Web.Mvc;

namespace CompanyDiscount.Web.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            context.MapRoute(
               "CategoryDetails",
               "Administration/{controller}/{action}/{id}",
               new { controller = "CategoryDetails", action = "Index", id = UrlParameter.Optional });
        }
    }
}