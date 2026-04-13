using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform[] pos;
    Transform points_Parent;
    Vector3 moveDir;
    int current_Index;
    bool isfinal = false;
    public GameObject textObj;


    void UITestTrue()
    {
        textObj.SetActive(true);
    }

    void GetDir()
    {
        moveDir = (pos[current_Index].position - transform.position).normalized;
        moveDir = ChangeDir(moveDir);
    }

    Vector3 ChangeDir(Vector3 dir)
    {
        return new Vector3(dir.x, 0, dir.z);
    }

    // Use this for initialization
    void Start()
    {
        points_Parent = GameObject.Find("WayPointsParent").transform;
        pos = new Transform[points_Parent.childCount];
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = points_Parent.GetChild(i);
        }
        GetDir();
    }

    // Update is called once per frame
    void Update()
    {
        if (isfinal == false)
        {
            transform.forward = moveDir;
            transform.Translate(Vector3.forward * Time.deltaTime * 5, Space.Self);

            if (Vector3.Distance(ChangeDir(transform.position), ChangeDir(pos[current_Index].position)) < 2f)
            {
                current_Index++;
                if (current_Index == pos.Length)
                {
                    UITestTrue();
                    isfinal = true;
                    return;
                }
                GetDir();
            }
        }
    }
}
