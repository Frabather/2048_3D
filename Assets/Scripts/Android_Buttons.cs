//#if UNITY_ANDROID

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;
using UnityEngine.EventSystems;

public class Android_Buttons : MonoBehaviour
{

    private Button switchCamComponent, MoveLeftButtonComp, MoveRightButtonComp, ThrowButtonComp;
    private GameObject MoveScript;
    public bool isButtonPressed = true;
    int time;


    void Start()
    {
        MoveScript = GameObject.Find("EmptyToManageThemAll");

        switchCamComponent = GameObject.Find("Switch_Cam_Button").GetComponent<Button>();
        MoveLeftButtonComp = GameObject.Find("Move_Left").GetComponent<Button>();
        MoveRightButtonComp = GameObject.Find("Move_Right").GetComponent<Button>();
        ThrowButtonComp = GameObject.Find("Throw_Ball").GetComponent<Button>();

        switchCamComponent.onClick.AddListener(switchCam);
        ThrowButtonComp.onClick.AddListener(Throw);
    }

    void switchCam()
    {
        if (isButtonPressed)
        {
            isButtonPressed = false;
        }
        else
        {
            isButtonPressed = true;
        }
    }

    void Throw()
    {
        GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().BallThrow();
    }

}

//#endif