using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager I;
    private void Awake()
    {
        I = this;
    }
    public void SaveVolumeData(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public float LoadVolumeData()
    {
        if (PlayerPrefs.HasKey("Volume"))
            return PlayerPrefs.GetFloat("Volume");
        else
            return 0.1f;
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }

}
