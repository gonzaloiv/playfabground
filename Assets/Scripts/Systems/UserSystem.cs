using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public static class UserSystem {

    #region Public Behaviour

    public static void Login (string customID = null, Action OnPlayfabLoginSuccess = null) {
        var request = new LoginWithCustomIDRequest() { CreateAccount = true, CustomId = customID ?? SystemInfo.deviceUniqueIdentifier };
        PlayFabClientAPI.LoginWithCustomID(request, (result) => { SuccessCallback(result); OnPlayfabLoginSuccess(); }, ErrorCallback);
    }

    #endregion

    #region Private Behaviour

    private static void SuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        Debug.Log("Logged with ID: " + (result as LoginResult).PlayFabId);
    }

    private static void ErrorCallback (PlayFabError error) {
        Debug.Log(error.ToString());
    }

    #endregion

}
