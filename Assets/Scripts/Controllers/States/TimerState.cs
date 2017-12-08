using System.Collections;
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
            VirtualCurrencySystem.ConsumeVirtualCurrency(VirtualCurrencyCode.RP, OnConsumeVirtualCurrencySuccess);
            player.SetLastTime(time);
            if (player.IsBestTime(time)) {
                player.SetBestTime(time);
                StatisticsSystem.UpdateStatistic(StatisticType.Time, time);
            }
        }

        public void OnConsumeVirtualCurrencySuccess () {
            VirtualCurrencySystem.GetVirtualCurrency(VirtualCurrencyCode.RP, player.SetRupees);
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

    }

}