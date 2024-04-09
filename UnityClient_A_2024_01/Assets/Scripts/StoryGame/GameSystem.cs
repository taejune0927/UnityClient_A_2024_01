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

    public class GameSystemEditor : Editor      //����Ƽ ��Ƽ���� ���
    {
        public override void OnInspectorGUI()       //�ν����� �Լ��� ������
        {
            base.OnInspectorGUI();                //���� �ν����͸� �����ͼ� ����

            GameSystem gameSystem = (GameSystem)target;       //���� �ý��� ��ũ��Ʈ Ÿ���� ����

            if (GUILayout.Button("Reset Stroy Models"))     //��ư�� ����
            {
                gameSystem.ResetStoryModels();
            }

            if(GUILayout.Button("Assing Text Component by name"))
            {
                //������Ʈ �̸����� Text ������Ʈ ã��
                GameObject textObject = GameObject.Find("StroyTextUI");
                if (textObject != null)
                {
                    Text textComponent = textObject.GetComponent<Text>();
                    if(textComponent != null)
                    {
                        //Text Componet �Ҵ�
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
        public static GameSystem instance;                  //������ �̱��� ȭ
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

        public void Start()                     //���� ���۽�
        {
            StartCoroutine(ShowText());           //�ؽ�Ʈ�� �����ش�,
        }


        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) StoryShow(1);                         //Q Ű�� ������ 1�� ���丮
            if (Input.GetKeyDown(KeyCode.W)) StoryShow(2);                         //W Ű�� ������ 2�� ���丮
            if (Input.GetKeyDown(KeyCode.E)) StoryShow(3);                         //E Ű�� ������ 3�� ���丮

            if (Input.GetKeyDown(KeyCode.Space))
            {
                delay = 0.0f;
            }
        }


        public void StoryShow(int number)
        {
            if (!showStroy)
            {
                currentModels = FindStoryModel(number);                       //���丮 �� ��ȣ�� ã�Ƽ�
                delay = 0.1f;
                StartCoroutine(ShowText());                                   //��ƾ�� ���� ��Ų��
            }
            
        }


        StoryTableObject FindStoryModel(int number)                                //���丮 �� ��ȣ�� ã�� �Լ�
        {
            StoryTableObject tempStoryModels = null;                               //temp �̸� ���� �س��� ������ ����
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