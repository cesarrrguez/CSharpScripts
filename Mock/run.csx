#load "tests.csx"

#r "nuget: Moq, 4.14.5"
#r "nuget: FluentAssertions, 5.10.3"
#r "nuget: MSTest.TestFramework, 2.1.2"

// Build test service
var testService = new UserServiceTests();
UserServiceTests.Setup();

// Test 1
var test_1 = testService.Given_UserId_100_Expected_UserId_1();
PrintTestResult(test_1);

// Test 2
var test_2 = testService.Given_UserId_2_Expected_UserId_2();
PrintTestResult(test_2);

// Test 3
var test_3 = testService.GetAllUsersCount_Expected_2();
PrintTestResult(test_3);

public void PrintTestResult(Task test)
{
    var result = test.IsCompletedSuccessfully ? "Test passed" : "Test failed";
    Console.WriteLine(result);
}
