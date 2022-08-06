using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MuteGame : MonoBehaviour
{
    public static bool isMuted = false;

    private Image muteImage;

    private void Start()
    {
        muteImage = GameObject.Find("MuteButton").GetComponent<Image>();

        if(isMuted)
        {
            muteImage.sprite = Resources.Load<Sprite>("mute");
        }
        else
        {
            muteImage.sprite = Resources.Load<Sprite>("sound");
        }
    }

    public void MuteToggle()
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
