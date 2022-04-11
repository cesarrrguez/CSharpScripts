#load "enums.csx"

public class Process
{
    readonly Dictionary<StateTransition, ProcessState> transitions;
    public ProcessState CurrentState { get; private set; }

    public Process()
    {
        CurrentState = ProcessState.Inactive;
        transitions = new()
        {
            { new(ProcessState.Inactive, Command.Exit), ProcessState.Terminated },
            { new(ProcessState.Inactive, Command.Begin), ProcessState.Active },
            { new(ProcessState.Active, Command.End), ProcessState.Inactive },
            { new(ProcessState.Active, Command.Pause), ProcessState.Paused },
            { new(ProcessState.Paused, Command.End), ProcessState.Inactive },
            { new(ProcessState.Paused, Command.Resume), ProcessState.Active }
        };
    }

    public ProcessState GetNext(Command command)
    {
        var transition = new StateTransition(CurrentState, command);

        if (!transitions.TryGetValue(transition, out ProcessState nextState))
        {
            throw new Exception("Invalid transition: " + CurrentState + " -> " + command);
        }

        return nextState;
    }

    public ProcessState MoveNext(Command command)
    {
        CurrentState = GetNext(command);
        return CurrentState;
    }

    class StateTransition
    {
        readonly ProcessState CurrentState;
        readonly Command Command;

        public StateTransition(ProcessState currentState, Command command)
        {
            CurrentState = currentState;
            Command = command;
        }

        public override int GetHashCode()
        {
            return CurrentState.GetHashCode() ^ Command.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is StateTransition other && CurrentState == other.CurrentState && Command == other.Command;
        }
    }
}
