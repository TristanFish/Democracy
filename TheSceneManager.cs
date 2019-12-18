using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheSceneManager : MonoBehaviour
{

    private static TheSceneManager _instance;
    private GameObject Player;
    [SerializeField]
    Vector3 SpawnPosition = Vector3.zero;

    public enum GameState { Title, Menu, Map, Building, MiniGame, Event};
    private GameState CurrentState;


    
    public static TheSceneManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (TheSceneManager)FindObjectOfType(typeof(TheSceneManager));
            }
            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    //Travel to a Scene named "BuildingName"
    public void TravelToBuilding(string BuildingName)
    {
        //Loop through all Loaded scenes
        for (int CheckAllLoadedScenes = 0; CheckAllLoadedScenes < SceneManager.sceneCount ; CheckAllLoadedScenes++)
        {
            //If the BuildingName scene is already loaded leave this function
            if (SceneManager.GetSceneAt(CheckAllLoadedScenes).name == BuildingName)
            {
                Debug.Log(BuildingName + ", is already loaded");
                MapScript.Instance.ToggleMap(false);
                return;
            }
            
        }
        //If BuildingName is not loaded yet load buildingName
        SceneManager.LoadSceneAsync(BuildingName, LoadSceneMode.Single);
        Debug.Log(BuildingName + ", Should be loaded");
        MapScript.Instance.ToggleMap(false);

        Player.transform.position = SpawnPosition;
       
    }

    public void SetGameStateTitle()
    {
        
    }

    public void LoadGameFromStart()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).Find("PlayerSelect").gameObject.SetActive(false);
        EventManager.Instance.enabled = true;
        TravelToBuilding("WhiteHouse");
    }

    public void SetGameStateMenu()
    {

    }

    public void SetGameStateMap()
    {
        PlayerManager.Instance.SetMovement(false);
    }

    public void SetGameStateBuilding()
    {
        PlayerManager.Instance.SetMovement(true);
    }

    public void SetGameStateMiniGame()
    {

    }

}
