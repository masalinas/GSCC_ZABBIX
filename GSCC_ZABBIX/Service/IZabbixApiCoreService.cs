using System;

using ZabbixAPICore;

namespace Zabbix.Service
{
    public interface IZabbixApiCoreService
    {
        Zabbix GetZabbix();
    }
}
