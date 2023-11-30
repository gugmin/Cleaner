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
        // easy���̵��� Ŭ���� ��, normal���̵� �ر�
        
        // normal���̵��� Ŭ���� ��, hard���̵� �ر�

    }
}
