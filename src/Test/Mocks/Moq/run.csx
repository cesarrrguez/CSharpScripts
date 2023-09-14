#load "../../../../packages.csx"

#load "tests.csx"

var testService = new CustomerServiceTests();
CustomerServiceTests.Setup();

var test = testService.GetByIdAsync_ShouldReturnCustomer_WhenCustomerExits();
PrintTestResult(test);

test = testService.GetByIdAsync_ShouldReturnNothing_WhenCustomerDoesNotExits();
PrintTestResult(test);

test = testService.GetByIdAsync_ShouldLogAppropriateMessage_WhenCustomerExits();
PrintTestResult(test);

public void PrintTestResult(Task test)
{
    var result = test.IsCompletedSuccessfully ? "Test passed" : "Test failed";
    WriteLine(result);
}
