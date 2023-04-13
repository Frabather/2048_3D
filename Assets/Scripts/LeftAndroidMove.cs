using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;
using UnityEngine.EventSystems;

public class LeftAndroidMove : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private GameObject MoveScript;
    private bool isPressed = false;

    void Start()
    {
        MoveScript = GameObject.Find("EmptyToManageThemAll");
    }

    void Update()
    {
        if(isPressed)
        {
            MoveScript.GetComponent<ThrowCubes>().TestMoveLeft();
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
