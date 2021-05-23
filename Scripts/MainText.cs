using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainText : MonoBehaviour
{
    public Text totalText;
    // Start is called before the first frame update
    float totalScore;
    void Start()
    {
        GameManager.Instance.LoadGameDataFromJson();
        totalScore = GameManager.Instance.gameData.point;
        totalText.text = "Total Score :: " + totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
