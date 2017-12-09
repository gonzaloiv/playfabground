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
        if (loaderController != null)
            loaderController.Hide();
    }

    #endregion

}