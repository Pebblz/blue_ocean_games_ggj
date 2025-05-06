using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int gameScene = 1;
    public void PlayeGameBTN()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void SettingsBTN()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
