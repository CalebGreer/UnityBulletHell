using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralFirePattern : BaseFirePattern
{
    private float m_angle = 0f;

    protected override void Fire()
    {
        float bulDirX = transform.position.x + Mathf.Sin((m_angle * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Cos((m_angle * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        GameObject bullet = BulletPool.Get().GetBullet();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.SetActive(true);
        bullet.GetComponent<Bullet>().Setup(bulDir, m_bulletSpeed, m_bulletDuration);

        m_angle += 10f;
    }
}
