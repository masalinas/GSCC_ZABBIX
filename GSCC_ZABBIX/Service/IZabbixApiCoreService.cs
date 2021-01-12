using System;

namespace Zabbix.Service
{
    public interface IZabbixApiCoreService
    {
        ZabbixAPICore.Zabbix GetZabbix();
    }
}
