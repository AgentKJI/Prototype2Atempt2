using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void play()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("SampleScene");

    }

    public void mainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void quit()
    {
        Application.Quit();
    }
        
    public void resume()
    {

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);


    }


}

