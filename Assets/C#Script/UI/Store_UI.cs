using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store_UI : MonoBehaviour
{
    static int storemenu_val = -1;
    Transform ItemView;
    public List<GameObject> Item_arr = new List<GameObject>();

    void Start(){
        ItemView = transform.GetChild(1).GetChild(0);
        for(int i = 0; i < ItemView.childCount; i++){
            Item_arr.Add(ItemView.GetChild(i).gameObject);
            Item_arr[i].SetActive(false);
        }
        if(storemenu_val == -1){
            storemenu_val = 0;
        }
        Item_arr[storemenu_val].SetActive(true);
    }

    public void Press_per_menu_btn(int val){
        storemenu_val = val;
        for(int i = 0; i < ItemView.childCount; i++){
            if(i == storemenu_val){
            Item_arr[i].SetActive(true);
            }else{
                Item_arr[i].SetActive(false);
            }
        }}
}
