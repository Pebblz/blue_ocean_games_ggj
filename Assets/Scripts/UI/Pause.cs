using UnityEngine;
public class Pause : MonoBehaviour
{
    bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject gamepadMenu;
    [SerializeField] GameObject keybindsMenu;
    [SerializeField] GameObject loseScreen;
    private void Start()
    {
        DisableEverything();
    }
    public void PauseGame()
    {
        if(!isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            DisableEverything();
            Time.timeScale = 1;
        }
    }
    public void OpenSettings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    public void OpenKeyBinds()
    {
        pauseMenu.SetActive(false);
        keybindsMenu.SetActive(true);
    }
    public void CloseKeyBinds()
    {
        pauseMenu.SetActive(true);
        keybindsMenu.SetActive(false);
    }
    public void OpenGamePadBinds()
    {
        settingsMenu.SetActive(false);
        gamepadMenu.SetActive(true);
    }
    public void CloseGamePadBinds()
    {
        settingsMenu.SetActive(true);
        gamepadMenu.SetActive(false);
    }
    public void DisableEverything()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        keybindsMenu.SetActive(false);
        gamepadMenu.SetActive(false);
    }
    public void LoseGame()
    {
        isPaused = true;
        DisableEverything();
        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
