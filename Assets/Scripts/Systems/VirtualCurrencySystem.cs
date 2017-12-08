using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Linq;

public static class VirtualCurrencySystem {

    #region Public Behaviour

    public static void GetVirtualCurrency (VirtualCurrencyCode virtualCurrencyCode, Action<int> OnGetVirtualCurrencySuccess) {
        var request = new GetUserInventoryRequest();
        PlayFabClientAPI.GetUserInventory(request, (result) => {
            if (result.VirtualCurrency == null || !result.VirtualCurrency.ContainsKey(virtualCurrencyCode.ToString()))
                return;
            OnGetVirtualCurrencySuccess(result.VirtualCurrency[virtualCurrencyCode.ToString()]);
            GetVirtualCurrencySuccessCallback(result);
        }, ErrorCallback);
    }

    public static void ConsumeVirtualCurrency (VirtualCurrencyCode virtualCurrencyCode, Action OnConsumeVirtualCurrencySuccess = null) {
        var request = new PurchaseItemRequest { ItemId = ItemID.OnePlay.ToString(), VirtualCurrency = virtualCurrencyCode.ToString(), Price = 1 };
        PlayFabClientAPI.PurchaseItem(request, (result) => {
            if (result.Items == null || result.Items.Count == 0)
                return;
            OnConsumeVirtualCurrencySuccess();
            ConsumeVirtualCurrencySuccessCallback(result);
        }, ErrorCallback);
    }

    #endregion

    #region Private Behaviour

    private static void GetVirtualCurrencySuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        var virtualCurrencies = (result as GetUserInventoryResult).VirtualCurrency;
        foreach (KeyValuePair<string, int> currency in virtualCurrencies)
            Debug.Log(currency.Key + " : " + currency.Value);
    }

    private static void ConsumeVirtualCurrencySuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        var items = (result as PurchaseItemResult).Items;
        foreach (ItemInstance item in items)
            Debug.Log("Purchased: " + item.ItemId);
    }

    private static void ErrorCallback (PlayFabError error) {
        Debug.Log(error.ToString());
    }

    #endregion

}