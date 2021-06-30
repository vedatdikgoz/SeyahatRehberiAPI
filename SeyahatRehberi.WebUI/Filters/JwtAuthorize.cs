﻿using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SeyahatRehberi.WebUI.ExtensionMethods;
using SeyahatRehberi.WebUI.Models;


namespace SeyahatRehberi.WebUI.Filters
{
    public class JwtAuthorize: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           var token= context.HttpContext.Session.GetString("token");
           if (string.IsNullOrWhiteSpace(token))
           {
               context.Result=new RedirectToActionResult("Login","Account", new { @area = "" });
           }
           else
           {
               using var httpClient = new HttpClient();
               httpClient.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer",token);
               var responseMessage= httpClient.GetAsync("https://localhost:44317/api/auth/activeUser").Result;
               if (responseMessage.IsSuccessStatusCode)
               {
                   var activeUser =
                       JsonConvert.DeserializeObject<UserViewModel>(responseMessage.Content.ReadAsStringAsync().Result);

                   context.HttpContext.Session.SetObject("activeUser",activeUser);
               }
               else
               {
                   context.Result = new RedirectToActionResult("Login", "Account", new {@area=""});
               }
           }
        }
    }
}
