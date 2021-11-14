#load "data.csx"

#r "nuget: Microsoft.EntityFrameworkCore.Sqlite, 3.1.0"
#r "nuget: Z.EntityFramework.Extensions.EFCore, 3.2.0"

var dbUtil = new DbUtil();

dbUtil.PrepareData();
DeleteAllUsers();

WriteLine();

dbUtil.PrepareData();
DeleteAllUsersPlus();

public void DeleteAllUsers()
{
    var stopwatch = new Stopwatch();
    stopwatch.Start();

    dbUtil.DeleteAllUsers();

    stopwatch.Stop();
    WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} milliseconds");
}

public void DeleteAllUsersPlus()
{
    var stopwatch = new Stopwatch();
    stopwatch.Start();

    dbUtil.DeleteAllUsersPlus();

    stopwatch.Stop();
    WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} milliseconds");
}
