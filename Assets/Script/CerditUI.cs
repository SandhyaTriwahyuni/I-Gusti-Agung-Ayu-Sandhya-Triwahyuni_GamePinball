using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CerditUI : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(BackGame);
    }
    public void BackGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
