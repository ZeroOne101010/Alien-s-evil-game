using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public Slider slide;

    void Update()
    {
        ChangeVolumeMusic();
    }

    void ChangeVolumeMusic()
    {
        AudioListener.volume = slide.value;
    }
}
