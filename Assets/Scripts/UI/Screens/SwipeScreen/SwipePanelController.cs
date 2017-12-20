using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class SwipePanelController : UIController, IDragHandler, IEndDragHandler {

    #region Events

    public delegate void SwipeEventHandler (Direction direction);
    public static event SwipeEventHandler SwipeEvent;

    #endregion

    #region Mono Behaviour

    public void OnDrag (PointerEventData eventData) { }

    public void OnEndDrag (PointerEventData eventData) {

        Vector3 drag = (eventData.position - eventData.pressPosition).normalized;
        Direction direction;

        if (Mathf.Abs(drag.x) > Mathf.Abs(drag.y)) {
            direction = (drag.x > 0) ? Direction.Right : Direction.Left;
        } else {
            direction = (drag.y > 0) ? Direction.Up : Direction.Down;
        }

        Debug.Log("Dragged: " + direction);
        SwipeEvent.Invoke(direction);

    }

    #endregion

}