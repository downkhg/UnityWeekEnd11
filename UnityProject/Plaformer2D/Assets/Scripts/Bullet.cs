using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 vStartPos;
    public Player master;
    // Start is called before the first frame update
    void Start()
    {
        vStartPos = this.transform.position;
        //Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vNowPos = this.transform.position;
        float fDist = Vector3.Distance(vStartPos, vNowPos);
        if (fDist >= 1)
            Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            //Destroy(collision.gameObject);

            //Player player =  GameObject.Find("player").GetComponent<Player>();
            //Player player = GameManager.GetGameManager().responnerPlayer.player.GetComponent<Player>();
            Player player = master;
            Player monster = collision.GetComponent<Player>();

            SuperMode superMode = monster.GetComponent<SuperMode>();
            if (superMode && superMode.isUse == false)
            {
                player.Attack(monster);
                superMode.On();
                if (monster.Death())
                {
                    PlayerInfo playerInfo = new PlayerInfo(monster.m_strName);
                    GameManager.GetGameManager().iventoryMonster.SetIventory(playerInfo);
                }
            }
        }
    }
}
