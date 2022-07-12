using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFirePattern : BaseFirePattern
{
    [SerializeField] private int m_bulletsAmount = 10;

    protected override void Fire()
    {
        float angleStep = 360 / m_bulletsAmount;
        float angle = 0;

        for (int i = 0; i < m_bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bullet = BulletPool.Get().GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().Setup(bulDir, m_bulletSpeed, m_bulletDuration);

            angle += angleStep;
        }
    }
}
