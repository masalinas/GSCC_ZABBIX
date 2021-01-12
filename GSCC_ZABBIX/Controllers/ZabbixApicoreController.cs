using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Zabbix.Service;

namespace Zabbix.Controller
{
  [Route("api/zabbix-api-core")]
  public class ZabbixApiCoreController
  {
      private ZabbixApiCoreService zabbixApiCoreService;
  }
}
