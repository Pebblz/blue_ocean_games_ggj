using UnityEngine;
public class Pause : MonoBehaviour
{
    [HideInInspector] public bool isPaused = false;
    [HideInInspector] public bool inventoryOpen = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject gamepadMenu;
    [SerializeField] GameObject keybindsMenu;
    [SerializeField] GameObject loseScreen;
    public GameObject inventory;
    private void Start()
    {
        DisableEverything();
        DisableCursor();
    }
    public void PauseGame()
    {
        if (inventoryOpen)
        {
            inventoryOpen = false;
            inventory.SetActive(false);
        }
        if(!isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            EnableCursor();
        }
        else
        {
            isPaused = false;
            DisableEverything();
            Time.timeScale = 1;
            DisableCursor();
        }
    }
    public void ToggleInventory()
    {
        if(isPaused)
        {
            isPaused = false;
            DisableEverything();
        }
        if(!inventoryOpen)
        {
            inventoryOpen = true;
            inventory.SetActive(true);
            Time.timeScale = 0;
            EnableCursor();
        }
        else
        {
            inventoryOpen = false;
            inventory.SetActive(false);
            Time.timeScale = 1;
            DisableCursor();
        }
    }

    public void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
        inventory.SetActive(false);
    }
    public void LoseGame()
    {
        isPaused = true;
        DisableEverything();
        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
