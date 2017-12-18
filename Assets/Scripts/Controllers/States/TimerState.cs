﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class TimerState : BaseState {

        #region Public Behaviour

        public TimerState (object parent) : base(parent) { }

        public override void Enter () {
            base.Enter();
            timerScreenController.Show();
        }

        public override void Exit () {
            base.Exit();
            timerScreenController.Hide();
        }

        public void OnTimerStopEvent (int time) {
            CurrencyService.SubstractCurrency(CurrencyCode.RP, Config.ruppeesPerGame)
                           .Then(() => CurrencyService.GetCurrency(CurrencyCode.RP))
                           .Then(currency => app.player.SetCurrency(currency));
            SetPlayerTime(time);
        }

        #endregion

        #region Protected Behaviour

        protected override void AddListeners () {
            TimerScreenController.TimerStopEvent += OnTimerStopEvent;
        }

        protected override void RemoveListeners () {
            TimerScreenController.TimerStopEvent -= OnTimerStopEvent;
        }

        #endregion

        #region Private Behavriour

        private void SetPlayerTime (int time) {
            Statistic playerTime = app.player.GetStatistic(StatisticType.HourTime);
            playerTime.SetLastValue(time);
            if (playerTime.IsBestValue(time)) {
                playerTime.SetBestValue(time);
                StatisticService.UpdateStatistic(StatisticType.HourTime, time);
            }
            app.player.SetStatistic(playerTime);
        }

        #endregion

    }

}