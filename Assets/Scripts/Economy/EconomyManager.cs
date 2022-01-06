using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public ResourceStruct opponentResources;
    
    [Header("Enemy Resources")] 
    public TextMeshProUGUI playerTokens;
    public TextMeshProUGUI beaverUI;
    public TextMeshProUGUI beaverPeltUI;
    public TextMeshProUGUI buffaloUI;
    public TextMeshProUGUI buffaloPeltUI;
    public TextMeshProUGUI pemmicanUI;
    public void IncrementBeaver(int i)
    {
        opponentResources.beaver += i;
        UpdateUI();

    }

    public void IncrementBeaverPelts(int i)
    {
        opponentResources.beaverPelts += i;
        UpdateUI();

    }
    
    public void DecrementBeaver(int i)
    {
        opponentResources.beaver -= i;
        UpdateUI();

    }

    public void IncrementBuffalo(int i)
    {
        opponentResources.buffalo += i;
        UpdateUI();

    }

    public void DecrementBuffalo(int i)
    {
        opponentResources.buffalo -= i;
        UpdateUI();
    }
    
    public void IncrementBuffaloPelts(int i)
    {
        opponentResources.buffaloPelts += i;
        UpdateUI();

    }
    
    

    public void IncrementPemmican(int i)
    {
        opponentResources.pemmican += i;
        UpdateUI();

    }

    private void UpdateUI()
    {
        /*
        beaverUI.text = opponentResources.beaver.ToString();
        beaverPeltUI.text = opponentResources.beaverPelts.ToString();
        buffaloUI.text = opponentResources.buffalo.ToString();
        buffaloPeltUI.text = opponentResources.buffaloPelts.ToString();
        pemmicanUI.text = opponentResources.pemmican.ToString();
        */
    }
}
