#load "../../../../packages.csx"

#load "tests.csx"

var testService = new UserServiceTests();

var test = testService.Print_ShouldUseRepository_WhenUsingConstructor();
PrintTestResult(test);

test = testService.Print_ShouldUseRepository_WhenUsingAutoMocker();
PrintTestResult(test);

test = testService.Print_ShouldUseRepository_WhenUsingAutoMockerWithShortCut();
PrintTestResult(test);

public void PrintTestResult(Task test)
{
    var result = test.IsCompletedSuccessfully ? "Test passed" : "Test failed";
    WriteLine(result);
}
