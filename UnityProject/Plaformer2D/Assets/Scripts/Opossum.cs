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

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject); //플레이어 삭제
            ////결과는 다를수있음. 어쨌든 없는 대상을 복제하는 행위가 올바른 방법이라고 할수없음.
            //Instantiate(collision.gameObject); //플레이어 생성 -> 몬스터생성
            Player monster = this.GetComponent<Player>();
            Player player = collision.gameObject.GetComponent<Player>();
            monster.Attack(player);
        }
    }
}
