using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFirePattern : MonoBehaviour
{
    [SerializeField] protected float m_fireRate = 0.1f;
    [SerializeField] protected float m_bulletSpeed = 5f;
    [SerializeField] protected float m_bulletDuration = 3f;

    protected void Start()
    {
        InvokeRepeating("Fire", 0, m_fireRate);
    }

    protected virtual void Fire()
    {

    }
}
