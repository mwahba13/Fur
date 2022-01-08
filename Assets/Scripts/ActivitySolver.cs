using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActivitySolver : MonoBehaviour
{

    public EconParams econParams;
    public ActivityCard enemyActivity;
    
    private PlayerResources _playerResources;
    private EconomyManager _econManager;
    private ActivityCard _activityCard;

    private ActivityAnimator _activityAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _activityCard = GetComponent<ActivityCard>();
        _activityAnimator = GetComponent<ActivityAnimator>();
        _playerResources = GameObject.FindWithTag("Player").GetComponent<PlayerResources>();
        _econManager = GameObject.FindWithTag("GameController").GetComponent<EconomyManager>();

        ResolveButton.resolveTurnEvent += Resolve;
    }


    public void Resolve()
    {
        //roll enemy die

        Stack<int> enemyRolls = enemyActivity.RollDice();
        Stack<int> playerRolls = _activityCard.RollDice();

        if (playerRolls.Count > enemyRolls.Count)
        {
            while (playerRolls.Count > 0)
            {
                int enemRoll = -1;
                int playRoll = playerRolls.Pop();
                
                enemRoll = enemyRolls.Count > 0 ? enemyRolls.Pop() : 0;
                
              //  Debug.Log("Player rolls: " + playRoll + " Enem roll: "+ enemRoll);
                
                if(playRoll > enemRoll)
                    AwardResourcesPlayer(playRoll - enemRoll);
                else if(playRoll < enemRoll)
                    AwardResourcesEnemy(enemRoll - playRoll);
            }

        }
        else
        {
            while (enemyRolls.Count > 0)
            {
                int playRoll = -1;
                int enemRoll = enemyRolls.Pop();
                
                playRoll = playerRolls.Count > 0 ? playerRolls.Pop() : 0;
                
               // Debug.Log("Player rolls: " + playRoll + " Enem roll: "+ enemRoll);

                
                if(playRoll > enemRoll)
                    AwardResourcesPlayer(playRoll - enemRoll);
                else if(playRoll < enemRoll)
                    AwardResourcesEnemy(enemRoll - playRoll);
            }
            
        }
        
        

    }
    
    //i is difference between winner dice roll and loserDiceRoll
    private void AwardResourcesPlayer(float i)
    {
        switch (_activityCard.cardType)
        {
            case ECardType.EHuntBeaver:
                int awardedBeaver = Mathf.CeilToInt(i/econParams.huntBeaverDivisor);
                _playerResources.IncrementBeaver(awardedBeaver);
               // Debug.Log("Player is awarded: " + awardedBeaver +" beavers");
                break;
            case ECardType.EHuntBuffalo:
                int awardedBuff = Mathf.CeilToInt(i / econParams.huntBuffaloDivisor);
                _playerResources.IncrementBuffalo(awardedBuff);
               // Debug.Log("Player is awarded: " + awardedBuff + " buffalo");
                break;
            
            case ECardType.EProcessBeaver:
                int awardedBeavPelt = Mathf.CeilToInt(i / econParams.processBeaverDivisor);
                if (awardedBeavPelt > _playerResources.playerResources.beaver)
                    awardedBeavPelt = _playerResources.playerResources.beaver;
                _playerResources.DecrementBeaver(awardedBeavPelt);
                _playerResources.IncrementBeaverPelts(awardedBeavPelt);
              //  Debug.Log("Player is awarded: "+ awardedBeavPelt+ " beaver pelts");
                break;
            
            case ECardType.EProcessBuffalo:
                int awardedBuffTotal = Mathf.CeilToInt(i / econParams.processBuffaloDivisor);

                if (awardedBuffTotal > _playerResources.playerResources.buffalo)
                    awardedBuffTotal = _playerResources.playerResources.buffalo;
                
                int awardedBuffPelt = 0;
                int awardedPemmican = 0;
                for(int j = 0;j < awardedBuffTotal;j++)
                    if (Random.Range(0, 2) == 0)
                        awardedPemmican++;
                    else
                        awardedBuffPelt++;

                _playerResources.DecrementBuffalo(awardedBuffTotal);
                _playerResources.IncrementBuffaloPelts(awardedBuffPelt);
                _playerResources.IncrementPemmican(awardedPemmican);
                
              //  Debug.Log("Player gains: " + awardedBuffPelt +" buff pelt and " + awardedPemmican 
                 //         + " Pemmican");
                
                break;
        }
    }
    
    //i is difference between winner dice roll and loserDiceRoll
    private void AwardResourcesEnemy(float i)
    {
        switch (_activityCard.cardType)
        {
            case ECardType.EHuntBeaver:
                int awardedBeaver = Mathf.CeilToInt(i/econParams.huntBeaverDivisor);
                _econManager.IncrementBeaver(awardedBeaver);
               // Debug.Log("Enem is awarded: " + awardedBeaver +" beavers");
                break;
            case ECardType.EHuntBuffalo:
                int awardedBuff = Mathf.CeilToInt(i / econParams.huntBuffaloDivisor);
                _econManager.IncrementBuffalo(awardedBuff);
              //  Debug.Log("Enem is awarded: " + awardedBuff + " buffalo");
                break;
            case ECardType.EProcessBeaver:
                int awardedBeavPelt = Mathf.CeilToInt(i / econParams.processBeaverDivisor);
                if (awardedBeavPelt > _econManager.opponentResources.beaver)
                    awardedBeavPelt = _econManager.opponentResources.beaver;
                _econManager.DecrementBeaver(awardedBeavPelt);
                _econManager.IncrementBeaverPelts(awardedBeavPelt);
              //  Debug.Log("Enem is awarded: "+ awardedBeavPelt+ " beaver pelts");
                break;
            case ECardType.EProcessBuffalo:
                int awardedBuffTotal = Mathf.CeilToInt(i / econParams.processBuffaloDivisor);

                if (awardedBuffTotal > _econManager.opponentResources.buffalo)
                    awardedBuffTotal = _econManager.opponentResources.buffalo;
                
                int awardedBuffPelt = 0;
                int awardedPemmican = 0;
                for(int j = 0;j < awardedBuffTotal;j++)
                    if (Random.Range(0, 2) == 0)
                        awardedPemmican++;
                    else
                        awardedBuffPelt++;
                _econManager.DecrementBuffalo(awardedBuffTotal);
                _econManager.IncrementBuffaloPelts(awardedBuffPelt);
                _econManager.IncrementPemmican(awardedPemmican);
             //   Debug.Log("Enemy gains: " + awardedBuffPelt +" buff pelt and " + awardedPemmican 
             //             + " Pemmican");
                break;
        }
    }
}
