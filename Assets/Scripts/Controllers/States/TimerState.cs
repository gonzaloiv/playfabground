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
            app.player.GetStatistic(StatisticType.HourTime).SetLastValue(time);
            CurrencyService.SubstractCurrency(CurrencyCode.RP, Config.ruppeesPerGame)
               .Then(() => CurrencyService.GetCurrency(CurrencyCode.RP))
               .Then(currency => app.player.SetCurrency(currency));
            if (BestScoreSystem.CanApply(app.player))
                BestScoreSystem.Apply(app.player, OnBestScoreSystemApply);
            if (BestScorePrizeSystem.CanApply(app.player))
                BestScorePrizeSystem.Apply(app.player, OnBestScorePrizeSystemApply);
        }

        public void OnBestScoreSystemApply() {
            Debug.Log("This is your best score!"); // TODO: Adding a best score panel to the screen
        }

        public void OnBestScorePrizeSystemApply () {
            popUpController.Show("You've got " + Config.bestScorePrize.ToString() + " rupees!");
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