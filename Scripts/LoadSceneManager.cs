using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneManager : MonoBehaviour
{
    public InGameText inGameText;
    public void ToMain() {
        SceneManager.LoadScene("MainScene");
        GameManager.Instance.gameData.currentHP = 100f;
        GameManager.Instance.SaveGameDataToJson();
    }

    public void ToStageSelect() {
        SceneManager.LoadScene("StageSelectScene");
    }

    public void ToStack() {
        SceneManager.LoadScene("PlayScene");
        GameManager.Instance.gameData.stageInfo = 0;
        GameManager.Instance.SaveGameDataToJson();
    }

    public void ToQue() {
        SceneManager.LoadScene("PlayScene");
        GameManager.Instance.gameData.stageInfo = 1;
        GameManager.Instance.SaveGameDataToJson();
    }

    public void ToDeq() {
        SceneManager.LoadScene("PlayScene");
        // GameManager.Instance.gameData.stageInfo = 2;
        GameManager.Instance.SaveGameDataToJson();
    }
    public void ToTree() {
        SceneManager.LoadScene("PlayScene");
        // GameManager.Instance.gameData.stageInfo = 3;
        GameManager.Instance.SaveGameDataToJson();
    }

    public void PlayToMain() {
        SceneManager.LoadScene("MainScene");
        GameManager.Instance.gameData.currentHP = 100f;
        GameManager.Instance.gameData.point += inGameText.stageScore;
        GameManager.Instance.SaveGameDataToJson();
    }

}
