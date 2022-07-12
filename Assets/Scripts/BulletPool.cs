using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static BulletPool m_instance;

    [SerializeField] private GameObject m_pooledBullet;
    private bool m_notEnoughBulletsInPool = true;

    private List<GameObject> m_bullets;

    public static BulletPool Get()
    {
        return m_instance;
    }

    private void Awake()
    {
        m_instance = this;
    }

    private void Start()
    {
        m_bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (m_bullets.Count > 0)
        {
            for (int i = 0; i < m_bullets.Count; i++)
            {
                if (!m_bullets[i].activeInHierarchy)
                {
                    return m_bullets[i];
                }
            }
        }

        if (m_notEnoughBulletsInPool)
        {
            GameObject bullet = Instantiate(m_pooledBullet);
            bullet.SetActive(false);
            m_bullets.Add(bullet);
            return bullet;
        }

        return null;
    }
}
