using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPopUp : MonoBehaviour
{
    public GameObject endCanvas;
    
    
    // Start is called before the first frame update
    void Start()
    {
        EnemySolver.OnEndGameEvent += OnEndGame;
        endCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEndGame()
    {
        endCanvas.SetActive(true);
    }

    public void OnContinueButtonPressed()
    {
        endCanvas.SetActive(false);
    }

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
}
