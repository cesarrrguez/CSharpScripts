#load "states.csx"

// Context
public class ServerService : IServerService
{
    private IServerState _state;

    public ServerService()
    {
        _state = new AvailableServerState();
    }

    public void SetServerState(IServerState state)
    {
        _state = state ?? throw new ArgumentNullException(nameof(state));
    }

    public void HandleRequest()
    {
        _state.Response(this);
    }
}
