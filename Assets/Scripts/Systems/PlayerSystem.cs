using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public static class PlayerSystem {

    #region Public Behaviour

    public static void Login (string customID = null, Action OnPlayfabLoginSuccess = null) {
        var request = new LoginWithCustomIDRequest() { CreateAccount = true, CustomId = customID ?? SystemInfo.deviceUniqueIdentifier };
        PlayFabClientAPI.LoginWithCustomID(request, (result) => { LoginSuccessCallback(result); OnPlayfabLoginSuccess(); }, ErrorCallback);
    }

    public static void GetPlayerInfo (Action<PlayerInfo> OnGetPlayerDataSuccess) {
        var request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, (result) => {
            if (result == null || result.Data.Count == 0) {
                OnGetPlayerDataSuccess(null);
            } else {
                PlayerInfo playerInfo = new PlayerInfo(
                    int.Parse(result.Data[PlayerInfo.FieldName.PreviousRupees.ToString()].Value),
                    int.Parse(result.Data[PlayerInfo.FieldName.GamesCount.ToString()].Value)
                );
                OnGetPlayerDataSuccess(playerInfo);
                GetPlayerInfoSuccessCallback(result);
            }
        }, ErrorCallback);
    }

    public static void SetPlayerInfo (PlayerInfo playerInfo, Action OnSetPlayerDataSuccess = null) {
        var request = new UpdateUserDataRequest();
        request.Data = new Dictionary<string, string> {
            { PlayerInfo.FieldName.PreviousRupees.ToString(), playerInfo.previousRupees.ToString() },
            { PlayerInfo.FieldName.GamesCount.ToString(), playerInfo.gamesCount.ToString() }
        };
        PlayFabClientAPI.UpdateUserData(request, (result) => {
            SetPlayerInfoSuccessCallback(result);
            if (OnSetPlayerDataSuccess != null)
                OnSetPlayerDataSuccess();
        }, ErrorCallback);
    }

    #endregion

    #region Private Behaviour

    private static void LoginSuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        Debug.Log("Logged with ID: " + (result as LoginResult).PlayFabId);
    }

    private static void GetPlayerInfoSuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        var info = (result as GetUserDataResult).Data;
        foreach (KeyValuePair<string, UserDataRecord> field in info)
            Debug.Log(field.Key + " : " + field.Value.Value.ToString());
    }

    private static void SetPlayerInfoSuccessCallback<UpdateUserDataResult> (UpdateUserDataResult result) {
        Debug.Log("Player info updated correctly");
    }

    private static void ErrorCallback (PlayFabError error) {
        Debug.Log(error.ToString());
    }

    #endregion

}
