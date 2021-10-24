using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIStatusBar : MonoBehaviour
{
    public RectTransform rectBar;
    public Text textName;
    public Color colorBar = Color.white;
    public RectTransform rectBarBG;

    public void SetStatusBar(Color color)
    {
        textName.text = gameObject.name;
        rectBar.GetComponent<Image>().color = color;
    }

    public void ProcessBar(float cur, float max)
    {
        float fRat = cur / max;
        Vector2  vSize = rectBar.sizeDelta;
        vSize.x = rectBarBG.sizeDelta.x * fRat;
        rectBar.sizeDelta = vSize;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetStatusBar(colorBar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
