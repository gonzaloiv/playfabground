using UnityEngine;
using System.Collections.Generic;

public class Config {

    #region Fields / Properties

	public static string DeviceId;
    public static string PlayFabTitleId;

    #endregion

    #region Mono Behaviour

    public static void Init (ConfigData configData) {
        DeviceId = SystemInfo.deviceUniqueIdentifier;
        PlayFabTitleId = configData.PlayFabTitleId;
    }

    #endregion


}