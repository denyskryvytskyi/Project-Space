using UnityEngine;
using UnityEngine.SceneManagement;

public class DialoguesCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(2);
    }
}
