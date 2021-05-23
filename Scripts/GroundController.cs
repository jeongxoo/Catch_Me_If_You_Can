using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ground;
    private Vector3 zeroPoint = new Vector3(-9.5f, 0.2f, 0.0f);
    
    public TrapSpawnController spawner;

    // Update is called once per frame
    void Update()
    {
        MovingGround();
    }

    void MovingGround()
    {
        if (Ground.transform.position.x <= -60.0f)
        {
            Ground.transform.position = zeroPoint;
            spawner.CheckStage();
        }
        else
        {
            Ground.transform.Translate(-6f * Time.deltaTime, 0, 0);
        }
    }
}
