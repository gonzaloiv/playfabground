using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConfigData", menuName = "ScriptableObject/Config", order = 1)]
public class ConfigData : ScriptableObject {

    [Header("Game")]
    public LaunchMode launchMode;
    public string deviceId;

    [Header("Virtual Currency")]
    public int ruppeesPerGame = 1;

    [Header("Statistics")]
    public int maxLeaderboardEntries = 10;
    public int bestScorePrize = 5;

}