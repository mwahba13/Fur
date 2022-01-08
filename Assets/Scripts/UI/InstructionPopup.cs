using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionPopup : MonoBehaviour
{

    public GameObject[] pages;
    public GameObject canvasObj;

    public GameObject rightButton;
    public GameObject leftButton;
    
    private int _pageIndex = 0;


    public void OnOpenInstruction()
    {
        _pageIndex = 0;
        leftButton.SetActive(false);
        for(int i = 0; i < pages.Length; i++)
            if(i != _pageIndex)
                pages[i].SetActive(false);
            else 
                pages[i].SetActive(true);
        
        canvasObj.SetActive(true);
    }

    public void OnCloseInstructions()
    {
        canvasObj.SetActive(false);
    }

    public void OnNextPageButtonPressed()
    {
        pages[_pageIndex].SetActive(false);

        _pageIndex++;
        pages[_pageIndex].SetActive(true);
        
        if(_pageIndex == pages.Length-1)
            rightButton.SetActive(false);
        else 
            rightButton.SetActive(true);
        
        leftButton.SetActive(true);
    }

    public void OnPrevPageButtonPressed()
    {
        pages[_pageIndex].SetActive(false);

        _pageIndex--;
        pages[_pageIndex].SetActive(true);
        
        if(_pageIndex == 0)
            leftButton.SetActive(false);
        else
            leftButton.SetActive(true);
        
        rightButton.SetActive(true);
    }
    
}
