using System.Web;
using System.Web.Mvc;

namespace AutenticacionDosFactores_twilio
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
