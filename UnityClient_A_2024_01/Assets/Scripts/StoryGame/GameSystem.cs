using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using STORYGAME;

#if UNITY_EDITOR

public class GameSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameSystem gameSystem = (GameSystem)target;

        if(GUILayout.Button("Reset Story Models"))        //�����Ϳ��� ��ư ����
        {
            gameSystem.ResetStoryModels();
        }
    }
}
#endif



public class GameSystem : MonoBehaviour
{
    public StoryModel[] storyModels;                  //����� ���丮 �𵨷� ����

    public static GameSystem instance;                //������ �̱��� ȭ


    private void Awake()                               //Scene�� ���� �ɶ� �ڵ� �����ܿ��� GameSystem�� �̱���ȭ
    {
        instance = this;
    }



    public enum GAMESTATE
    {
        STROYSHOW,
        WAITSELECT,
        STORYEND,
        BATTLEMODE,
        BATTLEMONE,
        SHOPMODE,
        ENDMODE
    }

    public Stats stats;
    public GAMESTATE currentState;

    public int currentStoryIndex = 1;        //����ǰ� �ִ� ���丮 ��ȣ

    StoryModel FindStoryModel(int number)
    {
        StoryModel tempStoryModels = null;
        List<StoryModel> storyModelList = new List<StoryModel>();    //�������� ������ ���� List ����

        for(int i = 0; i < storyModels.Length; i++)                  //for������ �迭 �ȿ� �ִ� ������ �� �����Ϳ���
        {
            if(storyModels[i].storytype == StoryModel.STORYTYPE.MAIN)   //���丮 Ÿ���� Main�� ��쿡�� �ش� List�� �߰�
            {
                storyModelList.Add(storyModels[i]);
            }
        }

        tempStoryModels = storyModelList[Random.Range(0, storyModelList.Count)];
        currentStoryIndex = tempStoryModels.storyNumber;
        Debug.Log("currentStoryIndex" + currentStoryIndex);


        return tempStoryModels;                   //return ��Ų��
    }

#if UNITY_EDITOR
    [ContextMenu("Reset Story Models")]
    public void ResetStoryModels()
    {
        storyModels = Resources.LoadAll<StoryModel>("");   //Resources ���� �Ʒ� ��� StoryModel �ҷ�����
    }
#endif
}