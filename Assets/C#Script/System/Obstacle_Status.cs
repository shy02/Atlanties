using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle_Status : MonoBehaviour
{
    [SerializeField] float Damage;
    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.CompareTag("Player")){
            StartCoroutine("getdamage", coll);
        }
    }
    IEnumerator getdamage(Collider2D coll){
        coll.gameObject.GetComponent<PlayerController>().GetDamage(Damage);
        coll.gameObject.GetComponent<PlayerController>().nowdamage = true;
        yield return new WaitForSeconds(1f);
        coll.gameObject.GetComponent<PlayerController>().nowdamage = false;
    }
}
