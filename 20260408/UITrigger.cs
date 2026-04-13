using UnityEngine;

public class UITrigger : MonoBehaviour
{
    public GameObject uiToDisplay; // 在 Inspector 里把你的 UI 拖进来

    // 当物体进入触发器时调用
    private void OnTriggerEnter(Collider other)
    {
        // 检查进入的对象是不是玩家
        if (other.CompareTag("Player"))
        {
            if (uiToDisplay != null)
            {
                uiToDisplay.SetActive(true); // 显示 UI
                Time.timeScale = 0f;
            }
        }
    }
}