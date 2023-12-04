using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TImeSlider : MonoBehaviour
{
    public Slider timeSlider;
    void Awake()
    {
        timeSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSlider.value > 0.0f)
        {
            // �ð��� ������ ��ŭ slider Value ������ �մϴ�.
            timeSlider.value -= Time.deltaTime;
        }
    }
}
