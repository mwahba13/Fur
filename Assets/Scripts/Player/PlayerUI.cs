using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EPlayerState
{
    EBoard,EMarket
}

public class PlayerUI : MonoBehaviour
{
    public EPlayerState PlayerState;

    public GameObject MarketUI;

    public GameObject playerUI;
    //public GameObject UpgradeUI;
    
    public Button rightButton;
    public Button leftButton;

    private PlayerCameraMover _camMover;
    // Start is called before the first frame update
    void Start()
    {
        _camMover = GetComponent<PlayerCameraMover>();
        SwitchState(PlayerState);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
            OnRightButtonClick();
        else if (Input.GetKeyDown(KeyCode.A))
            OnLeftButtonClick();
    }

    public void OnLeftButtonClick()
    {
        switch (PlayerState)
        {
            case EPlayerState.EBoard:
                SwitchState(EPlayerState.EMarket);
                break;

        }
    }
    
    public void OnRightButtonClick()
    {
        
        switch (PlayerState)
        {

            case EPlayerState.EMarket:
                SwitchState(EPlayerState.EBoard);
                break;

        }
    }

    private void SwitchState(EPlayerState newState)
    {
        PlayerState = newState;
        _camMover.MoveCamera(newState);
        
        if (newState == EPlayerState.EBoard)
        {
            leftButton.gameObject.SetActive(true);
            rightButton.gameObject.SetActive(false);
            playerUI.SetActive(true);
            MarketUI.SetActive(false);
            //UpgradeUI.SetActive(false);
        }
        else if (newState == EPlayerState.EMarket)
        {
            leftButton.gameObject.SetActive(false);
            rightButton.gameObject.SetActive(true);
            playerUI.SetActive(false);
            MarketUI.SetActive(true);
        }

    }
    
}
