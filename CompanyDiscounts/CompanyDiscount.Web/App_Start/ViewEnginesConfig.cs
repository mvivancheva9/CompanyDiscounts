namespace CompanyDiscount.Web
{
    using System.Web.Mvc;

    public class ViewEnginesConfig
    {
        internal static void RegisteViewEngines(ViewEngineCollection engines)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
