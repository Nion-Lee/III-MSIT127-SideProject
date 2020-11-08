using System.Web;
using System.Web.Mvc;

namespace 專題負責GoogleMap頁面
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
