using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BestScorePrizeSystem {

    #region Public Behaviour

    public static bool CanApply (Player player, int time) {
        Statistic playerTime = player.GetStatistic(StatisticType.HourTime);
        playerTime.SetLastValue(time);
        if (playerTime.IsBestValue(time)) {
            playerTime.SetBestValue(time);
            StatisticService.UpdateStatistic(StatisticType.HourTime, time);
            player.SetStatistic(playerTime);
            return true;
        } else {
            return false;
        }
    }

    public static void Apply (Player player, Action OnApply = null) {
        CurrencyService.AddCurrency(CurrencyCode.RP, Config.bestScorePrize)
           .Then(() => CurrencyService.GetCurrency(CurrencyCode.RP))
           .Then((result) => player.SetCurrency(result))
           .Then((result) => { if (OnApply != null) OnApply(); });
    }

    #endregion

}
