using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class MarketplaceHandler : MonoBehaviour
{
    public ResourceStruct marketPrice;
    private ResourceStruct _playerResources;
    private ResourceStruct _enemyResources;
    
    public TextMeshProUGUI beaverPriceText;
    public TextMeshProUGUI beaverPeltPriceText;
    public TextMeshProUGUI buffaloPriceText;
    public TextMeshProUGUI buffaloPeltPriceText;
    public TextMeshProUGUI pemmicanPriceText;

    
    

    
    // Start is called before the first frame update
    void Start()
    {
        _playerResources = GameObject.FindWithTag("Player").GetComponent<PlayerResources>().playerResources;
        _enemyResources = GameObject.FindWithTag("GameController").GetComponent<EconomyManager>().opponentResources;
        UpdateMarketPriceUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    


    private void UpdateMarketPriceUI()
    {
        beaverPriceText.text = marketPrice.beaver.ToString();
        beaverPeltPriceText.text = marketPrice.beaverPelts.ToString();
        buffaloPriceText.text = marketPrice.buffalo.ToString();
        buffaloPeltPriceText.text = marketPrice.buffaloPelts.ToString();
        pemmicanPriceText.text = marketPrice.pemmican.ToString();
    }
    
    public void OnBuyBeaver()
    {
        if (_playerResources.tokens >= marketPrice.beaver)
        {
            _playerResources.tokens -= marketPrice.beaver;
        }
        else
        {
            WarningTextPopUp.WarningTextEvent("You can't afford that beaver chum.");
        }
    }


    private void UpdateBeaverPrice()
    {
        
    }

    private void UpdateBuffaloPrice()
    {
        
    }

    private void UpdatePemmicanPrice()
    {
        
    }

    #region MarketPlaceButtonFunctions

    
    public void OnSellBeaver()
    {
        
    }

    public void OnBuyBeaverPelt()
    {
        
    }

    public void OnSellBeaverPelt()
    {
        
    }

    public void OnBuyBuffalo()
    {
        
    }

    public void OnBuyBuffaloPelt()
    {
        
    }

    public void OnBuyPemmican()
    {
        
    }

    public void OnSellPemmican()
    {
        
    }

    #endregion
    
    
}
