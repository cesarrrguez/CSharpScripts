#load "../../../packages.csx"

#load "tests.csx"

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
