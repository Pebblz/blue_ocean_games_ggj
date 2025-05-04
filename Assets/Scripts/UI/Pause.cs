using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    private void Start()
    {
        pauseMenu.SetActive(false);
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
            Time.timeScale = 1;
        }
    }
}
