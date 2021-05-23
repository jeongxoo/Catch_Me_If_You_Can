using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControll : MonoBehaviour
{    
    private Rigidbody2D rigidBody2D;
    private Animator animator;
    public CapsuleCollider2D collider;
    public GameObject[,] Health;
    public GameObject[] HP_full;
    public GameObject[] HP_half;
    private float jumpForce = 680.0f;
    private int doubleJump = 0;
    private int countHP = 0;
    private bool canDamaged = true;

    void Start()
    {
        GameManager.Instance.LoadGameDataFromJson();
        GameManager.Instance.gameData.currentHP = GameManager.Instance.gameData.maxHP;
        this.rigidBody2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        // Health = new GameObject[,];
        // HP_full = GameObject.FindGameObjectsWithTag("HP_Full");
        // HP_half = GameObject.FindGameObjectsWithTag("HP_Half");
        // Health = new GameObject[,] {HP_fUll, HP_half};



        GameManager.Instance.SaveGameDataToJson();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }


    public void JumpButton() {
        Input.GetKeyDown(KeyCode.Space);
    }
// -1.7~3 대충 3까지 올라감 점프 높이
    public void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && doubleJump < 2)
        {
            if (this.rigidBody2D.velocity.y == 0) {
                // 땅에서 점프
                this.animator.SetTrigger("JumpTrigger");
                this.rigidBody2D.AddForce(transform.up * this.jumpForce);
                doubleJump++;
            } else if (this.rigidBody2D.velocity.y > 0) {
                // 상승 중에 점프
                this.animator.SetTrigger("DoubleJumpTrigger");
                this.rigidBody2D.AddForce(transform.up * this.jumpForce * 0.5f);
                doubleJump++;
            } else {
                // 하강 중에 점프
                this.animator.SetTrigger("DoubleJumpTrigger");
                this.rigidBody2D.AddForce(transform.up * this.jumpForce * 1.2f);
                doubleJump++;
            }

        }

        if (this.rigidBody2D.velocity.y == 0 && doubleJump == 2) {
            doubleJump = 0;
        }
    }

    public void GetShield() {
        if (canDamaged) {
            canDamaged = false;
            this.animator.SetTrigger("HitTrigger");
            GameManager.Instance.gameData.currentHP -= 10;
            print(GameManager.Instance.gameData.currentHP);
            countHP++;
            switch (countHP) {
                case 1:
                    this.HP_full[4].gameObject.SetActive(false);
                    break;
                case 2:
                    this.HP_half[4].gameObject.SetActive(false);
                    break;
                case 3:
                    this.HP_full[3].gameObject.SetActive(false);
                    break;
                case 4:
                    this.HP_half[3].gameObject.SetActive(false);
                    break;
                case 5:
                    this.HP_full[2].gameObject.SetActive(false);
                    break;
                case 6:
                    this.HP_half[2].gameObject.SetActive(false);
                    break;
                case 7:
                    this.HP_full[1].gameObject.SetActive(false);
                    break;
                case 8:
                    this.HP_half[1].gameObject.SetActive(false);
                    break;
                case 9:
                    this.HP_full[0].gameObject.SetActive(false);
                    break;
                case 10:
                    this.HP_half[0].gameObject.SetActive(false);
                    break;    

                default:
                    break;        
            }
            StartCoroutine(CanDamaged());
            GameManager.Instance.SaveGameDataToJson();
        }
        
    }

    private void GetDamaged() {
        if (canDamaged) {
            canDamaged = false;
        } else {
            canDamaged = true;
        }

    }

    IEnumerator CanDamaged() {
        // canDamaged = false;
        yield return new WaitForSecondsRealtime(1f);
        canDamaged = true;
    }

}
