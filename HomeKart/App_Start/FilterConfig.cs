using HomeKartDAL;
using HomeKartEntity;
using System;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace HomeKart
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomExceptionFilter());
        }
    }
    public class CustomExceptionFilter : System.Web.Mvc.FilterAttribute, System.Web.Mvc.IExceptionFilter
    {
        public void OnException(ExceptionContext filtercontext)
        {
            if (!filtercontext.ExceptionHandled && filtercontext.Exception is NullReferenceException)
            {
                CustomExceptionHandler customExceptionHandler = new CustomExceptionHandler()
                {
                    ExceptionMessage = filtercontext.Exception.Message,
                    TraceException = filtercontext.Exception.StackTrace,
                    ControllerName = filtercontext.RouteData.Values["controller"].ToString(),
                    ActionName = filtercontext.RouteData.Values["action"].ToString(),
                    ExceptionLogTime = DateTime.Now
                };
                using (UserDataBase userContext = new UserDataBase())
                {
                    userContext.customExceptionHandlers.Add(customExceptionHandler);
                    userContext.SaveChanges();
                }
                filtercontext.ExceptionHandled = true;
                filtercontext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/Error"
                };
            }
        }
    }
}
