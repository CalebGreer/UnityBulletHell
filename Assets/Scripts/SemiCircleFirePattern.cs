using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiCircleFirePattern : BaseFirePattern
{
    [SerializeField] private int m_bulletsAmount = 10;
    [SerializeField] private float m_startAngle = 90f;
    [SerializeField] private float m_endAngle = 270f;

    private Vector2 m_bulletMoveDirection;

    protected override void Fire()
    {
        float angleStep = (m_endAngle - m_startAngle) / m_bulletsAmount;
        float angle = m_startAngle;

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
