using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Linq;

public class CurrencyService : BaseService {

    #region Public Behaviour

    public static void GetCurrency (CurrencyCode currencyCode, Action<Currency> OnGetCurrencySuccess) {
        var request = new GetUserInventoryRequest();
        PlayFabClientAPI.GetUserInventory(request, (result) => {
            if (result.VirtualCurrency == null || !result.VirtualCurrency.ContainsKey(currencyCode.ToString())) {
                OnGetCurrencySuccess(null);
            } else {
                OnGetCurrencySuccess(new Currency(currencyCode, result.VirtualCurrency[currencyCode.ToString()]));
                GetVirtualCurrencySuccessCallback(result);
            }
        }, ErrorCallback);
    }

    public static void SubstractCurrency (CurrencyCode currencyCode, int amount, Action OnConsumeCurrencySuccess = null) {
        var request = new SubtractUserVirtualCurrencyRequest { VirtualCurrency = currencyCode.ToString(), Amount = amount };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, (result) => {
            OnConsumeCurrencySuccess();
            SuccessCallback(result);
        }, ErrorCallback);
    }

    public static List<Currency> CurrenciesFromDictionary (Dictionary<string, int> currencyPairs) {
        List<Currency> currencies = new List<Currency>();
        foreach (KeyValuePair<string, int> currency in currencyPairs)
            currencies.Add(new Currency((CurrencyCode) Enum.Parse(typeof(CurrencyCode), currency.Key), currency.Value));
        return currencies;
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

    #endregion

}