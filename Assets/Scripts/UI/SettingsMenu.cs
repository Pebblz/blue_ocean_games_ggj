using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour, SettingDataPersistence
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
    [SerializeField] TextMeshProUGUI sensX;
    [SerializeField] Slider senseSliderX;
    [SerializeField] TextMeshProUGUI sensY;
    [SerializeField] Slider senseSliderY;
    [SerializeField] private InputActionAsset inputActions;
    TMP_Text text;
    PlayerMovement player;
    private void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>();
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
    public void UpdateSensitivityX(float newSens)
    {
        if (player != null)
        {
            player.sensitivityX = newSens;
        }
        sensX.text = newSens.ToString("f1");
    }
    public void UpdateSensitivityY(float newSens)
    {
        if (player != null)
        {
            player.sensitivityY = newSens;
        }
        sensY.text = newSens.ToString("f1");
    }
    public void ResetAllBindings()
    {
        foreach(InputActionMap map in inputActions.actionMaps)
        {
            map.RemoveAllBindingOverrides();
        }
    }
    public void ResetToDefault()
    {
        SetVolume(0);
        SetQuality(3);
        UpdateResolution(19);
        SetFullScreen(true);
        UpdateUI(0, 3, 19, true,5,5);
        UpdateSensitivityX(5);
        UpdateSensitivityY(5);
    }
    public void UpdateUI(float _volume, int _qualityLevel, int _resolutionIndex, bool _fullscreen, float sensX, float sensY)
    {
        volumeSlider.value = _volume;
        fullscreenToggle.isOn = _fullscreen;
        resolutionDropDown.value = _resolutionIndex;
        resolutionDropDown.RefreshShownValue();
        graphicsDropDown.value = _qualityLevel;
        senseSliderX.value = sensX;
        senseSliderY.value = sensY;
        graphicsDropDown.RefreshShownValue();
    }
    public void LoadData(SettingsData data)
    {
        player = Player.Instance.gameObject.GetComponent<PlayerMovement>();
        SetVolume(data.volume);
        SetQuality(data.quilityLevel);
        UpdateResolution(data.resolutionIndex);
        SetFullScreen(data.isFullscreen);
        UpdateSensitivityX(data.SensitivityX);
        UpdateSensitivityY(data.SensitivityY);
        UpdateUI(data.volume, data.quilityLevel, data.resolutionIndex, data.isFullscreen, data.SensitivityX,data.SensitivityY);
    }
    public void SaveData(ref SettingsData data)
    {
        data.volume = volume;
        data.quilityLevel = QualitySettings.GetQualityLevel();
        data.resolutionIndex = resolutionIndex;
        data.isFullscreen = Screen.fullScreen;
        data.SensitivityX = senseSliderX.value;
        data.SensitivityY = senseSliderY.value;
    }
}
