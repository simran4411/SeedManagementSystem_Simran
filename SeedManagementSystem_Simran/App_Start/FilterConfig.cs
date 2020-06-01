using System.Web;
using System.Web.Mvc;

namespace SeedManagementSystem_Simran
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
