using ISU_By_DBugSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Service
{
    public class UserActivityFilter : IActionFilter
    {
        private readonly ApplicationDBContext context;

        public UserActivityFilter(ApplicationDBContext context)
        {
            this.context = context;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var data = "";

            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            var url = $"{controllerName}/{actionName}";

            if (!string.IsNullOrEmpty(context.HttpContext.Request.QueryString.Value))
            {
                data = context.HttpContext.Request.QueryString.Value;
            }
            else
            {
                var userData = context.ActionArguments.FirstOrDefault();
                var stringUserData = JsonConvert.SerializeObject(userData);
                data = stringUserData;
            }

            var userName = context.HttpContext.User.Identity.Name;
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
            StoreUserActivity(data, url, userName, ipAddress);

        }

        public void StoreUserActivity(string data, string url, string userName, string ipAddress)
        {
            try
            {
 var userActivity = new UserActivity
            {
                Data = data,
                Url = url,
                UserName = userName,
                IpAddress = ipAddress
            };
            context.UserActivity.Add(userActivity);
            context.SaveChanges();
            }
            catch (Exception)
            {

            }
           
        }
    }
}
