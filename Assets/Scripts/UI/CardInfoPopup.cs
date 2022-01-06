using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfoPopup : MonoBehaviour
{
    public GameObject UIPopUpObj;

    private void Start()
    {
        UIPopUpObj.SetActive(false);
    }

    private void OnMouseEnter()
    {
        UIPopUpObj.SetActive(true);
        
    }

    private void OnMouseExit()
    {
        UIPopUpObj.SetActive(false);
    }

}
