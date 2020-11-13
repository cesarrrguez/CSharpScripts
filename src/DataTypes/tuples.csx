var employee1 = GetEmployee1();
WriteLine($"Employee. Id: {employee1.Item1}, First Name: {employee1.Item2}, Last Name: {employee1.Item3}");

var employee2 = GetEmployee2();
WriteLine($"Employee. Id: {employee2.Item1}, First Name: {employee2.Item2}, Last Name: {employee2.Item3}");

(int Id, string FirstName, string LastName) employee3 = GetEmployee2();
WriteLine($"Employee. Id: {employee3.Id}, First Name: {employee3.FirstName}, Last Name: {employee3.LastName}");

public Tuple<int, string, string> GetEmployee1() => Tuple.Create(1001, "James", "Brown");
public (int, string, string) GetEmployee2() => (1001, "James", "Brown");
