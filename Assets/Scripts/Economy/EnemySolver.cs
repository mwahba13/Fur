using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySolver : MonoBehaviour
{
    public int NumOfDice;

    public ActivityCard[] ActivityCards;

    [Header("Share Price Parameters")] 
    public int totNumShares;

    public int numOwnedShares;

    public TextMeshProUGUI ownedShareNumText;
    public TextMeshProUGUI totShareNumText;
    public TextMeshProUGUI sharePriceText;

    public delegate void EndGameDelegate();

    public static EndGameDelegate OnEndGameEvent;
    
    private int _initialNumDice;
    private int _currentSharePrice;
    private bool _isInEndgame = false;
    
    private MarketplaceHandler _marketplaceHandler;
    private ResourceStruct _playerResources;
    private ResourceStruct _enemyResources;
    private ResourceStruct _initMarketPrice;
    // Start is called before the first frame update
    void Start()
    {
        _marketplaceHandler = GameObject.FindWithTag("GameController").GetComponent<MarketplaceHandler>();
        _playerResources = GameObject.FindWithTag("Player").GetComponent<PlayerResources>().playerResources;
        _enemyResources = GetComponent<EconomyManager>().opponentResources;
        _initialNumDice = NumOfDice;
        _initMarketPrice = _marketplaceHandler.marketPrice;
        UpdateSharePrice();
        StartTurn();
        ResolveButton.endResolveEvent += StartTurn;
    }

//TODO - figure out basic enemy AI
    public void StartTurn()
    {
        foreach (var card in ActivityCards)
        {
            card.ClearCard();
        }

        NumOfDice = _initialNumDice;
        
        //randomly assign dice
        for (int i = 0; i < NumOfDice; i++)
        {
            if(!ActivityCards[Random.Range(0, 3)].AddDice())
                Debug.Log("failed to generate dice");
        }
        
    }
    
    #region Buy/Sell Functions

    private void BuyBeaver()
    {
        _enemyResources.beaver++;
        _enemyResources.tokens -= _marketplaceHandler.marketPrice.beaver;
        _marketplaceHandler.UpdateBeaverPrice(-1);
    }

    private void SellBeaver()
    {
        _enemyResources.beaver--;
        _enemyResources.tokens += _marketplaceHandler.marketPrice.beaver;
        _marketplaceHandler.UpdateBeaverPrice(1);
    }

    private void BuyBeaverPelt()
    {
        _enemyResources.beaverPelts++;
        _enemyResources.tokens -= _marketplaceHandler.marketPrice.beaverPelts;
        _marketplaceHandler.UpdateBeaverPeltPrice(-1);
    }

    private void SellBeaverPelt()
    {
        
        _enemyResources.beaverPelts--;
        _enemyResources.tokens += _marketplaceHandler.marketPrice.beaverPelts;
        _marketplaceHandler.UpdateBeaverPeltPrice(1);
    }

    private void BuyBuffalo()
    {
        _enemyResources.buffalo++;
        _enemyResources.tokens -= _marketplaceHandler.marketPrice.buffalo;
        _marketplaceHandler.UpdateBuffaloPrice(-1);
    }

    private void SellBuffalo()
    {
        
        _enemyResources.buffalo--;
        _enemyResources.tokens += _marketplaceHandler.marketPrice.buffalo;
        _marketplaceHandler.UpdateBuffaloPrice(1);
    }

    private void BuyBuffaloPelt()
    {
        _enemyResources.buffaloPelts++;
        _enemyResources.tokens -= _marketplaceHandler.marketPrice.buffaloPelts;
        _marketplaceHandler.UpdateBuffaloPeltPrice(-1);
    }

    private void SellBuffaloPelt()
    {
        
        _enemyResources.buffaloPelts--;
        _enemyResources.tokens += _marketplaceHandler.marketPrice.buffaloPelts;
        _marketplaceHandler.UpdateBuffaloPeltPrice(1);
    }
    
    private void BuyPemmican()
    {
        _enemyResources.pemmican++;
        _enemyResources.tokens -= _marketplaceHandler.marketPrice.pemmican;
        _marketplaceHandler.UpdatePemmicanPrice(-1);
    }

    private void SellPemmican()
    {
        
        _enemyResources.pemmican--;
        _enemyResources.tokens += _marketplaceHandler.marketPrice.pemmican;
        _marketplaceHandler.UpdatePemmicanPrice(1);
    }
    
    #endregion

    #region NWC Share Function

    //TODO - share price equation
    private void UpdateSharePrice()
    {
        _currentSharePrice = 100 / (totNumShares - numOwnedShares);
        UpdateShareUI();
    }

    private void UpdateShareUI()
    {
        ownedShareNumText.text = numOwnedShares.ToString();
        totShareNumText.text = totNumShares.ToString();
        sharePriceText.text = _currentSharePrice.ToString();
    }

    public void OnBuySharePrice()
    {
        if (_playerResources.tokens >= _currentSharePrice)
        {
            _playerResources.tokens -= _currentSharePrice;
            numOwnedShares++;
            UpdateSharePrice();
            
            if(numOwnedShares == totNumShares && !_isInEndgame)
                OnEndGame();
        }
        else
        {
            WarningTextPopUp.WarningTextEvent("You can't afford to buy a share.");
        }
    }

    private void OnEndGame()
    {
        _isInEndgame = true;
        OnEndGameEvent?.Invoke();
        
    }
    

    #endregion
}
