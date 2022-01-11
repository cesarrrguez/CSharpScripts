#load "tests.csx"

#r "nuget: FluentAssertions, 5.10.3"
#r "nuget: MSTest.TestFramework, 2.1.2"
#r "nuget: Microsoft.EntityFrameworkCore.Sqlite, 3.1.0"
#r "nuget: Microsoft.EntityFrameworkCore.InMemory, 3.1.0"

InitRepositoryTests.Setup();

var testRepository = new UserRepositoryTests();
UserRepositoryTests.Setup();

var test = testRepository.GetByIdAsync_ShouldReturnUser_WhenUserExits();
PrintTestResult(test);

test = testRepository.GetByIdAsync_ShouldReturnNothing_WhenUserDoesNotExits();
PrintTestResult(test);

public void PrintTestResult(Task test)
{
    var result = test.IsCompletedSuccessfully ? "Test passed" : "Test failed";
    WriteLine(result);
}
