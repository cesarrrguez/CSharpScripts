#load "../../../../packages.csx"

#load "entities.csx"
#load "tests.csx"

using System.Text.Json;

using AutoFixture;

BasicExamples();
ProductTests_Run();
UserTests_Run();

public void BasicExamples()
{
    WriteLine("Basic Examples:");

    IFixture fixture = new Fixture();

    string text = fixture.Create<string>();
    WriteLine($"string: {text}");

    int number = fixture.Create<int>();
    WriteLine($"int: {number}");

    IEnumerable<string> textList = fixture.CreateMany<string>();
    WriteLine($"IEnumerable<string>: {string.Join(", ", textList)}");

    Product product = fixture.Create<Product>();
    var productSerialized = JsonSerializer.Serialize(product);
    WriteLine($"Product: {productSerialized}");
}

public void ProductTests_Run()
{
    WriteLine("\nProduct tests:");

    ProductTests productTests = new ProductTests();

    var test = productTests.Create_ShouldReturnDummyProduct();
    PrintTestResult(test);

    test = productTests.Create_ShouldReturnExpensiveAndDummyProduct();
    PrintTestResult(test);
}

public void UserTests_Run()
{
    WriteLine("\nUser tests:");

    UserTests userTests = new UserTests();

    var test = userTests.Create_ShouldReturnUser_WithUserSpecimenBuilder();
    PrintTestResult(test);

    test = userTests.Create_ShouldReturnUser_WithMultipleSpecimenBuilder();
    PrintTestResult(test);

    test = userTests.Create_ShouldReturnUser_WithUserCustomization();
    PrintTestResult(test);

    test = userTests.Create_ShouldReturnUser_WithSpanishUserCustomization();
    PrintTestResult(test);

    test = userTests.Create_ShouldReturnUser_WithAdultUserCustomization();
    PrintTestResult(test);

    test = userTests.Create_ShouldReturnUser_WithUserWithDummyProductCustomization();
    PrintTestResult(test);
}

public void PrintTestResult(Task test)
{
    var result = test.IsCompletedSuccessfully ? "Test passed" : "Test failed";
    WriteLine(result);
}
