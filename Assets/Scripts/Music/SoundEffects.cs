using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [Serializable]
    public class SoundWithTag
    {
        public string tag;
        public AudioClip sound;
    }

    [Header("Genaral")]
    public float generalVolume;

    [Header("Sound")]
    public AudioSource soundSource;
    public SoundWithTag[] sound;
    private Dictionary<string, AudioClip> soundsDict;

    public float soundVolume;

    private void Start()
    {
        soundSource = GetComponent<AudioSource>();

        soundsDict = new Dictionary<string, AudioClip>();
        for (int i = 0; i < sound.Length; i++)
            soundsDict.Add(sound[i].tag, sound[i].sound);
    }

    public void PlaySound(string tag)
    {
        if (soundSource !=null) 
        {
            var data = SaveManager.Load<SaveData>(ConfigManager.saveKey);

            soundSource.clip = soundsDict[tag];
            soundSource.PlayOneShot(soundSource.clip, data.soundVolume);
        }
    }

    private void UpdateBackgroundVolume()
    {
        if (PlayerPrefs.HasKey(ConfigManager.saveKey))
        {
            var data = SaveManager.Load<SaveData>(ConfigManager.saveKey);

            this.generalVolume = data.generalVolume;

            this.soundVolume = data.soundVolume;
            this.soundSource.volume = this.soundVolume * generalVolume;
        }
        else
        {
            this.soundVolume = 0.5f;
            this.soundSource.volume = this.soundVolume;
        }
    }

    private void LateUpdate()
    {
        UpdateBackgroundVolume();
    }
}
