using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Linq;
using RSG;

public class CurrencyService : BaseService {

    #region Public Behaviour

    public static IPromise<Currency> GetCurrency (CurrencyCode currencyCode) {
        var promise = new Promise<Currency>();
        var request = new GetUserInventoryRequest();
        PlayFabClientAPI.GetUserInventory(request, (result) => {
            try {
                Currency currency = new Currency(currencyCode, result.VirtualCurrency[currencyCode.ToString()]);
                promise.Resolve(currency);
                GetCurrencySuccessCallback(result);
            } catch (Exception ex){
                promise.Reject(ex);
            }
        }, ErrorCallback);
        return promise;
    }

    public static IPromise SubstractCurrency (CurrencyCode currencyCode, int amount) {
        var promise = new Promise();
        var request = new SubtractUserVirtualCurrencyRequest { VirtualCurrency = currencyCode.ToString(), Amount = amount };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, (result) => {
            SuccessCallback(result);
            promise.Resolve();
        }, ErrorCallback);
        return promise;
    }

    public static List<Currency> CurrenciesFromDictionary (Dictionary<string, int> currencyPairs) {
        List<Currency> currencies = new List<Currency>();
        foreach (KeyValuePair<string, int> currency in currencyPairs)
            currencies.Add(new Currency((CurrencyCode) Enum.Parse(typeof(CurrencyCode), currency.Key), currency.Value));
        return currencies;
    }

    #endregion

    #region Private Behaviour

    private static void GetCurrencySuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        var virtualCurrencies = (result as GetUserInventoryResult).VirtualCurrency;
        foreach (KeyValuePair<string, int> currency in virtualCurrencies)
            Debug.Log(currency.Key + " : " + currency.Value);
    }

    private static void ConsumeVirtualCurrencySuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        var items = (result as PurchaseItemResult).Items;
        foreach (ItemInstance item in items)
            Debug.Log("Purchased: " + item.ItemId);
    }

    #endregion

}