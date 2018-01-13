using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScreenController : UIController {

    #region Fields / Properties

    [SerializeField] protected UIController loaderController;
    [SerializeField] protected PopUpController popUpController;

    #endregion

    #region Fields / Properties

    public virtual void Load () {
        loaderController.Show();
    }

    public override void Show () {
        base.Show();
        AddListeners();
        if (loaderController != null)
            loaderController.Hide();
    }

    public override void Hide () {
        base.Hide();
        RemoveListeners();
    }

    #endregion

    #region Protected Behaviour

    protected virtual void AddListeners () { }

    protected virtual void RemoveListeners () { }

    #endregion

}