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
            // 시간이 변경한 만큼 slider Value 변경을 합니다.
            timeSlider.value -= Time.deltaTime;
        }
    }
}
