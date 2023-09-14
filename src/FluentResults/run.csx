#load "../../packages.csx"

using FluentResults;

var result = IsNullOrEmptyName(string.Empty);

if (result.IsFailed)
{
    // Handle error
    WriteLine(result); // Result: IsSuccess='False', Reasons='Error with Message='Name is empty''
    return;
}

// Continue with the program

public Result IsNullOrEmptyName(string name)
{
    return string.IsNullOrEmpty(name) ? Result.Fail("Name is empty") : Result.Ok();
}
