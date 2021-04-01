using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    GameObject scenecontroller;

    public void OnClick()
    {
        this.scenecontroller = GameObject.Find("SceneController");
        Debug.Log("Button click!");
        this.scenecontroller.GetComponent<SceneController>().StartGame();
    }
}
