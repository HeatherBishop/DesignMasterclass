using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterUI : MonoBehaviour {

    private static CharacterUI instance;

    public static CharacterUI Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CharacterUI>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(CharacterUI).Name;
                    instance = obj.AddComponent<CharacterUI>();
                }
            }
            return instance;
        }
    }


    [SerializeField]
    public GameObject InfoPanel;

    public CharController focusedChar;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (InfoPanel == null)
        {
            InfoPanel = GameObject.Find("CharacterInfoPanel");
            InfoPanel.SetActive(false);
        }
    }

    private void Update()
    {

        //if the pointer is on a ui element return immediately
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        //if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            //raycast to hit a character
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            //if a character has been hit, set it as the focused character
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Character")
                {
                    focusedChar = hit.collider.GetComponent<CharController>();
                    GetCharacterInfo();
                }
            }
            //otherwise wipe the focused character
           else
           { 
                focusedChar = null;
                InfoPanel.SetActive(false);
           }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
            Instance.ShowDate();
    }
    //set sprite, name, location and info text, if the character is in position also show its date
    private void GetCharacterInfo()
    {
        InfoPanel.transform.GetChild(0).GetComponent<Image>().sprite = focusedChar.CharInfo.sprite;
        InfoPanel.transform.GetChild(1).GetComponent<Text>().text = focusedChar.CharInfo.characterName;
        InfoPanel.transform.GetChild(2).GetComponent<Text>().text = focusedChar.CharInfo.MapLocation;
        InfoPanel.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().text = focusedChar.CharInfo.itemInfo;

        
        ShowDate();

        InfoPanel.SetActive(true);
    }

    public void ShowDate()
    {
        if (focusedChar == null)
            return;


        if (focusedChar.moveable)
            InfoPanel.transform.GetChild(3).GetComponent<Text>().text = string.Empty;
        else
            InfoPanel.transform.GetChild(3).GetComponent<Text>().text = focusedChar.CharInfo.year.ToString();
    }

}
