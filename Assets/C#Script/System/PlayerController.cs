using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("JUMP")]
    [SerializeField] float JumpPower;
    [SerializeField] float JumpSpeed;
    [Header("DASH")]
    [SerializeField] float DashSpeed;
    [SerializeField] float DashTime;
    [Header("INIT")]
    [SerializeField] Transform Target;
    [SerializeField] Camera maincam;
    [SerializeField] GameManager Gm;

    [Header ("Share value")]
    public bool nowdamage = false;
    //private
    float Player_HP;
    bool nowdash = false;
    bool nowjump = false;
    int jumpcount = 0;
    Rigidbody2D rigid;
    Animator player_Animator;
    SpriteRenderer player_sprite;
    //WaitForSeconds delay = new WaitForSeconds(1f);

    void Start()
    {   
        rigid = this.GetComponent<Rigidbody2D>();
        player_Animator = this.GetComponent<Animator>();
        player_sprite = this.GetComponent<SpriteRenderer>();
        rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }
    void Update(){
        if(nowdash){
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.position.x, transform.position.y,transform.position.z), DashSpeed * Time.deltaTime);
        }
    }
    public void JumpBtn(){
        if(!nowdash && jumpcount < 2){
            if(jumpcount == 1){
            StopCoroutine("jumpTime");
            }
            StartCoroutine("jumpTime");//나중에 바꿔야됨
            nowjump = true;
            player_Animator.SetBool("nowjump", true);
            Vector2 jumpvec = Vector2.up * Mathf.Sqrt(JumpPower * -Physics.gravity.y);
            rigid.AddForce(jumpvec, ForceMode2D.Impulse);
            jumpcount++;
            player_Animator.SetInteger("jumpCount",jumpcount);
            player_Animator.SetBool("isUnder", false);
        }
    }

    public void DashBtn(){
        if(!nowjump && !nowdash){
        nowdash = true;
        StartCoroutine("Dash");
        }
    }
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.CompareTag("Ground")){
            jumpcount =0;
            nowjump = false;
        player_Animator.SetBool("nowjump", false);
        player_Animator.SetInteger("jumpCount", jumpcount);
        }
    }
    public void GetDamage(float dmg){
        if(!nowdamage){
        StartCoroutine("DamageSprite");
        this.GetComponent<PlayerStatus>().Player_recently_HP -= dmg;
        }
    }
    
    IEnumerator Dash(){
        //rigid.AddForce(Vector2.right * DashSpeed, ForceMode2D.Impulse);
        rigid.constraints = RigidbodyConstraints2D.None;
        yield return new WaitForSeconds(DashTime);
        nowdash = false;
        rigid.velocity = Vector2.zero;
        this.transform.position = new Vector3(0, -0.41f, 0);
        
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
    IEnumerator jumpTime(){
        //rigid.AddForce(Vector2.right * DashSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        player_Animator.SetBool("isUnder", true);
    }

    IEnumerator DamageSprite(){
        player_sprite.color = new Vector4(1,1,1,0.5f);
        yield return new WaitForSeconds(1f);
        player_sprite.color = new Vector4(1,1,1,1f);
    }

}
