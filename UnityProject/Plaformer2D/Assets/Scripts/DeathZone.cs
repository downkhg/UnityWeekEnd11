using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public static float DeathY;

    private void Start()
    {
        DeathY = transform.position.y;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 vPos = transform.position;
        Vector3 vStartPos = vPos; vStartPos.x -= 9999999.0f;
        Vector3 vEndPos = vPos; vEndPos.x += 9999999.0f;
        Gizmos.DrawLine(vStartPos, vEndPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy (collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
