#load "../../../packages.csx"

#load "data.csx"

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
    WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
}

public void DeleteAllUsersPlus()
{
    var stopwatch = new Stopwatch();
    stopwatch.Start();

    dbUtil.DeleteAllUsersPlus();

    stopwatch.Stop();
    WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
}
