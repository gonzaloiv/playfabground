using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : UIController {

    #region Fields / Properties

    [SerializeField] private GameObject loader;

    #endregion

    #region Fields / Properties

    public virtual void Load () {
        loader.SetActive(true);
    }

    public override void Show () {
        base.Show();
        if (loader != null)
            loader.SetActive(false);
    }

    #endregion

}