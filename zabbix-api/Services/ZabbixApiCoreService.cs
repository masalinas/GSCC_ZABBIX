using System;

namespace Zabbix.Service
{
    public class ZabbixApiCoreService : IZabbixApiCoreService
    {
        private ZabbixAPICore.Zabbix zabbix;

        public ZabbixApiCoreService(string username, string password, string basePath) {
            ZabbixAPICore.Zabbix zabbix = new ZabbixAPICore.Zabbix(username, password, basePath);
            zabbix.LoginAsync().Wait();

            Console.WriteLine("Connected to Zabbix ...");

            this.zabbix = zabbix;
        }

        ~ZabbixApiCoreService()
        {
            this.zabbix.LogoutAsync().Wait();
        }

        ZabbixAPICore.Zabbix IZabbixApiCoreService.GetZabbix()
        {
            return this.zabbix;
        }
    }
}
