using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        BoxCollider2D boxCollider = this.GetComponent<BoxCollider2D>();
        Vector2 vPos = this.transform.position;
        int nLayer = 1 << LayerMask.NameToLayer("Player");
        Collider2D collider = Physics2D.OverlapBox(vPos + boxCollider.offset, boxCollider.size, 0, nLayer);

        if(collider)
        {
            SuperMode superMode = collider.GetComponent<SuperMode>();
            if (superMode && superMode.isUse == false)
            {
                Player monster = this.GetComponent<Player>();
                Player player = collider.gameObject.GetComponent<Player>();
                monster.Attack(player);
                superMode.On();
            }      
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
    }
    //몬스터와 플레이어가 충돌되어 데미지를 줄경우 정상적이지않은 결과를 가져온다.
    //그러므로, 몬스터와 플레이어는 콜라이더를 이용하여 충돌체크가 불가능해진다.
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        //Destroy(collision.gameObject); //플레이어 삭제
    //        ////결과는 다를수있음. 어쨌든 없는 대상을 복제하는 행위가 올바른 방법이라고 할수없음.
    //        //Instantiate(collision.gameObject); //플레이어 생성 -> 몬스터생성
    //        Player monster = this.GetComponent<Player>();
    //        Player player = collision.gameObject.GetComponent<Player>();
    //        monster.Attack(player);
    //    }
    //}
}
