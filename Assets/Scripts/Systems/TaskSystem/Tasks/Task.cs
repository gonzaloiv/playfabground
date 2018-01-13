using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Task {

    #region Fields / Properties

    public bool IsRunning { get { return state == TaskState.Running; } }

    protected MonoBehaviour parent;
    protected Action OnTick;
    protected Action OnComplete;
    protected TaskState state = TaskState.Idle;

    #endregion

    #region Public Behaviour

    public Task (MonoBehaviour parent) {
        this.parent = parent;
    }

    public virtual void Run () {
        state = TaskState.Running;
    }

    public virtual void Dispose () {
        state = TaskState.Idle;
        if (OnComplete != null)
            OnComplete();
    }

    #endregion

}
