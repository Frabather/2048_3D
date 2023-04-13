using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndroidButtons : MonoBehaviour
{

    private GameObject SwitchCamButton, MoveLeftButton, MoveRightButton, ThrowBallButton;

    void Start()
    {
        SwitchCamButton = GameObject.Find("Switch_Cam_Button");
        MoveLeftButton = GameObject.Find("Move_Left");
        MoveRightButton = GameObject.Find("Move_Right");
        ThrowBallButton = GameObject.Find("Throw_Ball");



#if UNITY_ANDROID
    SwitchCamButton.SetActive(true);
    MoveLeftButton.SetActive(true);
    MoveRightButton.SetActive(true);
    ThrowBallButton.SetActive(true);
#endif

#if UNITY_STANDALONE_WIN
     SwitchCamButton.SetActive(false);
     MoveLeftButton.SetActive(false);
     MoveRightButton.SetActive(false);
     ThrowBallButton.SetActive(false);
#endif
    }
}
