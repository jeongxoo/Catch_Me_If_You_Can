using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawnController : MonoBehaviour
{
    private static TrapSpawnController instance;
    public Stack stack;
    public CircularQue que;
    public GameObject trapFire;
    public GameObject trapWater;
    public GameObject trapSaw;
    public GameObject[] spawnPosition;
    public SpriteRenderer[] spriteArray;
    public Sprite fire;
    public Sprite saw;
    const float startX = 21.0f;
    float addPosX;
    int num;
    int current = 0;
    public int stageNum;

    public static TrapSpawnController Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake() {
        GameManager.Instance.LoadGameDataFromJson();
        stageNum = GameManager.Instance.gameData.stageInfo;
    }

    void Start()
    {
        CheckStage();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CheckStage() {
        switch (stageNum) {
            case 0:
                AddTrapInStack();
                SpawnTrapsInStack();
                break;
            
            case 1:
                AddTrapInQue();
                SpawnTrapsInQue();
                break;
            
            default:
                break;
        }
    }

    public void SpawnTrapsInStack() {
        for (int i = 0; i < spawnPosition.Length; i++) {
            addPosX = Random.Range(3.0f, 4.0f);

            if (stack.Peek() == trapFire) {
                Vector3 pos = new Vector3(startX + (i * addPosX), 3.4f, 0f);
                spawnPosition[i].transform.position = pos;
            } else if (stack.Peek() == trapSaw) {
                Vector3 pos = new Vector3(startX + (i * addPosX), Random.Range(-1.5f, -0.5f), 0f);
                spawnPosition[i].transform.position = pos;
            }

            Instantiate(stack.Pop(), spawnPosition[i].transform.position, Quaternion.identity, spawnPosition[i].transform);
        }
    }

    public void SpawnTrapsInQue() {
        for (int i = 0; i < spawnPosition.Length; i++) {
            addPosX = Random.Range(3.0f, 4.0f);
            GameObject quePeek = que.Dequeue();

            if (quePeek == trapFire) {
                Vector3 pos = new Vector3(startX + (i * addPosX), 3.4f, 0f);
                spawnPosition[i].transform.position = pos;
            } else if (quePeek == trapSaw) {
                Vector3 pos = new Vector3(startX + (i * addPosX), Random.Range(-1.5f, -0.5f), 0f);
                spawnPosition[i].transform.position = pos;
            }

            Instantiate(quePeek, spawnPosition[i].transform.position, Quaternion.identity, spawnPosition[i].transform);
        }
    }

    public void AddTrapInStack() {
        for (int i = 0; i < 6; i++) {
            num = Random.Range(1, 3);
            if (current == 2 && num == current) {
                num = 1;
            }
            current = num;

            switch (num) {
                case 1:
                    stack.Push(trapFire);
                    spriteArray[i].sprite = fire;
                    break;

                case 2:
                    stack.Push(trapSaw);
                    spriteArray[i].sprite = saw;
                    break;

                default:
                    break;
            }
        }
    }

    public void AddTrapInQue() {
        for (int i = 0; i < 6; i++) {
            num = Random.Range(1, 3);
            if (current == 2 && num == current) {
                num = 1;
            }
            current = num;

            switch (num) {
                case 1:
                    que.Enqueue(trapFire);
                    spriteArray[i].sprite = fire;
                    break;

                case 2:
                    que.Enqueue(trapSaw);
                    spriteArray[i].sprite = saw;
                    break;

                default:
                    break;
            }
        }
    }
}
