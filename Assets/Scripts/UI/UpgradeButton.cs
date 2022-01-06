using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public int[] upgradePriceList;
    public GameObject upgradeUI;
    public TextMeshProUGUI capacityText;
    public TextMeshProUGUI costText;
    
    private PlayerResources _playerResources;
    private ActivityCard _activityCard;
    private int _upgradeLevel = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _activityCard = GetComponentInParent<ActivityCard>();
        _playerResources = GameObject.FindWithTag("Player").GetComponent<PlayerResources>();
        upgradeUI.SetActive(false);
        UpdateCostAndCapUI();
    }

    public void OnUpgradeButtonPressed()
    {
        try
        {

            if (_playerResources.playerResources.tokens >= upgradePriceList[_upgradeLevel]
                && _activityCard.CardCanBeUpgraded())
            {
                _playerResources.DecrementTokens(upgradePriceList[_upgradeLevel]);
                _upgradeLevel++;
                _activityCard.UpgradeCard();
                UpdateCostAndCapUI();
            }
            else
            {
                ThrowUpgradeError();
            }
        }
        catch (IndexOutOfRangeException e)
        {
            ThrowUpgradeError();
        }
    }

    private void UpdateCostAndCapUI()
    {
        capacityText.text = (_upgradeLevel + 3).ToString();
        costText.text = upgradePriceList[_upgradeLevel].ToString();
    }
    
    private void ThrowUpgradeError()
    {
        WarningTextPopUp.WarningTextEvent("You do not have enough tokens to upgrade this card.");
    }

    private void OnMouseEnter()
    {
        upgradeUI.SetActive(true);
    }

    private void OnMouseExit()
    {
        upgradeUI.SetActive(false);
    }

    private void OnMouseDown()
    {
        OnUpgradeButtonPressed();
    }
}
