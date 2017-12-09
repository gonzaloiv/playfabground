using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Linq;

public class StatisticService : BaseService {

    #region Public Behaviour

    public static void GetLeaderboard (string statisticName, Action<List<LeaderboardEntry>> OnGetLeaderboardSuccess) {
        var request = new GetLeaderboardRequest { StatisticName = statisticName, MaxResultsCount = Config.maxLeaderboardEntries };
        PlayFabClientAPI.GetLeaderboard(request, (result) => {
            if (result.Leaderboard == null || result.Leaderboard.Count == 0) {
                OnGetLeaderboardSuccess(null);
            } else {
                List<LeaderboardEntry> entries = new List<LeaderboardEntry>();
                result.Leaderboard.ForEach(entry => entries.Add(new LeaderboardEntry(entry.Position, entry.PlayFabId, entry.DisplayName, entry.StatValue)));
                GetLeaderboardSuccessCallback(result);
                OnGetLeaderboardSuccess(entries);
            }
        }, ErrorCallback);
    }

    public static void GetStatistic (StatisticType statisticType, Action<int> OnGetStatisticSuccess) {
        var request = new GetPlayerStatisticsRequest { StatisticNames = new List<string> { statisticType.ToString().ToLower() } };
        PlayFabClientAPI.GetPlayerStatistics(request, (result) => {
            if (result.Statistics == null || result.Statistics.Count == 0)
                return;
            OnGetStatisticSuccess(result.Statistics[0].Value);
            GetStatisticSuccessCallback(result);
        }, ErrorCallback);
    }

    public static void UpdateStatistic (StatisticType statisticType, int value, Action<UpdatePlayerStatisticsResult> OnUpdateStatisticSuccess = null) {
        var request = new UpdatePlayerStatisticsRequest();
        request.Statistics = new List<StatisticUpdate>() { new StatisticUpdate { StatisticName = statisticType.ToString(), Value = value } };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnUpdateStatisticSuccess ?? UpdateStatisticSuccessCallback, ErrorCallback);
    }

    public static List<Statistic> StatisticsFromList (List<StatisticValue> statisticValues) {
        if (statisticValues == null || statisticValues.Count == 0)
            return null;
        List<Statistic> statistics = new List<Statistic>();
        statisticValues.ForEach(statistic => statistics.Add(new Statistic((StatisticType) Enum.Parse(typeof(StatisticType), statistic.StatisticName), statistic.Value)));
        return statistics;
    }

    #endregion

    #region Private Behaviour

    private static void GetLeaderboardSuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        var entry = (result as GetLeaderboardResult).Leaderboard[0];
        Debug.Log("This dude: " + (string.IsNullOrEmpty(entry.DisplayName) ? entry.PlayFabId : entry.DisplayName) + ", is the best!");
    }

    private static void GetStatisticSuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        var statisticValue = (result as GetPlayerStatisticsResult).Statistics[0];
        Debug.Log("Player statistic " + statisticValue.StatisticName + " is " + statisticValue.Value);
    }

    private static void UpdateStatisticSuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        Debug.Log("Statistic updated! " + (result as UpdatePlayerStatisticsResult).CustomData);
    }

    #endregion

}
