# Check zabbix version
execute
curl -s -i -X POST -H 'Content-Type: application/json-rpc' -d '{"jsonrpc":"2.0","method":"apiinfo.version","id":1,"auth":null,"params":{}}' 'http://127.0.0.1/api_jsonrpc.php'

result:
{"jsonrpc":"2.0","result":"5.2.3","id":1}

# Login inside zabbix
execute
curl -s -i -X POST -H 'Content-Type: application/json-rpc' -d '{ "params": { "user": "Admin", "password": "zabbix" }, "jsonrpc": "2.0", "method": "user.login", "id": 1, "auth": null }' 'http://127.0.0.1/api_jsonrpc.php'

result:
{"jsonrpc":"2.0","result":"3e1a3bee565d9a9e0a7c97150a942aa2","id":1}

# add dependencies
dotnet add package Zabbix.API.Core

# start project
dotnet run --project ./GSCC_ZABBIX/GSCC_ZABBIX.csproj
