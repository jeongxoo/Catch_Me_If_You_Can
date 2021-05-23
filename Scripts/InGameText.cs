using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text stageText;
    public Text stagePoint;
    public float stageScore;
    public Button goBack;

    int stageNum;
    void Start()
    {
        GameManager.Instance.LoadGameDataFromJson();
        stageNum = GameManager.Instance.gameData.stageInfo;
        switch (stageNum) {
            case 0:
                stageText.text = "Stack!!";
                break;
            case 1:
                stageText.text = "Que!!";
                break;
            case 2:
                stageText.text = "Deq!!";
                break;
            case 3:
                stageText.text = "Tree!!";
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        stageScore += Time.deltaTime * 0.9f;
        stagePoint.text = "Score :: " + Mathf.CeilToInt(stageScore);
        if (GameManager.Instance.gameData.currentHP <= 0) {
            goBack.gameObject.SetActive(true);
        }
    }
}
