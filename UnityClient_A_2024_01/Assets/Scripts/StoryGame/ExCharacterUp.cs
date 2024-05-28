using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCharacterUp : ExCharacter
{
    protected override void Move()
    {
        base.Move();                         //base 키워를 사용하여 기존 함수 동작
        transform.Translate(
            Vector3. up * speed * 2
            * Time.deltaTime);
    }
}
