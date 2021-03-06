## Description
A Web Api Core .NET PoC with swagger to test the Zabbix API and Zabbix Webhooks to send RT data

- To read Zabbix API go to [Zabbix API](https://www.zabbix.com/documentation/current/manual/api/reference)

- To read Zabbix Webhooks go to [Zabbix Webhooks](https://www.zabbix.com/documentation/current/manual/config/notifications/media/webhook)

The Swagger interface 

![image](https://user-images.githubusercontent.com/1216181/104812893-b9c97300-5805-11eb-811d-d54dd6533d2a.png)

Zabbix portal

![image](https://user-images.githubusercontent.com/1216181/104812914-ef6e5c00-5805-11eb-87ad-b273bf8ddd47.png)


## Dependencies

- **Swashbuckle**: core .NET Swagger implementation.
- **Zabbix.API.Core**: core .NET Zabbix API implementation.
- **Microsoft signalR**: websockets core NET 3.1 implementation.

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
To have a simple access to Zabbix API we will use this .NET dependency

[Zabbix API Core](https://share.zabbix.com/zabbix-tools-and-utilities/dir-libraries/c/zabbix-net-core-api-library)
```
dotnet add package Zabbix.API.Core
```

## Configure Zabbix Core .NET Webapi App:
From any appsettings files we must configure these attributes:

- **Username**: the username to authenticate with Zabbix
- **Password**: the password to authenticate with Zabbix
- **BasePath**: the url where Zabbix API is running

## Start Zabbix Core .NET Webapi App:
```
dotnet run --project ./zabbix-api/zabbix-api.csproj
```
