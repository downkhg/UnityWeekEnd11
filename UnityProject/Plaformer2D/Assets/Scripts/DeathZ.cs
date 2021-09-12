using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZ : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < DeathZone.DeathY)
            Destroy(gameObject);
    }
}
