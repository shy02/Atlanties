using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //코인 갯수 산정
    //아이템 갯수 산정

    [SerializeField] float Player_HP;
    [SerializeField] PlayerStatus player_hp;
    [SerializeField] Text Score;
    int score_ = 0;
    [SerializeField] Text Coin;
    int coin_ = 0;
    [SerializeField] Text Item;
    int item_ = 0;
    public bool nowpause = false;
    MainStatus_Data maindata;
    void Start(){
        maindata = GameObject.Find("DDOL").transform.GetChild(0).GetComponent<MainStatus_Data>();
        StartCoroutine("GetScore");
    }
    //게임오버 판정
    void Update(){
        Player_HP = player_hp.Player_recently_HP;
        Score.text = score_.ToString();
        Coin.text = coin_.ToString();
        Item.text = item_.ToString();

        if(Player_HP <= 0){
            Debug.Log("GameOver");
            maindata.coin += coin_;
            SceneManager.LoadScene("Loby");
        }
    }

    //점수 올리기v
    IEnumerator GetScore(){
        yield return new WaitForSeconds(1f);
        score_++;
        StartCoroutine("GetScore");
    }

    public void Pause(){
        if(nowpause){
            Time.timeScale = 1;
            nowpause = false;
        }
        else{
            Time.timeScale = 0;
            nowpause = true;
        }
    }

    public void GetCoin(int coinval){
        Debug.Log("겟코인");
        score_ += coinval;
        coin_ += coinval;
    }
    public void GetItem(){
        item_++;
    }
}
