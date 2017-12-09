using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class PlayerService : BaseService {

    #region Public Behaviour

    public static void Login (string customID = null, Action OnPlayfabLoginSuccess = null) {
        var request = new LoginWithCustomIDRequest() { CreateAccount = true, CustomId = customID ?? SystemInfo.deviceUniqueIdentifier };
        PlayFabClientAPI.LoginWithCustomID(request, (result) => { LoginSuccessCallback(result); OnPlayfabLoginSuccess(); }, ErrorCallback);
    }

    public static void GetPlayer (Action<Player> OnGetPlayerSuccess) {

        var request = new GetPlayerCombinedInfoRequest();
        var requestParams = new GetPlayerCombinedInfoRequestParams { GetPlayerStatistics = true, GetUserData = true, GetUserInventory = true, GetUserVirtualCurrency = true };
        request.InfoRequestParameters = requestParams;

        PlayFabClientAPI.GetPlayerCombinedInfo(request, (result) => {

            Player player = new Player();

            List<Currency> currencies = CurrencyService.CurrenciesFromDictionary(result.InfoResultPayload.UserVirtualCurrency);
            if(currencies != null) player.SetCurrencies(currencies);

            List<Statistic> statistics = StatisticService.StatisticsFromList(result.InfoResultPayload.PlayerStatistics);
            if (statistics != null) player.SetStatistics(statistics);

            Inventory inventory = ItemService.InventoryFromItemInstanceList(result.InfoResultPayload.UserInventory);
            if(inventory != null) player.SetInventory(inventory);

            PlayerData playerData = DataService.PlayerInfoFromDictionary(result.InfoResultPayload.UserData);
            if (playerData != null) player.SetData(playerData);

            OnGetPlayerSuccess(player);
            GetPlayerSuccessBallback(result);

        }, ErrorCallback);

    }

    #endregion

    #region Private Behaviour

    private static void LoginSuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        Debug.Log("Logged with ID: " + (result as LoginResult).PlayFabId);
    }

    private static void GetPlayerSuccessBallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        Debug.Log("Player loaded correctly!");
    }

    #endregion

}
