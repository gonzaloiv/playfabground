using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ToggleScreenController : BaseScreenController {

    #region Fields / Properties

    [SerializeField] private List<Color> colors;
    [SerializeField] private Text titleText;
    [SerializeField] private ToggleGroupController toggleGroupController;

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        toggleGroupController.Init();
    }

    public override void Show () {
        base.Show();
        ToggleGroupController.ToggleButtonClickEvent += OnToggleButtonClickEvent;
        toggleGroupController.Show(0);
    }

    public override void Hide () {
        base.Hide();
        ToggleGroupController.ToggleButtonClickEvent -= OnToggleButtonClickEvent;
        toggleGroupController.Hide();
    }

    public void OnToggleButtonClickEvent (int index) {
        titleText.color = colors[index];
    }

    #endregion

}
