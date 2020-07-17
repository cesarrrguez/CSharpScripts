#load "tests.csx"

// Build test service
var testService = new UserServiceTest();
UserServiceTest.Setup(null);

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
