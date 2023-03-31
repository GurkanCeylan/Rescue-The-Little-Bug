using UnityEngine;
using UnityEngine.UI;

public class SoundPanelController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    AudioManager audioManager;

    public void ToggleMusix()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

     public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }

}
