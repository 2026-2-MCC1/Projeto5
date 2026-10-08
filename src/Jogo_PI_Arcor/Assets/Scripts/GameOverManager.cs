
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private bool gameOver = false;

    public void GameOver()
    {
        if (gameOver)
            return;

        gameOver = true;

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TentarDeNovo()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void VoltarMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}