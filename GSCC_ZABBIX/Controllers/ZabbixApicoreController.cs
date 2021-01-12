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
      [ProducesResponseType(typeof(Task<ZabbixAPICore.Response>), (int)HttpStatusCode.OK)]
      public Task<ZabbixAPICore.Response> GetResponseJsonAsync(string method, object parameters)
      {
        Task<ZabbixAPICore.Response> response = this.zabbixApiCoreService.GetZabbix().GetResponseObjectAsync(method, parameters);

        return response;
      }
    }
}
