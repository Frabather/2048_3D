using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    private GameObject defCam, secondCam;
    private bool isButtonPressed;

    void Start()
    {
        defCam = GameObject.Find("Main Camera");
        secondCam = GameObject.Find("Second Camera");
        secondCam.SetActive(false);
    }

    void Update()
    {
        #if UNITY_ANDROID
            isButtonPressed = GameObject.Find("EmptyToManageThemAll").GetComponent<Android_Buttons>().isButtonPressed;
        #endif
        if ((Input.GetKey("c")) || isButtonPressed)
        {
            defCam.SetActive(false);
            secondCam.SetActive(true);
        }
        else
        {
            defCam.SetActive(true);
            secondCam.SetActive(false);
        }
    }
}
