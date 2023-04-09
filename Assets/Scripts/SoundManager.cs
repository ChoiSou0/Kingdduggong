using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    /*public AudioMixer masterMixer;
    public Slider audioSlider;*/
    /*[Header("Music")]
    public AudioSource m_musicsource;
    [Header("Sound Effect")]
    public AudioSource s_bt;
    public AudioSource s_collision;*/

    public AudioMixer mixer;

    [Range(-80, 0)]
    public float master = 0;

    [Range(-80, 0)]
    public float bgm = 0;

    [Range(-80, 0)]
    public float se = 0;

    public void MixerControl()
    {
        mixer.SetFloat(nameof(master), master);
        mixer.SetFloat(nameof(bgm), bgm);
        mixer.SetFloat(nameof(se), se);
    }
    void Start()
    {
        
    }
    public void SetLevel()
    {
        MixerControl();
    }
}
