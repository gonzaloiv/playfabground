using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Linq;

public class DataService : BaseService {

    #region Public Behaviour

    public static void GetAppData (Action<AppData> OnGetAppDataSuccess) {
        var request = new GetTitleDataRequest { Keys = new List<string> { "AppInfo" } };
        PlayFabClientAPI.GetTitleData(request, (result) => {
            if (result.Data == null || !result.Data.ContainsKey("AppInfo"))
                return;
            AppData appData = JsonUtility.FromJson<AppData>(result.Data["AppInfo"]);
            OnGetAppDataSuccess(appData);
            GetAppInfoSuccessCallback(result);
        }, ErrorCallback);
    }

    public static void GetPlayerData (Action<PlayerData> OnGetPlayerDataSuccess) {
        var request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, (result) => {
            if (result == null || result.Data.Count == 0) {
                OnGetPlayerDataSuccess(null);
            } else {
                PlayerData playerData = PlayerInfoFromDictionary(result.Data);
                OnGetPlayerDataSuccess(playerData);
                GetPlayerInfoSuccessCallback(result);
            }
        }, ErrorCallback);
    }

    public static void SetPlayerData (PlayerData playerData, Action OnSetPlayerDataSuccess = null) {
        var request = new UpdateUserDataRequest{ Data = PlayerInfoToDictionary(playerData) };
        PlayFabClientAPI.UpdateUserData(request, (result) => {
            SetPlayerInfoSuccessCallback(result);
            if (OnSetPlayerDataSuccess != null)
                OnSetPlayerDataSuccess();
        }, ErrorCallback);
    }

    public static Dictionary<string, string> PlayerInfoToDictionary (PlayerData playerData) {
        return new Dictionary<string, string> {
            { PlayerData.FieldName.GamesCount.ToString(), playerData.gamesCount.ToString() }
        };
    }

    public static PlayerData PlayerInfoFromDictionary (Dictionary<string, UserDataRecord> resultData) {
        if (resultData == null || resultData.Count == 0)
            return null;
        return new PlayerData(int.Parse(resultData[PlayerData.FieldName.GamesCount.ToString()].Value));
    }

    #endregion

    #region Private Behaviour

    private static void GetAppInfoSuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        Debug.Log("OnGetAppInfoSuccess");
        foreach (KeyValuePair<string, string> field in (result as GetTitleDataResult).Data)
            Debug.Log(field.Key + " : " + field.Value.ToString());
    }

    private static void GetPlayerInfoSuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        var info = (result as GetUserDataResult).Data;
        foreach (KeyValuePair<string, UserDataRecord> field in info)
            Debug.Log(field.Key + " : " + field.Value.Value.ToString());
    }

    private static void SetPlayerInfoSuccessCallback<UpdateUserDataResult> (UpdateUserDataResult result) {
        Debug.Log("Player info updated correctly");
    }

    #endregion

}