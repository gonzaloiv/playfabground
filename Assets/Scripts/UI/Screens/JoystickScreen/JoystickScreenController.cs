using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickScreenController : BaseScreenController {

    #region Fields / Properties

    [SerializeField] private Text xAxisText;
    [SerializeField] private Text yAxisText;
    [SerializeField] private JoystickController joystickController;

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        xAxisText.text = string.Empty;
        yAxisText.text = string.Empty;
    }

    private void Update () {
        xAxisText.text = joystickController.xAxis.ToString();
        yAxisText.text = joystickController.yAxis.ToString();
        InputSystem.Instance.xAxis = joystickController.xAxis;
        InputSystem.Instance.yAxis = joystickController.yAxis;
    }

    #endregion

}
