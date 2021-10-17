using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject objBullet;
    public float ShotPower;

    public void Shot(Vector3 dir, Player player)
    {
        GameObject copyBullet = Instantiate(objBullet);
        copyBullet.transform.position = this.transform.position;
        Bullet bullet = copyBullet.GetComponent<Bullet>();
        bullet.master = player;
        Rigidbody2D rigidbody = copyBullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(dir * ShotPower);
    }
}
