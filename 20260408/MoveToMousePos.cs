using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMousePos : MonoBehaviour {

    Ray ray;
    RaycastHit hitInfo;
    Vector3 targetPoint;//鼠标位置点
    Camera mainCam;//主摄像机
	// Use this for initialization
	void Start () {
        Debug.Log("我是玩家，我的标签是: " + gameObject.tag);
        targetPoint = transform.position;//初始化目标点 自身的位置
        mainCam = Camera.main;//储存摄像机的变量
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
        {
            ray = mainCam.ScreenPointToRay(Input.mousePosition);//从屏幕上的点发射线
            if (Physics.Raycast(ray, out hitInfo, float.MaxValue, 1 << 9)) //是否点击到地面上 射线 检测到的星系 距离最大值 检测层级（只检测地面Plane(第九层级)）
            {
                targetPoint = hitInfo.point;//鼠标点击的地面位置点
                transform.forward = ChangePos(targetPoint - transform.position).normalized; //转身
            }
        }
        if (Vector3.Distance(ChangePos(transform.position), ChangePos(targetPoint)) > 0.5f) //距离终点0.5f才需要移动
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPoint.x, transform.position.y, targetPoint.z), Time.deltaTime * 5);
        }
	}
    Vector3 ChangePos(Vector3 pos) //构建一个 v3type 三维矢量
    {
        return new Vector3(pos.x, 0, pos.z); //忽略Y轴
    }
}
