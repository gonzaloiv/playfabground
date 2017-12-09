using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class BaseService {

    #region Protected Behaviour

    protected static void SuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        Debug.Log(result.ToString());
    }

    protected static void ErrorCallback (PlayFabError error) {
        Debug.Log(error.ErrorDetails);
        Debug.Log(error.ToString());
    }

    #endregion

}
