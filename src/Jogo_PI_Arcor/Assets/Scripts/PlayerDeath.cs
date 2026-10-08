
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameOverManager gameOverManager;

    public float alturaDaQueda = -10f;

    private bool morreu = false;

    void Update()
    {
        if (transform.position.y < alturaDaQueda)
        {
            Morrer();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Morrer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Morrer();
        }
    }

    void Morrer()
    {
        if (morreu)
            return;

        morreu = true;
        gameOverManager.GameOver();
    }
}