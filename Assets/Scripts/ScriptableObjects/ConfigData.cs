using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConfigData", menuName = "ScriptableObject/Config", order = 1)]
public class ConfigData : ScriptableObject {

    [Header("Game")]
    public string PlayFabTitleId = "7FB6";
    public string DeviceId = "7FB6";

    [Header("Statistics")]
    public int MaxLeaderboardEntries = 10;

}