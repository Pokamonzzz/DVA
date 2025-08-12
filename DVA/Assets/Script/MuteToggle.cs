using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    [Tooltip("Assign the AudioSource that plays the background music")]
    public AudioSource bgmSource;

    [Tooltip("The toggle UI element")]
    public Toggle muteToggle;

    private void Start()
    {
        // Optional: Load saved mute state
        if (PlayerPrefs.HasKey("BGM_Mute"))
        {
            bool isMuted = PlayerPrefs.GetInt("BGM_Mute") == 1;
            muteToggle.isOn = isMuted;
            bgmSource.mute = isMuted;
        }

        // Listen for toggle changes
        muteToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    public void OnToggleChanged(bool isOn)
    {
        // Here, "isOn" means the checkbox is checked → we mute the music
        bgmSource.mute = isOn;

        // Optional: Save mute state
        PlayerPrefs.SetInt("BGM_Mute", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
