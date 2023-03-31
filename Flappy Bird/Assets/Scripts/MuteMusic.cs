using UnityEngine;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sfx;
    public Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    private bool isOn = true;

    private void Start() 
    {
        button.image.sprite = soundOnImage;
    }

    public void ButtonClicked()
    {
        if (isOn)
        {
            button.image.sprite = soundOffImage;
            isOn = false;
            music.mute = true;
            sfx.mute = true;
        }
        else
        {
            button.image.sprite = soundOnImage;
            isOn = true;
            music.mute = false;
            sfx.mute = false;
        }
    }
}
