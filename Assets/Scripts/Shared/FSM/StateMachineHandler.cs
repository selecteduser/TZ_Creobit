using System;
using System.Collections.Generic;

public sealed class StateMachineHandler : IDisposable
{
    /*
            _states consists of:
                "AnyState" : State;
                "key" : State;
                ... etc.
    */
    
    public Dictionary<string, State> States { get; private set; }
    public State AnyState => States["AnyState"];
    public State CurrentState { get; private set; }
    
    public event Action<State> OnStateChanged;
    
    public StateMachineHandler(params string[] statesIdentifiers)
    {
        States = new Dictionary<string, State> {{"AnyState", new State()}};
        foreach (var identifier in statesIdentifiers) AddState(identifier);
    }
    public void AddState(string identifier)
    {
        if (!States.TryAdd(identifier, new State()))
        {
            throw new Exception($"Couldn't add {identifier} state!");
        }
    }
    public void SetState(string identifier)
    {
        if (!States.TryGetValue(identifier, out var setState))
        {
            throw new Exception($"Entity does not have {identifier} state!");
        }

        OnStateChanged?.Invoke(setState);
        CurrentState = setState;
    }
    public State TryGetState(string identifier)
    {
        if (!States.TryGetValue(identifier, out var state))
        {
            throw new Exception($"Entity does not have {identifier} state!");
        }

        return state;
    }
    public void Dispose()
    {
        OnStateChanged = null;
        foreach (var state in States)
        {
            state.Value.Dispose();
        }
        States.Clear();
        States = null;
    }
}
