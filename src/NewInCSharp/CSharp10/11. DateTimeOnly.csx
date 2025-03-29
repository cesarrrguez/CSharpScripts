DateTime dateTime = DateTime.Now; // C# 9
DateOnly dateFromDateTime = DateOnly.FromDateTime(DateTime.Now); // C# 10
TimeOnly timeFromDateTime = TimeOnly.FromDateTime(DateTime.Now); // C# 10
TimeOnly timeFromTimeSpan = TimeOnly.FromTimeSpan(TimeSpan.FromHours(13)); // C# 10

WriteLine(dateTime);
WriteLine(dateFromDateTime);
WriteLine(timeFromDateTime);
WriteLine(timeFromTimeSpan);
