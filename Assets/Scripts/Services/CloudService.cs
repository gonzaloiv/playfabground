using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Json;
using System;
using RSG;

public class CloudService : BaseService {

    #region Public Behaviour

    public static Promise StartCloudTimer () {
        int timeStamp = (int) (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;
        var promise = new Promise();
        var request = new ExecuteCloudScriptRequest { FunctionName = "ReloadRupees", GeneratePlayStreamEvent = true };
        PlayFabClientAPI.ExecuteCloudScript(request, (result) => {
            if (result.Error != null) {
                Debug.Log("result.Error" + result.Error.Message);
            } else {
                promise.Resolve();
                result.Logs.ForEach(x => Debug.Log(x.Message));
                SuccessCallback(result);
            }
        }, ErrorCallback);
        return promise;
    }

    #endregion

}
