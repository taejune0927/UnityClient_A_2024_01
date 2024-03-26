using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCharacter : MonoBehaviour
{
    public float speed = 5f; //ĳ���� �̵� �ӵ�

    private void Update()
    {
        Move();                           //�����Ӹ��� Move �Լ� ȣ��
    }
    protected virtual void Move()         //virtual Ű���带 �ۼ��Ͽ� ���
    {
        transform.Translate(Vector3.forward * Time.deltaTime);       //ĳ���Ͱ� ������ �̵�

    }
    public void DestoryCharacter()        //ĳ���� �ı�
    {
        Destroy(gameObject);
    }
}

