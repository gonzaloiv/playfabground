using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour {

    #region Fields / Properties

    public virtual void Init () {
        gameObject.SetActive(false);
    }

    public virtual void Show () {
        gameObject.SetActive(true);
    }

    public virtual void Hide () {
        gameObject.SetActive(false);
    }

    #endregion

}