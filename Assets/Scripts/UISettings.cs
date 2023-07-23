using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    public Text livesText;

    public void Update(){
        livesText.text = GameManager.instance.currentLives.ToString();
    }

}

