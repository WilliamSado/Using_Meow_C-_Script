using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private SceneController controller;

    void Start()
    {
        controller = Object.FindObjectOfType<SceneController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 只有标签为 ScoreItem 且名字不是子弹的物体才计数
        if (other.CompareTag("ScoreItem") && !other.name.Contains("Sphere_bullet"))
        {
            controller.AddScore(1);
            Destroy(other.gameObject); // 计数后销毁，防止重复计数
        }
    }
}
