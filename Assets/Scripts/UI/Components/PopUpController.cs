using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PopUpController : UIController {

    #region Fields / Properties

    [SerializeField] private Text titleText;
    [SerializeField] private Button exitButton;

    private Action OnExitButtonClick;

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        exitButton.onClick.AddListener(Hide);
    }

    public void Show (string title, Action OnExitButtonClick = null) {
        base.Show();
        this.OnExitButtonClick = OnExitButtonClick;
        titleText.text = title;
    }

    public override void Hide () {
        base.Hide();
        if (OnExitButtonClick != null)
            OnExitButtonClick();
    }

    #endregion

}
