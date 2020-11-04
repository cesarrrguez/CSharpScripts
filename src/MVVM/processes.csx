#load "interfaces.csx"
#load "calculations.csx"

public class ProcessController
{
    public ProcessController() { }

    public class SpecificController
    {
        public IRunProcess Run => new RunProcess();
    }

    public static ProcessController Instance { get; } = new ProcessController();

    public SpecificController Specific { get; } = new SpecificController();
}

public class RunInput
{
    public int Value1 { get; set; }
    public int Value2 { get; set; }
}

public class RunOutput
{
    public int Result { get; set; }
    public override string ToString() => $"Result: {Result}";
}

public interface IRunProcess : IProcess<RunInput, RunOutput> { }

public class RunProcess : IRunProcess
{
    public RunOutput Execute(RunInput parameters)
    {
        var output = new RunOutput();
        var calculation = new Calculation();

        var result = calculation.Sum(parameters.Value1, parameters.Value2);

        output.Result = result;

        return output;
    }
}
