using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public float Player_max_HP;
    public float Player_recently_HP;
    [SerializeField] Slider Hp_bar;
    [SerializeField] GameManager Gm;

    void Start(){
        Hp_bar.maxValue = Player_max_HP;
        Player_recently_HP = Player_max_HP;
    }
    
    void Update(){
        if(!Gm.nowpause)
        Hp_bar.value = Player_recently_HP;
        Player_recently_HP -= 0.01f;
    }
}
