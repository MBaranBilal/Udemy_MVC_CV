﻿using System.Web;
using System.Web.Mvc;

namespace Udemy_MVC_CV
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
