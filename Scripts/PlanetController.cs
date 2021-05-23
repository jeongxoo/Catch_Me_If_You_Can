using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plant;
    public GameObject Planet1;
    public GameObject Planet2;
    public GameObject Planet3;
    private float x;
    private float y;

    private Vector3 zeroPoint = new Vector3(20f, 0f, 0f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovintPlanets();
        Planet1.transform.Rotate(0f, 0f, 1f);
        Planet2.transform.Rotate(0f, 0f, 0.75f);
        Planet3.transform.Rotate(0f, 0f, 0.5f);
    }

    void MovintPlanets()
    {
        if (plant.transform.position.x <= -40.0f)
        {
            plant.transform.position = zeroPoint;
        }
        else
        {
            x += Time.deltaTime; 
            y = Mathf.Sin(x); 
            plant.transform.Translate(-x * 0.005f, y * 0.01f, 0);
        }
    }
}
