using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Créditos()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Sair()
    {
        Application.Quit();
    }
    

}


