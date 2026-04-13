using UnityEngine;
using UnityEngine.SceneManagement; // 必须引用这个命名空间
using TMPro;

public class SceneController : MonoBehaviour
{
    public int score = 0; // 计数器
    public int targetScore = 18;
    public TextMeshProUGUI scoreText; // 引用 UI 文本

    void Start()
    {
        if (scoreText == null)
        {
            scoreText = Object.FindObjectOfType<TextMeshProUGUI>();
        }
    }

    // 增加分数的方法
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();

        if (score >= targetScore)
        {
            ResetScene();
        }
    }

    // 更新 UI 显示
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Kills: " + score + " / " + targetScore;
        }
    }

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
}