#load "tests.csx"

#r "nuget: NUnit, 3.13.2"

var testService = new FactorialServiceTests();
testService.SetUp();

var test = testService.Calculate_ShouldReturnOne_WhenNumberIsZero();
PrintTestResult(test);

test = testService.Calculate_ShouldReturn120_WhenNumberIsFive();
PrintTestResult(test);

test = testService.Calculate_ShouldEqualTheirEqualTheory(0, 1);
PrintTestResult(test);

test = testService.Calculate_ShouldEqualTheirEqualTheory(5, 120);
PrintTestResult(test);

public void PrintTestResult(Task test)
{
    var result = test.IsCompletedSuccessfully ? "Test passed" : "Test failed";
    WriteLine(result);
}
