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

        if(GUILayout.Button("Reset Story Models"))        //에디터에서 버튼 생성
        {
            gameSystem.ResetStoryModels();
        }
    }
}
#endif



public class GameSystem : MonoBehaviour
{
    public StoryModel[] storyModels;                  //변경된 스토리 모델로 생성

    public static GameSystem instance;                //간단한 싱글톤 화


    private void Awake()                               //Scene이 생성 될때 코드 설정단에서 GameSystem을 싱글톤화
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

    public int currentStoryIndex = 1;        //진행되고 있는 스토리 번호

    StoryModel FindStoryModel(int number)
    {
        StoryModel tempStoryModels = null;
        List<StoryModel> storyModelList = new List<StoryModel>();    //랜덤으로 돌리기 위한 List 생성

        for(int i = 0; i < storyModels.Length; i++)                  //for문으로 배열 안에 있는 선언한 모델 데이터에서
        {
            if(storyModels[i].storytype == StoryModel.STORYTYPE.MAIN)   //스토리 타입이 Main인 경우에만 해당 List에 추가
            {
                storyModelList.Add(storyModels[i]);
            }
        }

        tempStoryModels = storyModelList[Random.Range(0, storyModelList.Count)];
        currentStoryIndex = tempStoryModels.storyNumber;
        Debug.Log("currentStoryIndex" + currentStoryIndex);


        return tempStoryModels;                   //return 시킨다
    }

#if UNITY_EDITOR
    [ContextMenu("Reset Story Models")]
    public void ResetStoryModels()
    {
        storyModels = Resources.LoadAll<StoryModel>("");   //Resources 폴더 아래 모든 StoryModel 불러오기
    }
#endif
}