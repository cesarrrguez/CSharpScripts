#load "tests.csx"

#r "nuget: FluentAssertions, 5.10.3"
#r "nuget: MSTest.TestFramework, 2.1.2"
#r "nuget: Microsoft.EntityFrameworkCore.Sqlite, 3.1.0"
#r "nuget: Microsoft.EntityFrameworkCore.InMemory, 3.1.0"

// Init test repository
InitRepositoryTests.Setup();

// Create test repository
var testRepository = new UserRepositoryTests();
UserRepositoryTests.Setup();

// Test 1
var test_1 = testRepository.Given_UserId_1_Expected_NotNull();
PrintTestResult(test_1);

// Test 2
var test_2 = testRepository.Given_UserId_2_Expected_Null();
PrintTestResult(test_2);

public void PrintTestResult(Task test)
{
    var result = test.IsCompletedSuccessfully ? "Test passed" : "Test failed";
    WriteLine(result);
}
