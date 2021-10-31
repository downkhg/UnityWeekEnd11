using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Responner responnerPlayer;
    public Responner responnerOpossum;
    public Responner responnerEagle;
    public TrakerCamera trakerCamera;

    public GUIStatusBar guiHPBar;

    static GameManager instance;

    public static GameManager GetGameManager()
    {
        return instance;
    }

    public IventoryMonster iventoryMonster;

    public enum E_GUI_SCENE { TITLE, THEEND, GAME_OVER, PLAY }
    public E_GUI_SCENE curGuiSecne;
    public List<GameObject> listGUIScene;
    void ShowScene(int idx)
    {
        for (int i = 0; i < listGUIScene.Count; i++)
        {
            if (i == idx)
                listGUIScene[i].SetActive(true);
            else
                listGUIScene[i].SetActive(false);
        }
    }
    public void SetGUISceneStatus(E_GUI_SCENE scene)
    {
        switch (scene)
        {
            case E_GUI_SCENE.TITLE:
                break;
            case E_GUI_SCENE.THEEND:
                break;
            case E_GUI_SCENE.GAME_OVER:
                break;
            case E_GUI_SCENE.PLAY:
                break;
        }
        ShowScene((int)scene);
        curGuiSecne = scene;
    }
    public void UpdataGUISceneStatus(E_GUI_SCENE scene)
    {
        switch (curGuiSecne)
        {
            case E_GUI_SCENE.TITLE:
                break;
            case E_GUI_SCENE.THEEND:
                break;
            case E_GUI_SCENE.GAME_OVER:
                break;
            case E_GUI_SCENE.PLAY:
                break;
        }
        ShowScene((int)scene);
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SetGUISceneStatus(curGuiSecne);

        for(int i =0; i<30; i++)
            iventoryMonster.SetIventory(new PlayerInfo(string.Format("{0}",i)));
    }

    public void EventToTitle()
    {
        SetGUISceneStatus(E_GUI_SCENE.TITLE);
    }

    public void EventExit()
    {
        Application.Quit(0);
    }

    public void EventPlay()
    {
        SetGUISceneStatus(E_GUI_SCENE.PLAY);
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

                if (eagle.objPatrolPoint== null)
                    eagle.objResponner = responnerPlayer.gameObject;
            }
        }
    }

    void CameraSettingProcess()
    {
        if (trakerCamera.objTarget == null)
        {
            trakerCamera.objTarget = responnerPlayer.player;
        }
    }

    void UpdataPlayerStatus()
    {
        if (responnerPlayer.player)
        {
            Player player = responnerPlayer.player.GetComponent<Player>();
            guiHPBar.ProcessBar(player.m_nHP, player.m_nMaxHP);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ReturnEagleProcess();
        CameraSettingProcess();
        UpdataPlayerStatus();
    }
}