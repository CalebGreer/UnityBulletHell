using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 m_moveDirection;
    private float m_moveSpeed;

    private void FixedUpdate()
    {
        transform.Translate(m_moveDirection * m_moveSpeed * Time.deltaTime);
    }

    public void Setup(Vector2 direction, float speed, float duration)
    {
        m_moveDirection = direction;
        m_moveSpeed = speed;
        Invoke("Destroy", duration);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
