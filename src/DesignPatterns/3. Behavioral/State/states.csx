#load "interfaces.csx"

using System.Threading;

// State A
public class AvailableServerState : IServerState
{
    public void Response(IServerService server)
    {
        WriteLine("Response: 200 OK");
        WriteLine($"Status = {GetType().Name}\n");
        server.SetServerState(new SaturatedServerState());
    }
}

// State B
public class SaturatedServerState : IServerState
{
    public void Response(IServerService server)
    {
        Thread.Sleep(1000);
        WriteLine("Response: 200 OK");
        WriteLine($"Status = {GetType().Name}\n");
        server.SetServerState(new HighSaturatedServerState());
    }
}

// State C
public class HighSaturatedServerState : IServerState
{
    public void Response(IServerService server)
    {
        Thread.Sleep(3000);
        WriteLine("Response: 200 OK");
        WriteLine($"Status = {GetType().Name}\n");
        server.SetServerState(new NotAvailableServerState());
    }
}

// State D
public class NotAvailableServerState : IServerState
{
    public void Response(IServerService server)
    {
        WriteLine("Response: 503 Not Available Server");
        WriteLine($"Status = {GetType().Name}\n");
        server.SetServerState(new AvailableServerState());
    }
}
