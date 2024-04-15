using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Main_UI : MonoBehaviour
{
    MainStatus_Data maindata;
    int maxHeart, recently_Heart, coin, cash, LV;
    float exp_value, maxexp;
    string name, call_Player;//칭호
    Text Player_name, heart_txt, coin_txt, air_txt, LV_txt, call_txt;

    GameObject Player, Pet;
    Vector3 Player_base, Pet_base;
    
    [Header("Service")]
    [SerializeField] GameObject CharacterDeco;
    [SerializeField] GameObject Medal_object;
    List<GameObject> Item_arr = new List<GameObject>();
    Transform ItemView;
    static int storemenu_val = -1;

    Scrollbar medal_scroll;
    bool isOpen_ch = false;
    bool isOpen_Medal = false;

    [Header("InputName")]
    [SerializeField] GameObject nameField;
    [SerializeField] InputField nameInput;

    

    void Start(){
        Player = GameObject.FindWithTag("Player");
        Pet = GameObject.FindWithTag("Pet");
        Player_base = Player.transform.position;
        Pet_base = Pet.transform.position;

        //texts
        Player_name = GetText(0,0,1);
        LV_txt = GetText(0,1,0);
        call_txt = GetText(0,2,0);
        heart_txt = GetText(5,3,0);
        coin_txt = GetText(5,1,1);
        air_txt = GetText(5,0,1);

        medal_scroll = Medal_object.transform.GetChild(1).GetChild(1).GetComponent<Scrollbar>();

        ItemView = CharacterDeco.transform.GetChild(2).GetChild(0).GetChild(0);
        for(int i = 0; i < ItemView.childCount; i++){
            Item_arr.Add(ItemView.GetChild(i).gameObject);
            Item_arr[i].SetActive(false);
        }
        if(storemenu_val == -1){
            storemenu_val = 0;
        }
        Item_arr[storemenu_val].SetActive(true);

        maindata = GameObject.Find("DDOL").transform.GetChild(0).transform.gameObject.GetComponent<MainStatus_Data>();
        recently_Heart = maindata.heart;
        coin = maindata.coin;
        cash = maindata.cash;
        LV = maindata.Level;
        exp_value = maindata.rec_exp;

        if(maindata.Playername != ""){
            name = maindata.Playername;
            nameField.SetActive(false);
        }
    }
    void Update(){
        //heart
        maxHeart = 5 + LV/10;
        heart_txt.text = recently_Heart.ToString() + "/" + maxHeart.ToString();
        //coin
        coin_txt.text = coin.ToString();
        //air
        air_txt.text = cash.ToString();
        //exp
        //name
        Player_name.text = name;
        //LV
        LV_txt.text = LV.ToString();
        //칭호
    }

    private Text GetText(int fn, int sn, int tn){
        return transform.GetChild(fn).GetChild(sn).GetChild(tn).GetComponent<Text>();
    }

    public void OptionButton(){
    }
    public void Medal(){
        medal_scroll.value = 1;
        
        if(!isOpen_Medal){
            isOpen_Medal = true;
            Medal_object.SetActive(true);
            isOpen_ch = false;
            CharacterDeco.SetActive(false);

            Player.transform.position = new Vector3(Player_base.x - 3.0f, Player_base.y, Player_base.z);
            Pet.transform.position = new Vector3(Pet_base.x - 3.0f, Pet_base.y, Pet_base.z);
        }else{
            Player.transform.position = Player_base;
            Pet.transform.position = Pet_base;
            isOpen_Medal = false;
            Medal_object.SetActive(false);
        }
    }
    public void Character(){
        if(!isOpen_ch){
        isOpen_ch = true;
        CharacterDeco.SetActive(true);
        isOpen_Medal = false;
        Medal_object.SetActive(false);

        Player.transform.position = new Vector3(Player_base.x - 3.0f, Player_base.y, Player_base.z);
        Pet.transform.position = new Vector3(Pet_base.x - 3.0f, Pet_base.y, Pet_base.z);
        }
        else{
            Player.transform.position = Player_base;
            Pet.transform.position = Pet_base;
            isOpen_ch = false;
            CharacterDeco.SetActive(false);
        }
    }

    public void Press_per_menu_btn_for_Character(int val){
        storemenu_val = val;
        for(int i = 0; i < ItemView.childCount; i++){
            if(i == storemenu_val){
            Item_arr[i].SetActive(true);
            }else{
                Item_arr[i].SetActive(false);
            }
        }}

    public void Store(){
        SceneManager.LoadScene("Store");
    }
    public void Stage(){
        SceneManager.LoadScene("ModeSelect");
    }
    public void press_nameOkay_btn(){
        if(nameInput.text != ""){
        name = nameInput.text;
        maindata.Playername = nameInput.text;
        }
        else{
        name = "우터";
        maindata.Playername = "우터";   
        }
        nameField.SetActive(false);
    }
}
