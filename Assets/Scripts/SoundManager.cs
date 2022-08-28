using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioClip goodClick;
    public AudioClip loseSound;
    public AudioClip winSound;

    public static bool isMuted = false;

    private Image muteImage;

    private void Start()
    {
        if (GameObject.Find("MuteButton"))
        {
            muteImage = GameObject.Find("MuteButton").GetComponent<Image>();

            if (isMuted)
            {
                muteImage.sprite = Resources.Load<Sprite>("mute");
            }
            else
            {
                muteImage.sprite = Resources.Load<Sprite>("sound");
            }
        }         
    }

    public void MuteGame()
    {
        if (isMuted)
        {
            isMuted = false;
            AudioListener.volume = 1;
            muteImage.sprite = Resources.Load<Sprite>("sound");
        }
        else
        {
            isMuted = true;
            AudioListener.volume = 0;
            muteImage.sprite = Resources.Load<Sprite>("mute");
        }
    }
}
