using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models;
using System.IO;

namespace SchoolApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ApplicationDBContext dbContext;
        public ExceptionFilter(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                string exceptionMessage = string.IsNullOrEmpty(filterContext.Exception.InnerException.Message) ? "" : filterContext.Exception.InnerException.Message;
                string stackTrace = string.IsNullOrEmpty(filterContext.Exception.StackTrace) ? "" : filterContext.Exception.StackTrace;
                string controllerName = string.IsNullOrEmpty(filterContext.RouteData.Values["controller"].ToString()) ? "" : filterContext.RouteData.Values["controller"].ToString();
                string actionName = string.IsNullOrEmpty(filterContext.RouteData.Values["action"].ToString()) ? "" : filterContext.RouteData.Values["action"].ToString();

                string Message = "Date :" + DateTime.Now.ToString() + ", Controller: " + controllerName + ", Action:" + actionName +
                                 "Error Message : " + exceptionMessage
                                + Environment.NewLine + "Stack Trace : " + stackTrace;
                var parameter = new List<SqlParameter>();
                parameter.Add(new SqlParameter("@InnerException", exceptionMessage.ToString()));
                parameter.Add(new SqlParameter("@StackTrace", stackTrace.ToString()));
                parameter.Add(new SqlParameter("@ActionName", actionName.ToString()));
                parameter.Add(new SqlParameter("@Controller", controllerName.ToString()));
                parameter.Add(new SqlParameter("@Code", ""));
                dbContext.Database.ExecuteSqlRaw("exec stp_CreateLog @InnerException, @StackTrace, @ActionName,@Controller,@Code", parameter.ToArray());

                filterContext.ExceptionHandled = true;
            }
        }
    }
}
