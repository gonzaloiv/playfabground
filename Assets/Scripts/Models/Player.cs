using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public class Player {

    #region Fields / Properties

    public PlayerData data = new PlayerData();
    public Inventory inventory = new Inventory();
    public List<Currency> currencies = new List<Currency>();
    public List<Statistic> statistics = new List<Statistic> { new Statistic(StatisticType.HourTime, 0) }; // Must be initizalied on Start

    #endregion

    #region Public Behaviour

    public void SetData (PlayerData data) {
        this.data = data;
    }

    public void SetInventory (Inventory inventory) {
        this.inventory = inventory;
    }

    public void SetCurrencies (List<Currency> currencies) {
        this.currencies = currencies;
    }

    public Currency GetCurrency (CurrencyCode code) {
        return this.currencies.FirstOrDefault(currency => currency.code == code);
    }

    public void SetCurrency (Currency currency) {
        int index = this.currencies.IndexOf(currencies.FirstOrDefault(cur => cur.code == currency.code));
        this.currencies[index] = currency;
    }

    public void SetStatistics (List<Statistic> statistics) {
        this.statistics = statistics;
    }

    public Statistic GetStatistic (StatisticType type) {
        return this.statistics.FirstOrDefault(statistic => statistic.type == type);
    }

    public void SetStatistic (Statistic statistic) {
        int index = this.statistics.IndexOf(statistics.FirstOrDefault(stat => stat.type == statistic.type));
        this.statistics[index] = statistic;
    }

    #endregion

}
