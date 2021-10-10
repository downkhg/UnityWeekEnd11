using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrakerCamera : MonoBehaviour
{
    public GameObject objTarget;
    public float Speed;

    void UpdateMove()
    {
        if (objTarget)
        {
            Vector3 vTargetPos = objTarget.transform.position;
            Vector3 vPos = transform.position;
            Vector3 vDist = vTargetPos - vPos; //타겟으로의 방향벡터를구한다.
            Vector3 vDir = vDist.normalized; //구한 방향벡터에서 순수한 방향을 구한다.
            float fDist = vDist.magnitude; //방향벡터에서 스칼라의 값을 가져온다.(사이거리)

            float fMove = Speed * Time.deltaTime;
            if (fDist > fMove)//이동량보다 거리가 짧으면 이동하지않는다.
            {
                transform.position += vDir * fMove;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
    }
}
