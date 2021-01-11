using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuListener : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
