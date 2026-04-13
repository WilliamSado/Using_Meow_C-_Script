using UnityEngine;
using UnityEngine.SceneManagement; // 必须引用这个命名空间

public class SceneCtrl : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetScene()
    {
        // 获取当前活动场景的名字
        string currentSceneName = SceneManager.GetActiveScene().name;

        // 重新加载该场景
        SceneManager.LoadScene(currentSceneName);
    }
    public void SwitchScene()
    {
        SceneManager.LoadScene("Scenes/20260408");
    }
}