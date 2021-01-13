using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Zabbix.Service;

namespace Zabbix.Controller
{
  [Route("api/zabbix-api-core")]
  public class ZabbixApiCoreController
  {
      private IZabbixApiCoreService zabbixApiCoreService;

      public ZabbixApiCoreController(IZabbixApiCoreService zabbixApiCoreService)
      {
            this.zabbixApiCoreService = zabbixApiCoreService;
      }

      [HttpGet("/get-json")]
      [ProducesResponseType(typeof(Task<string>), (int)HttpStatusCode.OK)]
      //public Task<string> GetResponseJsonAsync(string method, object parameters)
      public Task<string> GetResponseJsonAsync()
      {
            //Task<string> response = this.zabbixApiCoreService.GetZabbix().GetResponseJsonAsync(method, parameters);
            /*Task<string> response = this.zabbixApiCoreService.GetZabbix().GetResponseJsonAsync("user.get", new
            {
                output = "userid",
                filter = new { userid = 2 }
            });*/

            Task<string> response = this.zabbixApiCoreService.GetZabbix().GetResponseJsonAsync("user.get", new
            {
                output = "extend"
            });
            
            /*Task<string> response = this.zabbixApiCoreService.GetZabbix().GetResponseJsonAsync("apiinfo.version", new
            {
            });*/

        response.Wait();

        Console.WriteLine(response.Result);

        return response;
      }
    }
}
