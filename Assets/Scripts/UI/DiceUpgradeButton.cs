using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceUpgradeButton : MonoBehaviour
{
    public int[] upgradePriceList;

    public GameObject upgradeUI;
    public TextMeshProUGUI costText;
    
    private int _upgradeLevel = 0;
    
    private PlayerResources _player;
    private DiceRow _diceRow;
    private DiceManager _diceManager;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerResources>();
        _diceRow = GetComponentInParent<DiceRow>();
        _diceManager = GameObject.FindWithTag("Player").GetComponent<DiceManager>();

        upgradeUI.SetActive(false);
    }

    private void OnMouseDown()
    {

        try
        {
            
            if (_player.playerResources.tokens >= upgradePriceList[_upgradeLevel])
            {
                _player.DecrementTokens(upgradePriceList[_upgradeLevel]);

                if (_upgradeLevel != upgradePriceList.Length - 1)
                    _upgradeLevel++;
                //_diceRow.AddDiceToRow();
                _diceManager.GainDice();
                UpdateCostUI();
            }

        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    

    private void OnMouseEnter()
    {
        upgradeUI.SetActive(true);
    }

    private void UpdateCostUI()
    {
        costText.text = upgradePriceList[_upgradeLevel].ToString();
    }
    
    private void OnMouseExit()
    {
        upgradeUI.SetActive(false);
    }


}
