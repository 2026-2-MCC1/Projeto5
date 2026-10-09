using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;

    bool BackPause = false;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!BackPause)
            {
                container.SetActive(true);
                BackPause = true;
                Time.timeScale = 0;
            }
            else
            {
                container.SetActive(false);
                BackPause = false;
                Time.timeScale = 1;
            }
 
        }
    }

    public void RetomarButton()
    {
        container.SetActive(false);
        BackPause = false;
        Time.timeScale = 1;
    }
    
   public void VoltarButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}