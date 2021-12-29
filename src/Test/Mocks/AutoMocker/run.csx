#load "tests.csx"

#r "nuget: xunit, 2.4.1"
#r "nuget: Moq, 4.16.1"
#r "nuget: Moq.AutoMock, 3.0.0"

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
