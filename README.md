# start zabbix service middleware from docker compose yaml for postgress:
clone repository zabbix docker support

```
git clone https://github.com/zabbix/zabbix-docker
```

from the new repository zabbix-docker execute this command to start zabbix with postgress
under alpine images:

```
docker-compose -f docker-compose_v3_alpine_pgsql_latest.yaml up
```

# execute zabbix info version command from curl:
We could execute some commands to check the zabbix API:

Recover the zabbix info version
```
curl -s -i -X POST -H 'Content-Type: application/json-rpc' -d '{"jsonrpc":"2.0","method":"apiinfo.version","id":1,"auth":null,"params":{}}' 'http://127.0.0.1/api_jsonrpc.php'
```

result:
```
{"jsonrpc":"2.0","result":"5.2.3","id":1}
```

Login into zabbix and recover a security token using the default zabbix account:

```
curl -s -i -X POST -H 'Content-Type: application/json-rpc' -d '{ "params": { "user": "Admin", "password": "zabbix" }, "jsonrpc": "2.0", "method": "user.login", "id": 1, "auth": null }' 'http://127.0.0.1/api_jsonrpc.php'
```

result:
```
{"jsonrpc":"2.0","result":"3e1a3bee565d9a9e0a7c97150a942aa2","id":1}
```

# add zabbix Core .NET dependency in your Webapi Core .NET project:
```
dotnet add package Zabbix.API.Core
```

# start zabbix Core .NET Webapi App:
```
dotnet run --project ./GSCC_ZABBIX/GSCC_ZABBIX.csproj
```
