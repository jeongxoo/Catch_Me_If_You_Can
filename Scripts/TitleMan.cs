using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMan : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ballon;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PopBallon());
    }

    IEnumerator PopBallon() {
        yield return new WaitForSecondsRealtime(2f);
        ballon.gameObject.SetActive(true);
    }
}
