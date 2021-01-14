using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using Newtonsoft.Json;

using SignalRChat.Hubs;

namespace Zabbix.Controller
{
    [Route("api/zabbix-webhook")]
    [ApiController]
    public class ZabbixWebhookController: ControllerBase
    {
        private IHubContext<ZabbixHub> hub;

        public ZabbixWebhookController(IHubContext<ZabbixHub> hub)
        {
            this.hub = hub;
        }

        [HttpPost("/post-webhook")]
        public IActionResult SendData(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            this.hub.Clients.All.SendAsync("zabbixdata", json);

            return Ok(new { Message = "Request Completed" });
        }
    }
}
