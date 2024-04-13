using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Coinvalue;
    [SerializeField] GameManager Gm;

    void Start(){
        Gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.CompareTag("Player")){
            Gm.GetCoin(Coinvalue);
            Destroy(gameObject);
        }
    }
}
