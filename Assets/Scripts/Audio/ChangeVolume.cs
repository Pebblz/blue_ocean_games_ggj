using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public enum TargetMixer
    {
        SFX = 1,
        MUSIC,
        MASTER
    }
    public bool loadingSettingsValue;
    Slider slider;
    AudioManager manager;
    [SerializeField]
    TargetMixer mixer;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        slider = this.GetComponent<Slider>();
    }

    public void SetLevel(float level)
    {
        //ignore this function call if loading programmatically
        if (loadingSettingsValue)
        {
            return;
        }
        switch (mixer)
        {
            case TargetMixer.MUSIC:
                manager.setMusicVol(level);
                break;
            case TargetMixer.SFX:
                manager.setSFXVol(level);
                break;
            default:
                Debug.LogWarning("No mixer selected for volume control");
                break;
        }
    }

    public void setVolumeLevel()
    {

        loadingSettingsValue = true;
        switch (mixer)
        {
            case TargetMixer.MUSIC:
                slider.value = manager.getMusicVol();
                break;
            case TargetMixer.SFX:
                slider.value = manager.getSFXVol();
                break;
            default:
                Debug.LogWarning("No mixer selected for volume control");
                break;
        }

        loadingSettingsValue = false;
    }

}
