using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private Light testLight; // 存储灯光组件

    [Header("闪烁设置")]
    public float minIntensity = 0.5f; // 最小强度
    public float maxIntensity = 2.5f; // 最大强度
    public float flickerSpeed = 0.05f; // 闪烁速度（数值越小越快）

    void Start()
    {
        // 获取当前物体上的 Light 组件
        testLight = GetComponent<Light>();
    }

    void Update()
    {
        if (testLight != null)
        {
            // 每一帧都随机给灯光一个强度值
            // Random.Range 会在 min 和 max 之间随机取值
            testLight.intensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}