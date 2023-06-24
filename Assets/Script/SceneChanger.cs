using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ScneChange (string sceneName)
    {
        AudioManager.Instance.PlaySE(AudioManager.SeSoundData.SE.Click);
        SceneManager.LoadScene(sceneName);
    }
}
