using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_UI : MonoBehaviour
{
    MainStatus_Data maindata;
    int maxHeart, recently_Heart, coin, cash, LV;
    float exp_value, maxexp;
    string name, call_Player;//칭호
    
    [Header("Service")]
    [SerializeField] GameObject CharacterDeco;
    [SerializeField] GameObject Medal_object;
    bool isOpen_ch = false;
    bool isOpen_Medal = false;
    [Header("Text_Object")]
    [SerializeField] Text Player_name;
    [SerializeField] Text heart_txt;
    [SerializeField] Text coin_txt; 
    [SerializeField] Text air_txt;
    [SerializeField] Text LV_txt;
    [SerializeField] Text call_txt;
    [Header("EXP")]
    [SerializeField] Slider exp_;
    [Header("InputName")]
    [SerializeField] GameObject nameField;
    [SerializeField] InputField nameInput;

    void Start(){
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

    public void OptionButton(){
    }
    public void Medal(){
        if(!isOpen_Medal){
            isOpen_Medal = true;
            Medal_object.SetActive(true);
            isOpen_ch = false;
            CharacterDeco.SetActive(false);
        }else{
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
        }
        else{
            isOpen_ch = false;
            CharacterDeco.SetActive(false);
        }
    }
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
