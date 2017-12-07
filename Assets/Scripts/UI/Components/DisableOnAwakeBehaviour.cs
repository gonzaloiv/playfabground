using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnAwakeBehaviour : MonoBehaviour {

    #region Mono Behaviour

    private void Awake () {
        gameObject.SetActive(false);
    }

    #endregion

}
