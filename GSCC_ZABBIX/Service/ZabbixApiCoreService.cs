using System;

using ZabbixAPICore;

namespace Zabbix.Service
{
    public class ZabbixApiCoreService : IZabbixApiCoreService
    {
        private Zabbix zabbix;

        public ZabbixApiCoreService(string username, string password, string basePath) {
            Zabbix zabbix = new Zabbix(username, password, basePath);
            zabbix.LoginAsync().Wait();
        }

        public Zabbix GetZabbix() {
          return this.zabbix;
        }
    }
}
