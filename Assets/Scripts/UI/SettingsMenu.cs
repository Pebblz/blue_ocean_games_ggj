using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    //, SettingDataPersistence
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;
    float volume;
    int resolutionIndex;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public TMP_Dropdown graphicsDropDown;
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        //data = FindObjectOfType<SettingsData>();
        List<string> resolutionList = new List<string>();
        int currentResolution = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionList.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
            resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
                resolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(resolutionList);
        resolutionDropDown.value = currentResolution;
        resolutionDropDown.RefreshShownValue();
    }
    public void SetVolume(float _volume)
    {
        audioMixer.SetFloat("volume", _volume);
        volume = _volume;
    }
    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void UpdateResolution(int _resolutionIndex)
    {
        resolutions = Screen.resolutions;
        Resolution resolution = resolutions[_resolutionIndex];
        resolutionIndex = _resolutionIndex;
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void ResetToDefault()
    {
        SetVolume(0);
        SetQuality(3);
        UpdateResolution(19);
        SetFullScreen(true);
        UpdateUI(0, 3, 19, true);
    }
    public void UpdateUI(float _volume, int _qualityLevel, int _resolutionIndex, bool _fullscreen)
    {
        volumeSlider.value = _volume;
        fullscreenToggle.isOn = _fullscreen;
        resolutionDropDown.value = _resolutionIndex;
        resolutionDropDown.RefreshShownValue();
        graphicsDropDown.value = _qualityLevel;
        graphicsDropDown.RefreshShownValue();
    }
    //public void LoadData(SettingsData data)
    //{
    //    SetVolume(data.volume);
    //    SetQuality(data.quilityLevel);
    //    UpdateResolution(data.resolutionIndex);
    //    SetFullScreen(data.isFullscreen);
    //    UpdateUI(data.volume, data.quilityLevel, data.resolutionIndex, data.isFullscreen);
    //}
    //public void SaveData(ref SettingsData data)
    //{
    //    data.volume = volume;
    //    data.quilityLevel = QualitySettings.GetQualityLevel();
    //    data.resolutionIndex = resolutionIndex;
    //    data.isFullscreen = Screen.fullScreen;
    //}
}
