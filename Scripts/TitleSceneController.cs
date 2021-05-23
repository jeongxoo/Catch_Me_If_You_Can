using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemy_fruit;
    public GameObject destination;
    public Image fruit_1;
    public Image fruit_2;
    private const float boss_mv_speed = 7.0f;
    private bool check = false;

    public Text gameLogo;
    public Text gameLogoBack;
    public Image startButton;
    public Image reset;

    private float easing = 7.0f;
    private float s_easing = 70.0f;
    float time = 0;
    float F_time1 = 4.0f;
    float F_time2 = 4.0f;
    
    void Start()
    {
        StartCoroutine(FadeFlow(gameLogo, F_time1));
        StartCoroutine(FadeFlow(gameLogoBack, F_time1));

    }

    // Update is called once per frame
    public void Update()
    {
        MoveEnemy(boss_mv_speed * Time.deltaTime);
    }

    void MoveEnemy(float mv_speed) {
        if (enemy.gameObject.transform.position.x <= fruit_1.gameObject.transform.position.x) {
            enemy.gameObject.transform.Translate(mv_speed, 0, 0);
        } else {
            fruit_1.gameObject.SetActive(false);
            enemy_fruit.gameObject.SetActive(true);
            StartCoroutine(TakeARest());
        }

        if (check) {
            if (enemy.gameObject.transform.position.x <= destination.gameObject.transform.position.x) {
                enemy.gameObject.transform.Translate(mv_speed, mv_speed / 3f, 0);
            }
        }
    }

    IEnumerator TakeARest() {
        yield return new WaitForSecondsRealtime(1.5f);
        check = true;
    }

    IEnumerator FadeFlowButton(Image panel, float F_time)
    {
        Color alpha = panel.color;
        time = 0;
        while(alpha.a < 1)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            panel.color = alpha;
            yield return null;
        }
        yield return null;

        startButton.gameObject.SetActive(true);
        // StartCoroutine(FadeFlowButton(startButton, F_time2));

    }

        IEnumerator FadeFlow(Text panel, float F_time)
    {
        Color alpha = panel.color;
        time = 0;
        while(alpha.a < 1)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            panel.color = alpha;
            yield return null;
        }
        yield return null;

        startButton.gameObject.SetActive(true);
        StartCoroutine(FadeFlowButton(startButton, F_time2));

    }
}
