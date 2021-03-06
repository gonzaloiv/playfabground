﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BestScorePrizeSystem {

    #region Public Behaviour

    public static bool CanApply (Player player) {
        Statistic playerTime = player.GetStatistic(StatisticType.HourTime);
        return playerTime.IsBestValue(playerTime.lastValue);
    }

    public static void Apply (Player player, Action OnApply = null) {
        CurrencyService.AddCurrency(CurrencyCode.RP, Config.bestScorePrize)
           .Then(() => CurrencyService.GetCurrency(CurrencyCode.RP))
           .Then((result) => {
               player.SetCurrency(result);
               if (OnApply != null)
                   OnApply();
           });
    }

    #endregion

}
