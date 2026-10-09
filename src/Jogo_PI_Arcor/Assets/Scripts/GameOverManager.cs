
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private bool gameOver = false;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        if (gameOver)
            return;

        gameOver = true;
    }

    public void TentarDeNovo()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Mundo1");
    }

    public void VoltarMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}