using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Linq;
using RSG;

public class DataService : BaseService {

    #region Public Behaviour

    public static IPromise<AppData> GetAppData () {
        var promise = new Promise<AppData>();
        var request = new GetTitleDataRequest { Keys = new List<string> { "AppInfo" } };
        PlayFabClientAPI.GetTitleData(request, (result) => {
            try {
                AppData appData = JsonUtility.FromJson<AppData>(result.Data["AppInfo"]);
                promise.Resolve(appData);
                GetAppInfoSuccessCallback(result);
            } catch (Exception ex) {
                promise.Reject(ex);
            }
        }, ErrorCallback);
        return promise;
    }

    public static Promise<PlayerData> GetPlayerData () {
        var promise = new Promise<PlayerData>();
        var request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, (result) => {
            try {
                PlayerData playerData = PlayerInfoFromDictionary(result.Data);
                GetPlayerInfoSuccessCallback(result);
                promise.Resolve(playerData);
            } catch (Exception ex) {
                promise.Reject(ex);
            }
        }, ErrorCallback);
        return promise;
    }

    public static Promise SetPlayerData (PlayerData playerData) {
        var promise = new Promise();
        var request = new UpdateUserDataRequest { Data = PlayerInfoToDictionary(playerData) };
        PlayFabClientAPI.UpdateUserData(request, (result) => {
            SetPlayerInfoSuccessCallback(result);
            promise.Resolve();
        }, ErrorCallback);
        return promise;
    }

    public static Dictionary<string, string> PlayerInfoToDictionary (PlayerData playerData) {
        return new Dictionary<string, string> {
            { PlayerData.FieldName.GamesCount.ToString(), playerData.gamesCount.ToString() }
        };
    }

    public static PlayerData PlayerInfoFromDictionary (Dictionary<string, UserDataRecord> resultData) {
        if (resultData != null && resultData[PlayerData.FieldName.GamesCount.ToString()] != null) 
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