using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExParentClass : MonoBehaviour //��� : ����Ƽ ������Ʈ���� �����ϰ�
{
    //protected�� ����� ������ ���� Ŭ���� �� �Ļ� Ŭ�������� ���� ����
    protected int protectedValue;
}
public class ExChildClass : ExParentClass    //ExParentClass�� ���
{
    private void Start()
    {
        //ExParentClass�� protecte ������ ���� ����
        Debug.Log("protected Value from Child Class : " + protectedValue);
    }
} 
