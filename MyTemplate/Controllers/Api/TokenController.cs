using ApplicationCore.Commons.Constants;
using Microsoft.AspNetCore.Mvc;
using MyTemplateWeb.ViewModels.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTemplateWeb.Controllers.Api
{
    [Route("api/{controller}/{action}")]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetToken()
        {
            TokenVo tokenVo;

            string userAct = Request.Cookies[CookieConstants.CLIENT_USER_NAME]?.ToString();
            string guid = Request.Cookies[CookieConstants.CLIENT_TICKET]?.ToString();

            try
            {

            }
            catch (Exception)
            {

            }

            return Ok();
        }
    }
}
