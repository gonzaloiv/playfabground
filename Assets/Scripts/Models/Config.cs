using UnityEngine;
using System.Collections.Generic;

public static class Config {

    #region Fields / Properties

    public static string DeviceId;
    public static string PlayFabTitleId;
    public static int MaxLeaderboardEntries;

    #endregion

    #region Mono Behaviour

    public static void Init (ConfigData configData) {
        DeviceId = string.IsNullOrEmpty(configData.DeviceId) ? SystemInfo.deviceUniqueIdentifier : configData.DeviceId;
        PlayFabTitleId = configData.PlayFabTitleId;
        MaxLeaderboardEntries = configData.MaxLeaderboardEntries;
    }

    #endregion


}