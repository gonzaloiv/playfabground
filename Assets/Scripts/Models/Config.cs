using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config {

    #region Fields / Properties

    public static string deviceId;
    public static string playFabTitleId;
    public static int ruppeesPerGame;
    public static int maxLeaderboardEntries;

    #endregion

    #region Mono Behaviour

    public static void Init (ConfigData configData) {
        deviceId = string.IsNullOrEmpty(configData.deviceId) ? SystemInfo.deviceUniqueIdentifier : configData.deviceId;
        playFabTitleId = configData.playFabTitleId;
        ruppeesPerGame = configData.ruppeesPerGame;
        maxLeaderboardEntries = configData.maxLeaderboardEntries;
    }

    #endregion

}