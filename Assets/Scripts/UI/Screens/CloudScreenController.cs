using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CloudScreenController : BaseScreenController {

    #region Fields / Properties

    [SerializeField] private Text countText;
    [SerializeField] private Button cloudButton;

    #endregion

    #region Event

    public static event EventHandler CloudButtonClickEvent;

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        cloudButton.onClick.AddListener(InvokeCloudButtonClickEvent);
    }

    public override void Show () {
        base.Show();
        countText.text = string.Empty;
    }

    public void Show (int count) {
        base.Show();
        countText.text = count.ToString();
    }

    private void InvokeCloudButtonClickEvent () {
        CloudButtonClickEvent.Invoke(cloudButton, null);
    }

    #endregion

}
