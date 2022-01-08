using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class MarketplaceHandler : MonoBehaviour
{
    public ResourceStruct marketPrice;
    private ResourceStruct _playerResources;
    
    public TextMeshProUGUI beaverPriceText;
    public TextMeshProUGUI beaverPeltPriceText;
    public TextMeshProUGUI buffaloPriceText;
    public TextMeshProUGUI buffaloPeltPriceText;
    public TextMeshProUGUI pemmicanPriceText;


    private int _beaverStock = 6;
    private int _beaverPeltStock = 6;
    private int _buffaloStock = 6;
    private int _buffaloPeltStock = 6; 
    private int _pemmicanStock = 12;

    //TODO - add resolution animation/phase
    // Start is called before the first frame update
    private void Awake()
    {
        _playerResources = GameObject.FindWithTag("Player").GetComponent<PlayerResources>().playerResources;
        UpdateBeaverPrice(0);
        UpdateBuffaloPrice(0);
        UpdateMarketPriceUI();
    }

    private void UpdateMarketPriceUI()
    {

        
        
        beaverPriceText.text = marketPrice.beaver.ToString();
        beaverPeltPriceText.text = marketPrice.beaverPelts.ToString();
        buffaloPriceText.text = marketPrice.buffalo.ToString();
        buffaloPeltPriceText.text = marketPrice.buffaloPelts.ToString();
        pemmicanPriceText.text = marketPrice.pemmican.ToString();
    }
    

    //where i is the netchange of the stock of beaver in the open market
    //TODO - figure out price curves
    public void UpdateBeaverPrice(int i)
    {
        _beaverStock += i;

        marketPrice.beaver = (-_beaverStock / 5) + 5;
        if (marketPrice.beaver <= 0)
            marketPrice.beaver = 1;
        
        UpdateBeaverPeltPrice(i);
        UpdateMarketPriceUI();

    }

    public void UpdateBeaverPeltPrice(int i)
    {
        _beaverPeltStock += i;

        marketPrice.beaverPelts = (-_beaverPeltStock / 5) + 10;

        if (marketPrice.beaverPelts <= 0)
            marketPrice.beaverPelts = 3;
        UpdateMarketPriceUI();

    }

    public void UpdateBuffaloPrice(int i)
    {
        _buffaloStock += i;

        marketPrice.buffalo = (-_buffaloStock/5 + 12);
        if (marketPrice.buffalo <= 0)
            marketPrice.buffalo = 5;
        
        UpdateBuffaloPeltPrice(i);
        UpdatePemmicanPrice(i);
        UpdateMarketPriceUI();

    }

    public void UpdateBuffaloPeltPrice(int i)
    {
        _buffaloPeltStock += i;

        marketPrice.buffaloPelts = (-_buffaloPeltStock / 5) + 17;
        if (marketPrice.buffaloPelts <= 0)
            marketPrice.buffaloPelts = 7;
        
        UpdateMarketPriceUI();

    }

    public void UpdatePemmicanPrice(int i)
    {
        _pemmicanStock += i;

        marketPrice.pemmican = (-_pemmicanStock / 5) + 22;
        if (marketPrice.pemmican <= 0)
            marketPrice.pemmican = 9;
        
        UpdateMarketPriceUI();

    }

    #region MarketPlaceButtonFunctions

    public void OnBuyBeaver()
    {
        if (_playerResources.tokens >= marketPrice.beaver)
        {
            _playerResources.tokens -= marketPrice.beaver;
            _playerResources.beaver += 1;
            UpdateBeaverPrice(-1);
        }
        else
        {
            WarningTextPopUp.WarningTextEvent("You can't afford that beaver buddy.");
        }
    }


    public void OnSellBeaver()
    {
        if (_playerResources.beaver > 0)
        {
            _playerResources.beaver -= 1;
            _playerResources.tokens += marketPrice.beaver;
            UpdateBeaverPrice(1);
        }
        else
            WarningTextPopUp.WarningTextEvent("You don't have any beaver to sell. " +
                                              "maybe you should go hunt some.");
    }

    public void OnBuyBeaverPelt()
    {
        if (_playerResources.tokens >= marketPrice.beaverPelts)
        {
            _playerResources.tokens -= marketPrice.beaverPelts;
            _playerResources.beaverPelts += 1;
            UpdateBeaverPeltPrice(-1);
        }
        else
        {
            WarningTextPopUp.WarningTextEvent("Save up more to buy that pelt.");
        }
    }

    public void OnSellBeaverPelt()
    {
        
        if (_playerResources.beaverPelts > 0)
        {
            _playerResources.beaverPelts -= 1;
            _playerResources.tokens += marketPrice.beaverPelts;
            UpdateBeaverPeltPrice(1);
        }
        else
        {
            WarningTextPopUp.WarningTextEvent("You don't have any pelts to sell. Process "
            + " beaver to make beaver pelts.");
        }
    }

    public void OnBuyBuffalo()
    {
        if (_playerResources.tokens >= marketPrice.buffalo)
        {
            _playerResources.tokens -= marketPrice.buffalo;
            _playerResources.buffalo += 1;
            UpdateBuffaloPrice(-1);
        }
        else
        {
            WarningTextPopUp.WarningTextEvent("Save up more to buy that buffalo.");
        }
    }

    public void OnSellBuffalo()
    {
        if (_playerResources.buffalo > 0)
        {
            _playerResources.buffalo -= 1;
            _playerResources.tokens += marketPrice.buffalo;
            UpdateBuffaloPrice(1);
        }
        else
        {
            WarningTextPopUp.WarningTextEvent("You don't have any buffalo to sell. Go hunt some.");
        }
    }
    
    public void OnBuyBuffaloPelt()
    {
        if (_playerResources.tokens >= marketPrice.buffaloPelts)
        {
            _playerResources.tokens -= marketPrice.buffaloPelts;
            _playerResources.buffaloPelts += 1;
            UpdateBuffaloPrice(-1);
        }
        else
        {
            WarningTextPopUp.WarningTextEvent("Save up more to buy that buffalo pelt.");
        }
    }

    public void OnSellBuffaloPelt()
    {
        if (_playerResources.buffaloPelts > 0)
        {
            _playerResources.buffaloPelts -= 1;
            _playerResources.tokens += marketPrice.buffaloPelts;
            UpdateBeaverPeltPrice(1);
        }
        else
        {
            WarningTextPopUp.WarningTextEvent("You don't have any pelts to sell. Process "
                                              + " buffalo to make buffalo pelts.");
        }
    }

    public void OnBuyPemmican()
    {
        if (_playerResources.tokens >= marketPrice.pemmican)
        {
            _playerResources.tokens -= marketPrice.pemmican;
            _playerResources.pemmican += 1;
            UpdateBuffaloPrice(-1);
        }
        else
        {
            WarningTextPopUp.WarningTextEvent("You can't afford to buy pemmican.");
        }  
    }

    public void OnSellPemmican()
    {
        if (_playerResources.pemmican > 0)
        {
            _playerResources.pemmican -= 1;
            _playerResources.tokens += marketPrice.pemmican;
            UpdateBeaverPeltPrice(1);
        }
        else
        {
            WarningTextPopUp.WarningTextEvent("You don't have any pemmican to sell. Process "
                                              + " buffalo to make pemmican.");
        }
    }

    #endregion
    
    
}
