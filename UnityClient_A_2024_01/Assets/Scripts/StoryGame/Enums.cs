using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STORYGAME //이름 충돌 방지
{
    public class Enums             //열겨형 타입
    {
        public enum StoryType         //스토리 타입 
        {
            MAIN,
            SUB,
            SERIAL
        }


        public enum EvenType           //이벤트 발생시 체크
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


        public enum ResultType      //이벤트 결과 열거
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
        //체력과 정신력
        public int hpPoint;
        public int spPoint;

        public int cuttentHpPoint;
        public int cuttentSpPoint;
        public int cuttentXpPoint;

        //기본 스텟 설정 (D&D)
        public int strength;           //STR
        public int dexterity;          //DEX
        public int consitiution;       //CON
        public int intelligence;       //INT
        public int wisdom;             //WIS
        public int charisma;           //

    }
}

