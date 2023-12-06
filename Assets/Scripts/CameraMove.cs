using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraMove : MonoBehaviour
{
    public void StartRound()
    {
        transform.DOMove(new Vector3(0, 0, -10), 2).SetUpdate(true);
    }
    public void RoundClear()
    {
        transform.DOMove(new Vector3(0, 10, -10), 2).SetUpdate(true);
    }

}
