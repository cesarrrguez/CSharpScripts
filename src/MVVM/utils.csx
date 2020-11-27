#load "interfaces.csx"

// Extensions
// ------------------------------------------------------------

public async static Task<TOutput> ExecuteProcess<TInput, TOutput>(this IProcess<TInput, TOutput> process, TInput input)
    where TInput : class
    where TOutput : class
{
    try
    {
        return await Task.Run(() => process.Execute(input)).ConfigureAwait(false);
    }
    catch (Exception e)
    {
        WriteLine(e.Message);
        throw;
    }
}
