using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class PlayerInfo
{
    string strName;
    public string Name
    {
        get { return strName; }
        //set { strName = value; }
    }
    public PlayerInfo(string name)
    {
        strName = name;
    }
}

public class IventoryMonster : MonoBehaviour
{
    public List<PlayerInfo> listMonster = new List<PlayerInfo>();

    public void SetIventory(PlayerInfo monster)
    {
        listMonster.Add(monster);
    }

    public PlayerInfo GetPlayer(int idx)
    {
        return listMonster[idx];
    }

    private void OnGUI()
    {
        int w = 100;
        int h = 20;
        for (int i = 0; i < listMonster.Count; i++)
        {
            GUI.Box(new Rect(0, h * i, w, h), listMonster[i].Name);
        }
    }
}
