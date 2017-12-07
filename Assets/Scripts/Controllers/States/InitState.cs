using UnityEngine;
using System.Collections;

namespace States {

    public class InitState : BaseState {

        #region Public Behaviour

        public InitState (object parent) : base(parent) { }

        public override void Enter () {
            timerScreenController.Init();
            mainMenuScreenController.Init();
            blogScreenController.Init();
            footerController.Init();
            UserSystem.Login(Config.DeviceId, OnLoginSuccess);
        }

        public void OnLoginSuccess () {
            DataSystem.GetAppInfo(OnGetAppInfoSuccess);
        }

        public void OnGetAppInfoSuccess (AppInfo appInfo) {
            app.SetInfo(appInfo);
            footerController.Show(app.info);
            mainController.ToMainMenuState();
        }

        #endregion

    }

}