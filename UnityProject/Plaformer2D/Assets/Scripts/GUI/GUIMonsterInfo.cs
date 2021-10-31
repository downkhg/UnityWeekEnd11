using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIMonsterInfo : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public Text textName;

    public void SetPlayerInfo(PlayerInfo playerInfo)
    {
        this.playerInfo = playerInfo;
        textName.text = playerInfo.Name;
    }

    //private void Start()
    //{
    //    PlayerInfo playerInfo = new PlayerInfo("test");
    //    SetPlayerInfo(playerInfo);
    //}
}
