var employee = GetEmployee();
Console.WriteLine($"Employee. Id: {employee.Item1}, First Name: {employee.Item2}, Last Name: {employee.Item3}");

public Tuple<int, string, string> GetEmployee()
{
    var id = 1001;
    var firstName = "James";
    var lastName = "Brown";

    return Tuple.Create(id, firstName, lastName);
}
