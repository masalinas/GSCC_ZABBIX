## Description
A simple Webapi Core .NET PoC with swagger to test the Zabbix API

To read zabbix API go to [Zabbix API](https://www.zabbix.com/documentation/current/manual/api/reference)

Swagger interface
![Swagger_Screen](https://user-images.githubusercontent.com/1216181/104485187-7931e580-55ca-11eb-8c16-503339364ef0.png)

Zabbix portal
![Swagger_Screen](
https://user-images.githubusercontent.com/1216181/104485242-88189800-55ca-11eb-9f65-b8a5baa5ac09.png)

## Start Zabbix service middleware from docker compose yaml using postgress and nginx web server
clone repository zabbix docker support

```
git clone https://github.com/zabbix/zabbix-docker
```

from the new repository zabbix-docker execute this command to start zabbix with postgress
under alpine images:

```
docker-compose -f docker-compose_v3_alpine_pgsql_latest.yaml up
```

## Execute some Zabbix API commands from shell
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

## Add Zabbix Core .NET dependency in your Webapi Core .NET project:
To have a simle access to Zabbix API we will use this .NET dependency

[Zabbix API Core](https://share.zabbix.com/zabbix-tools-and-utilities/dir-libraries/c/zabbix-net-core-api-library)
```
dotnet add package Zabbix.API.Core
```

## Configure Zabbix Core .NET Webapi App:
From any appsettings files we must configure these attributes:

- Username: the username to authenticate with Zabbix
- password: the password to authenticate with Zabbix
- BasePath: the url where Zabbix API is running

## Start Zabbix Core .NET Webapi App:
```
dotnet run --project ./GSCC_ZABBIX/GSCC_ZABBIX.csproj
```
