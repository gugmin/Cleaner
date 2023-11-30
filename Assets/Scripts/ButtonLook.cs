using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLook : MonoBehaviour
{
    [SerializeField] private Button easyBtn;
    [SerializeField] private Button normalBtn;
    [SerializeField] private Button hardBtn;

    // Start is called before the first frame update
    void Start()
    {
        easyBtn.interactable = true;
        normalBtn.interactable = false;
        hardBtn.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        // easy난이도를 클리어 시, normal난이도 해금
        
        // normal난이도를 클리어 시, hard난이도 해금

    }
}
