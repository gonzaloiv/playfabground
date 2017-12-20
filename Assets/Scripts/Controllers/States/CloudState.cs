using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace States {

    public class CloudState : BaseState {

        #region Public Behaviour

        public CloudState (object parent) : base(parent) { }

        public override void Enter () {
            base.Enter();
            cloudScreenController.Show();
        }

        public override void Exit () {
            base.Exit();
            cloudScreenController.Hide();
        }

        public void OnCloudButtonClickEvent (object sender, EventArgs e) {
            CloudService.StartCloudTimer()
                .Then(() => CurrencyService.GetCurrency(CurrencyCode.RP)
                .Then((result) => cloudScreenController.Show(result.amount)));
        }

        #endregion

        #region Protected Behaviour

        protected override void AddListeners () {
            CloudScreenController.CloudButtonClickEvent += OnCloudButtonClickEvent;
        }

        protected override void RemoveListeners () {
            CloudScreenController.CloudButtonClickEvent -= OnCloudButtonClickEvent;
        }

        #endregion

    }

}