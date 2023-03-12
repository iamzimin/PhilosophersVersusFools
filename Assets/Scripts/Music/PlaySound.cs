using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    GameObject obj;
    SoundEffects se;

    private void Start()
    {
        obj = GameObject.FindWithTag("SOUND_EFFECTS_TAG");
        //if (obj != null)
        se = obj.GetComponent<SoundEffects>();
    }

    public void SoundPlay(string tag)
    {
        //if (se != null)
        se.PlaySound(tag);
    }

}
