using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string m_strName;
    public int m_nExp = 0;
    public int m_nLv = 1;
    public int m_nHP;
    public int m_nStr;

    public void Init(string name, int hp, int str)
    {
        m_strName = name;
        m_nHP = hp;
        m_nStr = str;
    }
    public void Attack(Player target)
    {
        target.m_nHP = target.m_nHP - this.m_nStr;
    }
    public bool Death()
    {
        if (m_nHP <= 0)
            return true;
        else
            return false;
    }

    public int m_nIdx = 0;
    private void OnGUI()
    {
        string msg = "Name:"+gameObject.name;
        msg += "\nStr:" + m_nStr;
        msg += "\nHP:" + m_nHP;
        msg += "\nExp/Lv:" + m_nExp + "/" + m_nLv;
        GUI.Box(new Rect(m_nIdx * 100, 0, 100, 100), msg);
    }
}
