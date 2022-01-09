#load "tests.csx"

#r "nuget: xunit, 2.4.1"

var testService = new FactorialServiceTests();

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
