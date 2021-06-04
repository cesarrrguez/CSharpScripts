#load "data.csx"

#r "nuget: StackExchange.Redis, 2.2.4"

var redisBD = RedisDB.Connection.GetDatabase();
redisBD.StringSet("1", "César");

var value = redisBD.StringGet("1");
WriteLine(value);

// redisBD.KeyDelete("1");
