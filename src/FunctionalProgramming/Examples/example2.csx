var days = Days(new DateTime(2020, 08, 15), DateTime.Now);
WriteLine($"{days} days");

public int Days(DateTime from, DateTime to) => (to - from).Days;
