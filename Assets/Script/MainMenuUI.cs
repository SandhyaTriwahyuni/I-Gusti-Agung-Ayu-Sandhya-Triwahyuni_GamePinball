using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button playbutton;
    public Button exitbutton;
    public Button creditbutton;

    private void Start()
    {
        playbutton.onClick.AddListener(PlayGame);
        exitbutton.onClick.AddListener(ExitGame);
        creditbutton.onClick.AddListener(Credit);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Pinball");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
}
