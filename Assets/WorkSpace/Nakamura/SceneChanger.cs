using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ScneChange (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
