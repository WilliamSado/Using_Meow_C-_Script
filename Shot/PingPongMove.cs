using UnityEngine;

public class PingPongMove : MonoBehaviour
{
    [Header("移动设置")]
    public float moveRange = 3.0f;  // 左右移动的范围
    public float moveSpeed = 2.0f;  // 移动的速度

    private float startX;
    private float randomOffset;

    void Start()
    {
        // 记录物体初始位置
        startX = transform.position.x;
        randomOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        float targetX = startX + Mathf.Sin((Time.time + randomOffset) * moveSpeed) * moveRange;
        Vector3 currentPos = transform.position;
        transform.position = new Vector3(targetX, currentPos.y, currentPos.z);
    }
}