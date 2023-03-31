 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioMixer audioMixer;

    [Header("----Audio Source----")]
    public AudioSource musicSource;
    public AudioSource SFXSource;    

    [Header("----Audio Clip----")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip death;
    public AudioClip victory;
    public int deadCounter;
    public float value;

    const string mixerPitch = "musicPitch";
    const string sfxPitch = "sfxPitch";

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        musicSource.clip = background;
        musicSource.Play();
        audioMixer.GetFloat("musicPitch", out value);
        print(value + " Pitch");
       
    }

    private void Update() 
    {
        SetPitch();
    }

    public void SetPitch()
    {
        deadCounter = GameManager.Instance.GetDeadCounter();
        
        switch (deadCounter)
            {
                case 0: audioMixer.SetFloat(mixerPitch, 1f);//0
                    break; 
                case 10: audioMixer.SetFloat(mixerPitch, 0.95f);//10
                    break; 
                case 20: audioMixer.SetFloat(mixerPitch, 0.90f);//20
                    break;
                case 30: audioMixer.SetFloat(mixerPitch, 0.85f);//30
                    break;
                case 40: audioMixer.SetFloat(mixerPitch, 0.80f);//40
                    break;
                case 50: audioMixer.SetFloat(mixerPitch, 0.75f);//50
                    break;
                case 60: audioMixer.SetFloat(mixerPitch, 0.70f);//60
                    break;
            }

        /*
        if (deadCounter >= 2)
        {
            audioMixer.SetFloat(mixerPitch, 0.90f);
            print(deadCounter + " & 0.90f");
        }
        else if (deadCounter >= 4)
        {
            audioMixer.SetFloat(mixerPitch, 0.80f);
            print(deadCounter + " & 0.80f");
        }
        */
    }

    public void PlaySFX(AudioClip clip)
    {
        audioMixer.SetFloat(sfxPitch, Random.Range (0.9f,1.1f));
        SFXSource.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

     public void ToggleSFX()
    {
        SFXSource.mute = !SFXSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        SFXSource.volume = volume;
    }

    /*
    public static AudioManager instance;
    public AudioSource bgm, endMusic;
    public AudioSource[] soundEffects;


    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].pitch = Random.Range(0.9f, 1.1f);
    }
    */

}
