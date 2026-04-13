using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // 子弹预制体
    public Transform firePoint;     // 子弹发射点（枪口位置）
    public float bulletSpeed = 20f;

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 鼠标左键射击
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 1. 获取鼠标点击的世界坐标
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        // 依然检测地面层级 (Layer 9)
        if (Physics.Raycast(ray, out hitInfo, float.MaxValue, 1 << 9))
        {
            Vector3 targetPoint = hitInfo.point;

            // 2. 计算从玩家到点击点的“水平方向向量”
            Vector3 targetDir = targetPoint - transform.position;
            targetDir.y = 0; // 彻底忽略 Y 轴高度差
            targetDir.Normalize();

            // 3. 角度判定：计算玩家正前方 (transform.forward) 与 目标方向 的夹角
            // Vector3.Angle 返回的是 0 到 180 度之间的正值
            float angle = Vector3.Angle(transform.forward, targetDir);

            // 4. 限制在 45 度以内（正左 22.5 度 到 正右 22.5 度，总共 45 度）
            // 如果你想指“中心线两侧各 45 度”，则将 22.5f 改为 45f
            if (angle > 22.5f)
            {
                targetDir = transform.forward;
            }
            SpawnBullet(targetDir);
        }
    }

    // 提取出的发射逻辑函数
    void SpawnBullet(Vector3 shootDir)
    {
        // 在发射点生成子弹，并让子弹朝向计算出的水平方向
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(shootDir));

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = shootDir * bulletSpeed;
        }
    }
}