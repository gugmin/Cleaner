using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputEvent : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnClickEvent;

    public void CallMoveEvent(Vector2 dir)
    {
        OnMoveEvent?.Invoke (dir);
    }

    public void CallClickEvent()
    {
        OnClickEvent?.Invoke();
    }
}
