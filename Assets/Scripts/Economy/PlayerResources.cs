using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public struct ResourceStruct
{
    
    public int tokens;
    public int beaver;
    public int buffalo;
    public int beaverPelts;
    public int buffaloPelts;
    public int pemmican;

}


public class PlayerResources : MonoBehaviour
{
    public ResourceStruct playerResources;

    [Header("Player Resources")] 
    public TextMeshProUGUI playerTokens;
    public TextMeshProUGUI beaverUI;
    public TextMeshProUGUI beaverPeltUI;
    public TextMeshProUGUI buffaloUI;
    public TextMeshProUGUI buffaloPeltUI;
    public TextMeshProUGUI pemmicanUI;
    [Header("Marketplace UI Elements")] 
    public TextMeshProUGUI beaverStockText;
    public TextMeshProUGUI buffaloStockText;
    public TextMeshProUGUI pemmicanStockText;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }


    public void DecrementTokens(int i)
    {
        playerResources.tokens -= i;
        UpdateUI();
    }

    public void IncrementBeaver(int i)
    {
        playerResources.beaver += i;
        UpdateUI();
    }

    public void DecrementBeaver(int i)
    {
        playerResources.beaver -= i;
        UpdateUI();
    }

    public void IncrementBeaverPelts(int i)
    {
        playerResources.beaverPelts += i;
        UpdateUI();
    }

    public void IncrementBuffalo(int i)
    {
        playerResources.buffalo += i;
        UpdateUI();
    }

    public void DecrementBuffalo(int i)
    {
        playerResources.buffalo -= i;
        UpdateUI();
    }
    
    public void IncrementBuffaloPelts(int i)
    {
        playerResources.buffaloPelts += i;
        UpdateUI();
    }

    public void IncrementPemmican(int i)
    {
        playerResources.pemmican += i;
        UpdateUI();
    }
    
    

    private void UpdateUI()
    {
        beaverStockText.text = playerResources.beaverPelts.ToString();
        buffaloStockText.text = playerResources.buffaloPelts.ToString();
        pemmicanStockText.text = playerResources.pemmican.ToString();
        playerTokens.text = playerResources.tokens.ToString();

        beaverUI.text = playerResources.beaver.ToString();
        beaverPeltUI.text = playerResources.beaverPelts.ToString();
        buffaloUI.text = playerResources.buffalo.ToString();
        buffaloPeltUI.text = playerResources.buffaloPelts.ToString();
        pemmicanUI.text = playerResources.pemmican.ToString();

    }
    
}
