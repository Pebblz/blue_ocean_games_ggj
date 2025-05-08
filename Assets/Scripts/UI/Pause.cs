using UnityEngine;
public class Pause : MonoBehaviour
{
    bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject gamepadMenu;
    [SerializeField] GameObject keybindsMenu;
    private void Start()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
        if(settingsMenu != null)
            settingsMenu.SetActive(false);
        if (keybindsMenu != null)
            keybindsMenu.SetActive(false);
        if (gamepadMenu != null)
            gamepadMenu.SetActive(false);
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
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(false);
            keybindsMenu.SetActive(false);
            gamepadMenu.SetActive(false);
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
}
