#load "../../packages.csx"

#load "data.csx"

var redisBD = RedisDB.Connection.GetDatabase();
redisBD.StringSet("1", "César");

var value = redisBD.StringGet("1");
WriteLine(value);

// redisBD.KeyDelete("1");
