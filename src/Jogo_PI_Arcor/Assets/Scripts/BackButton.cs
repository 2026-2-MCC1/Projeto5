using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void Voltar()
    {
        SceneManager.LoadScene("SceneUI");
    }
}