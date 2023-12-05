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
    [SerializeField] private AudioClip[] ballSound;
    private AudioSource bgm;
    private void Awake()
    {
        I = this;
        bgm = GetComponent<AudioSource>();
        BgmSoundRandomPlay();
        volumeSlider.value = DataManager.I.LoadVolumeData();
    }
    void Update()
    {
        bgm.volume = volumeSlider.value;
        if (!bgm.isPlaying)
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
        DataManager.I.SaveVolumeData(volumeSlider.value);
        volumeSetUI.SetActive(false);
    }
    public void PlayBallSound()
    {
        bgm.PlayOneShot(ballSound[0]);
    }
    public void PlayDieSound()
    {
        bgm.PlayOneShot(ballSound[1]);
    }
}
