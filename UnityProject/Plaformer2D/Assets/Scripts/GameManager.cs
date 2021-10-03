using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Responner responnerPlayer;
    public Responner responnerOpossum;
    public Responner responnerEagle;

    GameManager instance;
    GameManager GetGameManager()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void ReturnEagleProcess()
    {
        //부활한 독수리에 부활하는 위치가 없다면 알려준다.
        GameObject objEagle = responnerEagle.player;
        if (objEagle)
        {
            Eagle eagle = objEagle.GetComponent<Eagle>();
            if (eagle)
            {
                if (eagle.objResponner == null)
                    eagle.objResponner = responnerEagle.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ReturnEagleProcess();
    }
}
