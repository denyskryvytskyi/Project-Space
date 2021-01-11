using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnClickLoadSceneItem(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
