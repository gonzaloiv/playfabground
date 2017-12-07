using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Linq;

public static class DataSystem {

    #region Public Behaviour

    public static void GetAppInfo (Action<AppInfo> OnGetAppInfoSuccess) {
        var request = new GetTitleDataRequest();
        request.Keys = new List<string>{"AppInfo"};
        PlayFabClientAPI.GetTitleData(request, (result) => {
            if (result.Data == null || !result.Data.ContainsKey("AppInfo")) 
                return;
            AppInfo appInfo = JsonUtility.FromJson<AppInfo>(result.Data["AppInfo"]);
            SuccessCallback(result);
            OnGetAppInfoSuccess(appInfo);
        }, ErrorCallback);
    }

    #endregion

    #region Private Behaviour

    private static void SuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        Debug.Log("OnGetAppInfoSuccess");
        (result as GetTitleDataResult).Data.Keys.ToList().ForEach(key => Debug.Log((result as GetTitleDataResult).Data[key]));
    }

    private static void ErrorCallback (PlayFabError error) {
        Debug.Log(error.ToString());
    }

    #endregion

}

