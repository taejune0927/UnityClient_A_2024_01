using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STORYGAME //�̸� �浹 ����
{
    public class Enums             //������ Ÿ��
    {
        public enum StoryType         //���丮 Ÿ�� 
        {
            MAIN,
            SUB,
            SERIAL
        }


        public enum EvenType           //�̺�Ʈ �߻��� üũ
        {
            NONE,
            GoToBattle = 100,
            CheckSTR = 1000,
            CheckDEX,
            CheckCON,
            CheckINT,
            CHECKWIS,
            CheckCHA
        }


        public enum ResultType      //�̺�Ʈ ��� ����
        {
            ChangeHp,
            ChangeSp,
            AddExperience,
            GoToShop,
            GoToNextStory,
            GotoRandomStory,
            GotoEnding
        }
    }

    [System.Serializable]

    public class Stats
    {
        //ü�°� ���ŷ�
        public int hpPoint;
        public int spPoint;

        public int cuttentHpPoint;
        public int cuttentSpPoint;
        public int cuttentXpPoint;

        //�⺻ ���� ���� (D&D)
        public int strength;           //STR
        public int dexterity;          //DEX
        public int consitiution;       //CON
        public int intelligence;       //INT
        public int wisdom;             //WIS
        public int charisma;           //

    }
}

