using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ToggleGroupController : UIController {

    #region Fields / Properties

    [SerializeField] private List<Button> buttons;

    #endregion

    #region Events

    public delegate void ToggleButtonClickEventHandler (int index);
    public static event ToggleButtonClickEventHandler ToggleButtonClickEvent = delegate { };

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        buttons.ForEach(button => button.onClick.AddListener(() => OnClick(button)));
    }

    public void Show (int index) {
        base.Show();
        OnClick(buttons[index]);
    }

    #endregion

    #region Private Behaviour

    private void OnClick (Button button) {
        buttons.ForEach(btn => btn.targetGraphic.color = btn.colors.normalColor);
        button.targetGraphic.color = button.colors.pressedColor;
        ToggleButtonClickEvent.Invoke(buttons.IndexOf(button));
    }

    #endregion

}