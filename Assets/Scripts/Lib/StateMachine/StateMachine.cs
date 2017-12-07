using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StateMachine {

    #region Fields / Properties

    public State CurrentState { get { return states.ContainsKey(current) ? states [current] : null; } }

    private Type previous = null;
    private Type current = null;
    private readonly Dictionary<Type, State> states = new Dictionary<Type, State>();

    #endregion

    #region Public Behaviour

    public void Register (State state) {
        if (state != null)
            states [state.GetType()] = state;
    }

    public void Unregister (Type type) {
        if (type == current)
            ChangeState<State>();
        if (states.ContainsKey(type))
            states.Remove(type);
    }

    public void Clear () {
        ChangeState<State>();
        states.Clear();
    }

    public void ChangeState<T> () where T : State {
        if (current != null)
            states [current].Exit();
        previous = current;
        current = typeof(T);
        if (states.ContainsKey(current))
            states [current].Enter();
    }

    public void Return () {
        if (previous == null || current == null)
            return;
        states [current].Exit();
        Type temp = current;
        current = previous;
        previous = temp;
        states [current].Enter();
    }

    #endregion

}