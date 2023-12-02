using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager I;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] GameObject volumeSetUI;
    [SerializeField] private AudioClip[] music;
    private AudioSource bgm;
    private void Awake()
    {
        I = this;
        bgm = GetComponent<AudioSource>();
        BgmSoundRandomPlay();
    }
    void Update()
    {
        bgm.volume = volumeSlider.value;
        if(!bgm.isPlaying)
            BgmSoundRandomPlay();

    }
    public void BgmSoundRandomPlay()
    {
        bgm.clip = music[Random.Range(0, (music.Length))];
        bgm.loop = false;
        bgm.Play();
    }
    public void BgmSoundStop()
    {
        bgm.Stop();
    }
    public void ShowVolumeSettingUI()
    {
        volumeSetUI.SetActive(true);
    }
    public void HideVolumeSettingUI()
    {
        volumeSetUI.SetActive(false);
    }
}
