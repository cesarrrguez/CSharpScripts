var sons = typeof(Water).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Water)))
    .Select(t => t.Name);

WriteLine(string.Join(", ", sons)); // Juice, Wine, RedWine

public class Water { }
public class Juice : Water { }
public class Wine : Water { }
public class RedWine : Wine { }
