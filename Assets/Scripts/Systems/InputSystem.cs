using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InputSystem : MonoBehaviour {

    #region Fields / Properties

    public static readonly InputSystem Instance = new InputSystem();
    public bool w, a, s, d;
    public float xAxis, yAxis;

    #endregion

    #region Mono Behaviour

    void Update () {
        w = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.I);
        a = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.J);
        s = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.K);
        d = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.L);
    }

    #endregion

}
