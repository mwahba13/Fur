using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{


    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnInstructionButtonPressed()
    {
        
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
