// State
public interface IServerState
{
    void Response(IServerService server);
}

// Context
public interface IServerService
{
    void SetServerState(IServerState state);
    void HandleRequest();
}
