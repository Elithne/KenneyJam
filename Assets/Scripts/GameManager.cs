using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake(){
        instance = this;
        //SceneManager.sceneLoaded += LoadState;
        //DontDestroyOnLoad(gameObject);
    }

    public List<Sprite> playerSprites;
    public Player player;
    public PlayerGrabKey playerKeys;
    public FloatingTextManager floatingTextManager;

    public int keys;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration){
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    /*public void LoadState(Scene s, LoadSceneMode mode){
        if(!PlayerPrefs.HasKey("SaveState")){
            return;
        }
        string[]data = PlayerPrefs.GetString("SaveState").Split('|');
        
        //ChangePlayerSkin
        keys = int.Parse(data[1]);

        player.transform.position = GameObject.Find("SpawnPoint").transform.position;

    }

    //skin-keys
    public void SaveState(Scene s, LoadSceneMode mode){

        string save = "";
        save += "0"+"|";
        save += playerKeys.GetKeys().ToString()+ "|";
        PlayerPrefs.SetString("SaveState", save);

    }*/
}
