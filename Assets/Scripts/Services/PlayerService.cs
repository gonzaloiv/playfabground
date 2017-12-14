﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PlayFab;
using PlayFab.ClientModels;
using Facebook.Unity;
using RSG;

public class PlayerService : BaseService {

    #region Public Behaviour

    public static Promise LoginWithCustomID (string customID = null) {
        var promise = new Promise();
        var request = new LoginWithCustomIDRequest() { CreateAccount = true, CustomId = customID ?? SystemInfo.deviceUniqueIdentifier };
        PlayFabClientAPI.LoginWithCustomID(request, (result) => {
            LoginSuccessCallback(result);
            promise.Resolve();
        }, ErrorCallback);
        return promise;
    }

    public static Promise LoginWithFacebook () {
        var promise = new Promise();
        FB.LogInWithReadPermissions(null, (loginResult) => {
            try {
                var request = new LoginWithFacebookRequest { CreateAccount = true, AccessToken = AccessToken.CurrentAccessToken.TokenString };
                PlayFabClientAPI.LoginWithFacebook(request, (result) => { promise.Resolve(); }, ErrorCallback);
            } catch (Exception ex) {
                promise.Reject(ex);
            }
        });
        return promise;
    }

    public static Promise<Player> GetPlayer () {
        var promise = new Promise<Player>();
        var request = new GetPlayerCombinedInfoRequest();
        var requestParams = new GetPlayerCombinedInfoRequestParams { GetPlayerStatistics = true, GetUserData = true, GetUserInventory = true, GetUserVirtualCurrency = true };
        request.InfoRequestParameters = requestParams;
        PlayFabClientAPI.GetPlayerCombinedInfo(request, (result) => {
            try {
                Player player = new Player();
                List<Currency> currencies = CurrencyService.CurrenciesFromDictionary(result.InfoResultPayload.UserVirtualCurrency);
                if (currencies != null) player.SetCurrencies(currencies);
                List<Statistic> statistics = StatisticService.StatisticsFromList(result.InfoResultPayload.PlayerStatistics);
                if (statistics != null) player.SetStatistics(statistics);
                Inventory inventory = ItemService.InventoryFromItemInstanceList(result.InfoResultPayload.UserInventory);
                if (inventory != null) player.SetInventory(inventory);
                PlayerData playerData = DataService.PlayerInfoFromDictionary(result.InfoResultPayload.UserData);
                if (playerData != null) player.SetData(playerData);
                GetPlayerSuccessBallback(result);
                promise.Resolve(player);
            } catch (Exception ex) {
                promise.Reject(ex);
            }
        }, ErrorCallback);
        return promise;
    }

    #endregion

    #region Private Behaviour

    private static void LoginSuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        Debug.Log("Logged with ID: " + (result as PlayFab.ClientModels.LoginResult).PlayFabId);
    }

    private static void GetPlayerSuccessBallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        Debug.Log("Player loaded correctly!");
    }

    #endregion

}