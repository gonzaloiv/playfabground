using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Linq;
using RSG;

public class StatisticService : BaseService {

    #region Public Behaviour

    public static Promise<List<LeaderboardEntry>> GetLeaderboard (string statisticName) {
        var promise = new Promise<List<LeaderboardEntry>>();
        var request = new GetLeaderboardRequest { StatisticName = statisticName, MaxResultsCount = Config.maxLeaderboardEntries };
        request.ProfileConstraints = new PlayerProfileViewConstraints { ShowAvatarUrl = true, ShowLocations = true };
        PlayFabClientAPI.GetLeaderboard(request, (result) => {
            try {
                promise.Resolve(LeaderboardEntriesFromLeaderboard(result.Leaderboard));
                GetLeaderboardSuccessCallback(result);
            } catch (Exception ex) {
                promise.Reject(ex);
            }
        }, ErrorCallback);
        return promise;
    }

    public static Promise<List<LeaderboardEntry>> GetPlayerLeaderboard (string statisticName) {
        var promise = new Promise<List<LeaderboardEntry>>();
        var request = new GetLeaderboardAroundPlayerRequest { StatisticName = statisticName, MaxResultsCount = Config.maxLeaderboardEntries };
        request.ProfileConstraints = new PlayerProfileViewConstraints { ShowAvatarUrl = true, ShowLocations = true };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, (result) => {
            try {
                promise.Resolve(LeaderboardEntriesFromLeaderboard(result.Leaderboard));
                GetPlayerLeaderboardSuccessCallback(result);
            } catch (Exception ex) {
                promise.Reject(ex);
            }
        }, ErrorCallback);
        return promise;
    }

    public static Promise<int> GetStatistic (StatisticType statisticType) {
        var promise = new Promise<int>();
        var request = new GetPlayerStatisticsRequest { StatisticNames = new List<string> { statisticType.ToString().ToLower() } };
        PlayFabClientAPI.GetPlayerStatistics(request, (result) => {
            try {
                promise.Resolve(result.Statistics[(int) statisticType].Value);
                GetStatisticSuccessCallback(result);
            } catch (Exception ex) {
                promise.Reject(ex);
            }
        }, ErrorCallback);
        return promise;
    }

    public static Promise UpdateStatistic (StatisticType statisticType, int value) {
        var promise = new Promise();
        var request = new UpdatePlayerStatisticsRequest();
        request.Statistics = new List<StatisticUpdate>() { new StatisticUpdate { StatisticName = statisticType.ToString(), Value = value } };
        PlayFabClientAPI.UpdatePlayerStatistics(request, (result) => {
            try {
                UpdateStatisticSuccessCallback(result);
                promise.Resolve();
            } catch (Exception ex) {
                promise.Reject(ex);
            }
        }, ErrorCallback);
        return promise;
    }

    public static List<LeaderboardEntry> LeaderboardEntriesFromLeaderboard (List<PlayerLeaderboardEntry> leaderboardEntries) {
        List<LeaderboardEntry> entries = new List<LeaderboardEntry>();
        leaderboardEntries.ForEach(entry => {
            LeaderboardEntry newEntry = new LeaderboardEntry(entry.Position, entry.PlayFabId, entry.DisplayName, entry.StatValue);
            if (!string.IsNullOrEmpty(entry.Profile.AvatarUrl))
                newEntry.SetAvatarURL(entry.Profile.AvatarUrl);
            if (entry.Profile.Locations != null)
                newEntry.SetCity(entry.Profile.Locations[0].City);
            entries.Add(newEntry);
        });
        return entries;
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

    private static void GetPlayerLeaderboardSuccessCallback<PlayFabResultCommon> (PlayFabResultCommon result) {
        var entry = (result as GetLeaderboardAroundPlayerResult).Leaderboard[0];
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
