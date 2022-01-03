using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EPlayerState
{
    EBoard,EMarket,EUpgrade
}

public class PlayerUI : MonoBehaviour
{
    public EPlayerState PlayerState;

    public GameObject MarketUI;
    public GameObject UpgradeUI;
    
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
            case EPlayerState.EMarket:
                break;
            case EPlayerState.EUpgrade:
                SwitchState(EPlayerState.EBoard);
                break;
        }
    }
    
    public void OnRightButtonClick()
    {
        
        switch (PlayerState)
        {
            case EPlayerState.EBoard:
                SwitchState(EPlayerState.EUpgrade);
                break;
            case EPlayerState.EMarket:
                SwitchState(EPlayerState.EBoard);
                break;
            case EPlayerState.EUpgrade:
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
            rightButton.gameObject.SetActive(true);
            
        }
        else if (newState == EPlayerState.EMarket)
        {
            leftButton.gameObject.SetActive(false);
            rightButton.gameObject.SetActive(true);
        }
        
        else if (newState == EPlayerState.EUpgrade)
        {
            
            leftButton.gameObject.SetActive(true);
            rightButton.gameObject.SetActive(false);
        }
    }
    
}
