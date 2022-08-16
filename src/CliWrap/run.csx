#r "nuget: CliWrap, 3.4.4"

using CliWrap;
using CliWrap.Buffered;

var result = await Cli.Wrap("dotnet")
    .WithArguments("--version")
    .ExecuteBufferedAsync();

WriteLine(result.StandardOutput); // 6.0.300
