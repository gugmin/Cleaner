using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputEvent : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnClickEvent;
    public event Action<Vector2> OnItemEvent;

    public void CallMoveEvent(Vector2 dir)
    {
        OnMoveEvent?.Invoke (dir);
    }

    public void CallClickEvent()
    {
        OnClickEvent?.Invoke();
    }

    public void CallItemEvent(Vector2 position)
    {
        OnItemEvent?.Invoke(position);
    }
}
