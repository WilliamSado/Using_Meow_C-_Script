using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    private float timer = 0f;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            for (int i = 0; i < 3; i++)
            {
                // 生成逻辑同上
                Vector2 p = Random.insideUnitCircle * 3f;
                Instantiate(enemyPrefab, transform.position + new Vector3(p.x, 0, p.y), Quaternion.identity);
            }
            timer = 0f; // 重置计时器
        }
    }
}




