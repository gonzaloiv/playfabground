using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BestScoreSystem {

    #region Public Behaviour

    public static bool CanApply (Player player) {
        Statistic playerTime = player.GetStatistic(StatisticType.HourTime);
        return playerTime.IsBestValue(playerTime.lastValue);
    }

    public static void Apply (Player player, Action OnApply = null) {
        Statistic playerTime = player.GetStatistic(StatisticType.HourTime);
        playerTime.SetBestValue(playerTime.lastValue);
        player.SetStatistic(playerTime);
        StatisticService.UpdateStatistic(playerTime)
            .Then(() => {
                if (OnApply != null)
                    OnApply();
            });
    }

    #endregion

}
