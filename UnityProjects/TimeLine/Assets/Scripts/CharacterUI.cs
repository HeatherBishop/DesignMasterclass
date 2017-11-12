using UnityEngine;
using UnityEngine.UI;

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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Character")
                {
                    focusedChar = hit.collider.GetComponent<CharController>();
                    GetCharacterInfo();
                }
            }
           else
           { 
                focusedChar = null;
                InfoPanel.SetActive(false);
           }
        }
        //if(Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
        //    if (hit.collider.tag == "Character")
        //    {
        //        focusedChar = hit.collider.GetComponent<CharController>();
        //    }
        //    if(hit.collider == null)
        //    {
        //        focusedChar = null;
        //        InfoPanel.SetActive(false);
        //    }
        //}
    }
    private void GetCharacterInfo()
    {
        InfoPanel.transform.GetChild(0).GetComponent<Image>().sprite = focusedChar.CharInfo.sprite;
        InfoPanel.transform.GetChild(1).GetComponent<Text>().text = focusedChar.CharInfo.characterName;
        InfoPanel.transform.GetChild(2).GetComponent<Text>().text = focusedChar.CharInfo.MapLocation;
        InfoPanel.transform.GetChild(3).GetComponent<Text>().text = focusedChar.CharInfo.itemInfo;
        InfoPanel.SetActive(true);
    }

}
