using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMode : MonoBehaviour
{
    public float Time;
    public bool isUse;

    IEnumerator ProcessTimmer()
    {
        isUse = true;
        yield return new WaitForSeconds(Time);
        GetComponent<SpriteRenderer>().color = Color.white;
        isUse = false;
    }

    public void On()
    {
        StartCoroutine(ProcessTimmer());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isUse)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            Color color = spriteRenderer.color;
            if (color.a == 1) color.a = 0;
            else color.a = 1;
            spriteRenderer.color = color;
        }
    }
}
