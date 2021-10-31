using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIIventory : MonoBehaviour
{
    public List<GUIMonsterInfo> listMonsterInfoButton;
    public GridLayoutGroup GridLayoutGroupContent;

    void SetIventory(IventoryMonster iventoryMonster)
    {
        List<PlayerInfo> iventoryMonsters = iventoryMonster.listMonster;
        GameObject prefabButton = Resources.Load("Prefabs/GUI/MonsterInfoButton") as GameObject;

        foreach(PlayerInfo item in iventoryMonsters)
        {
            GameObject objButton = Instantiate(prefabButton, GridLayoutGroupContent.transform);
            GUIMonsterInfo gUIMonsterInfo = objButton.GetComponent<GUIMonsterInfo>();
            gUIMonsterInfo.SetPlayerInfo(item);
            listMonsterInfoButton.Add(gUIMonsterInfo);
        }
        RectTransform rectButton = prefabButton.GetComponent<RectTransform>();
        RectTransform rectContent = GridLayoutGroupContent.GetComponent<RectTransform>();
        Vector3 vButtonSize = GridLayoutGroupContent.cellSize;
        Vector3 vConterntSize = rectContent.sizeDelta;

        int nRowSize = (int)(vConterntSize.x / vButtonSize.x);
        int nColSize = iventoryMonsters.Count / nRowSize;
        if (iventoryMonsters.Count % nRowSize  > 0) nColSize++;
        vConterntSize.y = vButtonSize.y * nColSize;
        rectContent.sizeDelta = vConterntSize;
    }

    void ReleaseIventory()
    {
        foreach (GUIMonsterInfo item in listMonsterInfoButton)
        {
            Destroy(item.gameObject);
        }
        listMonsterInfoButton.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            //if (gameObject.activeSelf)
            {
                gameObject.SetActive(true);
                SetIventory(GameManager.GetGameManager().iventoryMonster);
            }
        }
    }
}
