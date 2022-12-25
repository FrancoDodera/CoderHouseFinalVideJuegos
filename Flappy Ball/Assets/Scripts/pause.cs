using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    private bool pausaActiva;
    public GameObject menuPausa;


    void Start()
    {
        
    }

    
    void Update()
    {
        TogglePausa();
    }

    public void TogglePausa()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausaActiva)
            ResumeGame();
            else
            PauseGame();
        }
    }

    void PauseGame()
    {
        menuPausa.SetActive(true);
        pausaActiva = true;
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        menuPausa.SetActive(false);
        pausaActiva = false;
        Time.timeScale = 1;
    }
}
