using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f; // 最大血量
    private float currentHealth;   // 当前血量

    void Start()
    {
        // 初始化血量
        currentHealth = maxHealth;
    }

    // 公开方法：供子弹或其他伤害来源调用
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " 受到伤害，剩余血量: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 这里可以播放死亡动画或特效
        Debug.Log("敌人已死亡！");
        Destroy(gameObject); // 销毁物体
    }
}