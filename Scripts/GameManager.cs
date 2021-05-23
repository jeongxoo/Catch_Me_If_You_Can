using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public GameData gameData;


    // 게임매니저
    #region 싱글톤(게임매니저)
    private void Awake() // 이거는 게임매니저 싱글톤 코드
    {

        var objs = FindObjectsOfType<GameManager>();
        if(objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        Application.targetFrameRate = 60;
        Time.timeScale = 1;

        instance = this;
    }

    public static GameManager Instance // 이거는 외부에서 게임매니저를 참조할 수 있게 해주는 Instance 생성 코드
    {
        get
        {
            return instance;
        }
    }


    #endregion 싱글톤(게임매니저)

    private void Start()
    {
        LoadGameDataFromJson();
    }

    // JSON 데이터 save&load
    #region JSON

    // 데이터 저장 함수
    [ContextMenu("To Json Data")]
    public void SaveGameDataToJson() // 현재 GameData를 JSON파일로 저장해주는 함수
    {
        string jsonData = JsonUtility.ToJson(gameData, true);
        string path = Path.Combine(Application.persistentDataPath, "GameData.json");
        File.WriteAllText(path, jsonData);
    }

    // 데이터 로드 함수
    [ContextMenu("From Json Data")]
    public void LoadGameDataFromJson() // JSON파일의 정보를 현재 GameData로 불러오는 함수
    {
        string path = Path.Combine(Application.persistentDataPath, "GameData.json");
        string jsonData = File.ReadAllText(path);
        gameData = JsonUtility.FromJson<GameData>(jsonData);
    }

    #endregion JSON

    public void Update() {
        if (gameData.currentHP == 0) {
            Time.timeScale = 0.0f;
        } else {
            Time.timeScale = 1.0f;
        }
    }

    public void ResetGameData() // Station이랑 Stage초기화 할 때 쓰는 함수~
    {

        SaveGameDataToJson();
    }

}

[System.Serializable]
public class GameData // 게임 데이타 저장용 클래스 
{
    public float maxHP = 100f;
    public float currentHP = 100f;
    public int stageInfo; // 0 == stack, 1 == queue, else ~~
    public float point = 0;
}
