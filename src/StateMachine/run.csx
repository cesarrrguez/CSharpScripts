#load "processes.csx"

var process = new Process();
WriteLine("Current State = " + process.CurrentState);
WriteLine("Command.Begin: Current State = " + process.MoveNext(Command.Begin));
WriteLine("Command.Pause: Current State = " + process.MoveNext(Command.Pause));
WriteLine("Command.End: Current State = " + process.MoveNext(Command.End));
