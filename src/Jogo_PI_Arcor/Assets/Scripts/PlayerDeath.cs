
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

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
            Debug.Log($"Morreu porque interagiu com {collision.gameObject.name}");
            Morrer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log($"Morreu porque interagiu com {other.gameObject.name}");
            Morrer();
        }
    }

    void Morrer()
    {
        if (morreu)
            return;

        morreu = true;
        SceneManager.LoadScene("GameOver");
    }
}