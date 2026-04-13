using UnityEngine;
using UnityEngine.AI; // 必须引用导航命名空间

public class SimpleEnemyAI : MonoBehaviour
{
    public float chaseRange = 10f;  // 发现玩家的距离
    public string playerTag = "Player";

    private Transform Player;
    private NavMeshAgent agent;

    public float attackDamage = 10f;
    public float attackSpeed = 1f; // 每秒攻击一次
    private float nextAttackTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // 通过标签找到玩家
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
        {
            Player = playerObj.transform;
        }
        if (Player == null) Debug.LogError("找不到玩家！请检查 Tag。");
    }

    void Update()
    {
        if (Player == null) return;

        // 计算敌人与玩家之间的距离
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        // 如果玩家在追击范围内
        if (distanceToPlayer <= chaseRange)
        {
            // 设置导航目标为玩家位置
            agent.SetDestination(Player.position);
        }
        else
        {
            // 超出范围可以停止移动，或者让它回到巡逻点
            agent.ResetPath();
        }

        float distance = Vector3.Distance(transform.position, Player.position);
        if (distance <= agent.stoppingDistance + 0.5f) // 靠近玩家
        {
            if (Time.time >= nextAttackTime)
            {
                AttackPlayer();
                nextAttackTime = Time.time + attackSpeed;
            }
        }
    }

    void AttackPlayer()
    {
        PlayerHealth ph = Player.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            ph.TakeDamage(attackDamage);
        }
    }

    void OnDisable()
    {
        // 遍历所有子物体
        foreach (Transform child in transform)
        {
            // 将子物体的本地坐标、旋转、缩放全部重置
            child.localPosition = Vector3.zero;
            child.localRotation = Quaternion.identity;
        }
    }
}