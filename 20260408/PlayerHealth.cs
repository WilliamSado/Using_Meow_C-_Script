using UnityEngine;
using UnityEngine.UI; // 必须引用 UI 命名空间

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public GameObject textObj;

    public Slider healthSlider; // 在 Inspector 中把 UI Slider 拖到这里

    void UITestTrue()
    {
        textObj.SetActive(true);
    }

    void Start()
    {
        currentHealth = maxHealth;

        // 初始化血条设置
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    // 受到伤害的方法
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 限制在0到最大值之间

        // 更新 UI
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("玩家死亡！");
        if (healthSlider != null)
        {
            Destroy(healthSlider.gameObject);
        }
        Destroy(gameObject);
        UITestTrue();
        // 这里可以写重新加载关卡或显示游戏结束画面的逻辑
    }
}