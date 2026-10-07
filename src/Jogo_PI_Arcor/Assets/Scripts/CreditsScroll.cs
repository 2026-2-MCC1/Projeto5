using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CreditsScroll : MonoBehaviour
{
    public float speed = 50f;
    public float FinalLimit = 1000f;
    public float TimeBack = 2f;

    private bool finish = false;

    void Update()
    {
        if (finish)
            return;

        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.localPosition.y >= FinalLimit)
        {
            finish = true;
            StartCoroutine(VoltarAoMenu());
        }
    }

    IEnumerator VoltarAoMenu()
    {
        yield return new WaitForSeconds(TimeBack);

    SceneManager.LoadScene("SceneUI");
   }
}
