using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TrapController : MonoBehaviour
{
    public CharacterControll player;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag) {
            case "Player":
                other.gameObject.SendMessage("GetShield");
                break;

            case "Block":
                Destroy(this.gameObject);
                break;

            default:
                break;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        switch (other.tag) {
            case "Player":
                break;

            default:
                break;
        }
    }
}
