using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Update()
    {
        // Vector3.down = 0,-1,0
        transform.Translate(Vector3.down * Time.deltaTime);
    }

    // ���� ������Ʈ�� ȭ�� ������ ����� �� ȣ��Ǵ� �Լ�
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // ���� ������Ʈ�� �浹�� ���� �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}