using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPlayer : MonoBehaviour
{

    private int health = 100;      //�÷��̾��� ü��

    // �÷��̾ ���ظ� ���� �� ȣ��Ǵ� �޼���
    public void TakeDemage(int damage)
    {
        //�÷��̾��� ü�� ����
        health -= damage;

        //ü���� 0 ���Ϸ� �������� �� �÷��̾� ��� ó��
        if(health <= 0)
        {
            Die();
        }
    }


    //�÷��̾ ������� �� ȣ��Ǵ� �Լ�
    private void Die()
    {
        Debug.Log("�÷��̾ ����߽��ϴ�");
        //��� ó�� ���� �߰�
    }
    
}
