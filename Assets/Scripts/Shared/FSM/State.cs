using System;

public class State : IDisposable
{
    public delegate void StateUpdateEvent();
    public delegate void StateTimeDependentUpdateEvent(float deltaTime);
    
    //Events:
    public StateUpdateEvent Update { get; private set; }
    public StateUpdateEvent FixedUpdate { get; private set; }
    public StateUpdateEvent LateUpdate { get; private set; }

    //Properties:
    public event StateUpdateEvent OnUpdate
    {
        add => Update += value;
        remove => Update -= value;
    }
    public event StateUpdateEvent OnFixedUpdate
    {
        add => FixedUpdate += value;
        remove => FixedUpdate -= value;
    }
    public event StateUpdateEvent OnLateUpdate
    {
        add => LateUpdate += value;
        remove => LateUpdate -= value;
    }
    public void Dispose()
    {
        Update = null;
        FixedUpdate = null;
        LateUpdate = null;
    }
}