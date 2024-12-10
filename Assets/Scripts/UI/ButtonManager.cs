using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Play()
    {
        SceneManager.LoadScene("Main Level");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
