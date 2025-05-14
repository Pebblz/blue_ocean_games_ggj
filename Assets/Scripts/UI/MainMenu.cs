using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int gameScene = 1;
    [SerializeField] GameObject settingsUI;
    [SerializeField] GameObject KeybindsUI;
    [SerializeField] GameObject gamepadUI;
    [SerializeField] GameObject mainMenuUI;
    private void Start()
    {
        settingsUI.SetActive(false);
        KeybindsUI.SetActive(false);
        gamepadUI.SetActive(false);
    }
    public void PlayeGameBTN()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void OpenSettings()
    {
        settingsUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }
    public void CloseSettings()
    {
        settingsUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
    public void OpenkeyBinds()
    {
        KeybindsUI.SetActive(true);
        settingsUI.SetActive(false);
    }
    public void ClosekeyBinds() 
    {
        KeybindsUI.SetActive(false);
        settingsUI.SetActive(true);
    }
    public void OpenGamepad() 
    {
        gamepadUI.SetActive(true);
        settingsUI.SetActive(false);
    }
    public void CloseGamepad() 
    {
        gamepadUI.SetActive(false);
        settingsUI.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
