using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public float Speed;
    public GameObject objTarget;
    public float Site;

    public GameObject objResponner;
    public GameObject objPatrolPoint;

    public bool isMove = false;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Site);
    }

    private void FixedUpdate()
    {
        FindLayerCircle();
        //FindCircleAll();
    }

    void FindLayerCircle()
    {
        //특정레이어만 충돌체크되도록 설정하기
        int nLayer = 1 << LayerMask.NameToLayer("Player");
        Collider2D collider =
            Physics2D.OverlapCircle(transform.position, Site, nLayer);
        //만약 여기서 충돌검사시 충돌검사된, 객체의 태그가 "Player"가 아니라면 타겟이 사라질수도있다.
        if (collider)
        {
            if (collider.gameObject.tag == "Player")
                objTarget = collider.gameObject;
        }
    }

    void FindCircleAll()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Site);

        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].tag == "Player")
                objTarget = colliders[i].gameObject;
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
        UpdateReturn();
        UpdatePatrol();
    }

    void UpdateReturn()
    {
        if (objTarget == null)
        {
            objTarget = objResponner;
        }
    }

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
                isMove = true;
            }
            else
            {
                isMove = false;
            }
        }
    }

    void UpdatePatrol()
    {
        if (isMove == false)
        {
            if (objTarget.name == objResponner.name)
            {
                objTarget = objPatrolPoint;
            }
            else if (objTarget.name == objPatrolPoint.name)
            {
                objTarget = objResponner;
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
