using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State {

    #region Protected Behaviour

    public virtual void Enter () {
        AddListeners();
    }

    public virtual void Exit () {
        RemoveListeners();
    }

    #endregion

    #region Protected Behaviour

    protected virtual void AddListeners () { }

    protected virtual void RemoveListeners () { }

    #endregion

}