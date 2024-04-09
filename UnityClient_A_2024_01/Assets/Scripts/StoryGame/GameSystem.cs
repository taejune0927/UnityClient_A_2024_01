using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using UnityEngine.UI;
using TMPro;


namespace STORYGAME
{
#if UNITY_EDITOR
    [CustomEditor(typeof(GameSystem))]

    public class GameSystemEditor : Editor      //유니티 에티더를 상속
    {
        public override void OnInspectorGUI()       //인스팩터 함수를 재정의
        {
            base.OnInspectorGUI();                //기존 인스팩터를 가져와서 실행

            GameSystem gameSystem = (GameSystem)target;       //게임 시스템 스크립트 타겟을 설정

            if (GUILayout.Button("Reset Stroy Models"))     //버튼을 생성
            {
                gameSystem.ResetStoryModels();
            }

            if(GUILayout.Button("Assing Text Component by name"))
            {
                //오브젝트 이름으로 Text 컴포넌트 찾기
                GameObject textObject = GameObject.Find("StroyTextUI");
                if (textObject != null)
                {
                    Text textComponent = textObject.GetComponent<Text>();
                    if(textComponent != null)
                    {
                        //Text Componet 할당
                        gameSystem.textComponent = textComponent;
                        Debug.Log("Text Component assigned Successfully");
                    }
                }
            }
        }

    }
#endif
    public class GameSystem : MonoBehaviour
    {
        public static GameSystem instance;                  //간단한 싱글톤 화
        public Text textComponent = null;

        public float delay = 0.1f;
        public string fullText;
        public string currentText = "";

        public enum GAMESTATE
        {
            STORYSHIW,
            WAITSELECT,
            STROTYEND,
            ENDMODE
        }

        public GAMESTATE currentState;
        public StoryTableObject[] storyModels;
        public StoryTableObject currentModels;
        public int currentStoryIndex;
        public bool showStroy = false;

        private void Awake()
        {
            instance = this;
        }

        public void Start()                     //게임 시작시
        {
            StartCoroutine(ShowText());           //텍스트를 보여준다,
        }


        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) StoryShow(1);                         //Q 키를 누르면 1번 스토리
            if (Input.GetKeyDown(KeyCode.W)) StoryShow(2);                         //W 키를 누르면 2번 스토리
            if (Input.GetKeyDown(KeyCode.E)) StoryShow(3);                         //E 키를 누르면 3번 스토리

            if (Input.GetKeyDown(KeyCode.Space))
            {
                delay = 0.0f;
            }
        }


        public void StoryShow(int number)
        {
            if (!showStroy)
            {
                currentModels = FindStoryModel(number);                       //스토리 모델 번호를 찾아서
                delay = 0.1f;
                StartCoroutine(ShowText());                                   //루틴을 실행 시킨다
            }
            
        }


        StoryTableObject FindStoryModel(int number)                                //스토리 모델 번호로 찾는 함수
        {
            StoryTableObject tempStoryModels = null;                               //temp 미리 저장 해놓은 변수를 선언
            for(int i = 0; i < storyModels.Length; i ++)
            {
                if(storyModels[i].storyNumber == number)
                {
                    tempStoryModels = storyModels[i];
                    break;
                }
            }

            return tempStoryModels;
        }

        IEnumerator ShowText()
        {
            showStroy = true;
            for(int i = 0; i <= currentModels.storyText.Length; i++)
            {
                currentText = currentModels.storyText.Substring(0, i);
                textComponent.text = currentText;
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(delay);
            showStroy = false;
        }

#if UNITY_EDITOR
        [ContextMenu("Reset Stroy Models")]

        public void ResetStoryModels()
        {
            storyModels = Resources.LoadAll<StoryTableObject>("");
        }
#endif
    }

}