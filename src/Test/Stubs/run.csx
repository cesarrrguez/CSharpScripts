#load "tests.csx"

#r "nuget: MSTest.TestFramework, 2.1.2"

var testService = new CustomerServiceTests();
CustomerServiceTests.Setup();

var test = testService.GetByIdAsync_ShouldReturnNothing_WhenCustomerDoesNotExits();
PrintTestResult(test);

public void PrintTestResult(Task test)
{
    var result = test.IsCompletedSuccessfully ? "Test passed" : "Test failed";
    WriteLine(result);
}
