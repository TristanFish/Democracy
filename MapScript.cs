using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{   
    private static MapScript _instance;
    
    #region Expansion/Minimize variables
    //Assigning values here so that there are no more warnings, if you want to change the actual variables 
    //head to the BillBoardPlaceHolder and change them from the editor.
    
    [SerializeField]
    private Vector2 MinPosition = Vector2.zero;
    [SerializeField]
    private Vector2 ExPosition = Vector2.zero;
    [SerializeField]    
    private Vector2 MinScale = Vector2.zero;
    [SerializeField] 
    private Vector2 ExScale = Vector2.zero;
    [SerializeField]
    private float ScaleSpeed = 0;

    public static bool Expanded = false;
    #endregion

    #region Button variables

    public GameObject[] BuildingIcons;


    #endregion

    public static MapScript Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        GetComponent<RectTransform>().anchoredPosition = MinPosition;
    }

    private void Start()
    {
        BuildingIcons = new GameObject[transform.GetChild(0).GetChild(0).childCount];
        for (int i = 0; i < transform.GetChild(0).GetChild(0).childCount; i++)
        {
            BuildingIcons[i] = transform.GetChild(0).GetChild(0).GetChild(i).gameObject;
        }
    }


    /// <summary>
    /// Expands the map is Expand is true, minimizes if false
    /// </summary>
    /// <param name="Expand"></param>
    public void ToggleMap(bool Expand)
    {
        if (!Expand)
        {
            MinimizeMap();
        }
        else
        {
            ExpandMap();
        }
    }


    private void ExpandMap()
    {
        StopAllCoroutines();
        StartCoroutine("Expand");
    }

    private void MinimizeMap()
    {
        StopAllCoroutines();
        StartCoroutine("Minimize");
    }


    private void ToggleButtons(bool ButtonState)
    {
        for(int i = 0; i < BuildingIcons.Length; i++)
        {
            BuildingIcons[i].GetComponent<Button>().interactable = ButtonState;
            BuildingIcons[i].GetComponent<DisplayInfo>().enabled = ButtonState;
            BuildingIcons[i].GetComponent<RawImage>().raycastTarget = ButtonState;
        }
    }


    IEnumerator Expand()
    {

        TheSceneManager.Instance.SetGameStateMap();

        Vector2 DifPos = ExPosition - MinPosition;
        Vector2 DifScale = ExScale - MinScale;
        Vector2 MoveSpeed =  DifPos / (DifScale / ScaleSpeed) ;

        //While current scale is less than target scale
        while (gameObject.GetComponent<RectTransform>().localScale.x < ExScale.x)
        {
            
            gameObject.GetComponent<RectTransform>().localScale += new Vector3(ScaleSpeed, 0.775f * ScaleSpeed) * Time.deltaTime;

            gameObject.GetComponent<RectTransform>().anchoredPosition += MoveSpeed * Time.deltaTime;

            yield return null;
            
        }
        gameObject.GetComponent<RectTransform>().localScale = ExScale;
        gameObject.GetComponent<RectTransform>().anchoredPosition = ExPosition;


        ToggleButtons(true);
        GetComponent<Button>().interactable = false;

        Expanded = true;
        
    }

    IEnumerator Minimize()
    {   
        ToggleButtons(false);

        Vector2 DifPos = ExPosition - MinPosition;
        Vector2 DifScale = ExScale - MinScale;
        Vector2 MoveSpeed = DifPos / (DifScale / ScaleSpeed);

        while (gameObject.GetComponent<RectTransform>().localScale.x > MinScale.x)
        {
            gameObject.GetComponent<RectTransform>().localScale -= new Vector3(ScaleSpeed, 0.775f * ScaleSpeed) * Time.deltaTime;

            gameObject.GetComponent<RectTransform>().anchoredPosition += -MoveSpeed * Time.deltaTime;
            
            yield return null;
        }
        gameObject.GetComponent<RectTransform>().localScale = MinScale;
        gameObject.GetComponent<RectTransform>().anchoredPosition = MinPosition;
        TheSceneManager.Instance.SetGameStateBuilding();

        GetComponent<Button>().interactable = true;

        Expanded = false;
        
    }

    private void OnDestroy()
    {

    }
}
