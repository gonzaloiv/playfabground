using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config {

    #region Fields / Properties

    public static LaunchMode launchMode;
    public static string deviceId;
    public static int ruppeesPerGame;
    public static int maxLeaderboardEntries;
    public static int bestScorePrize;

    #endregion

    #region Mono Behaviour

    public static void Init (ConfigData configData) {
        launchMode = configData.launchMode;
        deviceId = string.IsNullOrEmpty(configData.deviceId) ? SystemInfo.deviceUniqueIdentifier : configData.deviceId;
        ruppeesPerGame = configData.ruppeesPerGame;
        maxLeaderboardEntries = configData.maxLeaderboardEntries;
        bestScorePrize = configData.bestScorePrize;
    }

    #endregion

}