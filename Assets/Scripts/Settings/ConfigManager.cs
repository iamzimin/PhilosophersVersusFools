using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigManager : MonoBehaviour
{
    public GameObject generalVolume;
    public GameObject soundVolume;
    public GameObject musicVolume;
    public GameObject nicknameTextField;

    public const string saveKey = "mainSave";



    // Start is called before the first frame update
    private void Awake()
    {
        Load();
    }

    private SaveData GetSaveSnapshot()
    {
        var data = new SaveData()
        {
            generalVolume = this.generalVolume.GetComponent<Slider>().value,
            soundVolume = this.soundVolume.GetComponent<Slider>().value,
            musicVolume = this.musicVolume.GetComponent<Slider>().value,

            nickname = this.nicknameTextField.GetComponent<TMP_InputField>().text,
        };
        return data;
    }

    public void SaveSettings()
    {
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<SaveData>(saveKey);

        this.generalVolume.GetComponent<Slider>().value = (data.generalVolume);
        this.soundVolume.GetComponent<Slider>().value = (data.soundVolume);
        this.musicVolume.GetComponent<Slider>().value = (data.musicVolume);

        this.nicknameTextField.GetComponent<TMP_InputField>().text = (data.nickname);
    }

    private void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapshot());
    }

    public string GetNickname()
    {
        var data = SaveManager.Load<SaveData>(saveKey);
        return data.nickname;
    }

    public float GetSoundVolume()
    {
        var data = SaveManager.Load<SaveData>(saveKey);
        return data.soundVolume;
    }

}
