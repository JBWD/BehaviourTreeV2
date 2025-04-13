using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TowerDefenseGameManager : MonoBehaviour
{
   
    private static TowerDefenseGameManager instance;

    public static TowerDefenseGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<TowerDefenseGameManager>();
            }
            return instance;;
        }
    }
    public int startingCurrency = 100;
    private int currentCurrency = 0;

    public int startingLives = 20;
    private int currentLives = 0;

    public int numberOfRounds = 10;
    private int currentRound = 0;

    private List<int> roundsFinished = new List<int>();
    private List<int> roundsStarted = new List<int>();
    
    private bool roundStarted = false;
    private bool roundFinished = false;
    
    public UnityEvent OnGameWin;
    public UnityEvent OnGameOver;
    public UnityEvent<int> OnLoseLife;
    public UnityEvent<int> OnGainLife;
    public UnityEvent<int> OnLifeChange;
    public UnityEvent<int> OnCurrencyIncrease;
    public UnityEvent<int> OnCurrencyDecrease;
    public UnityEvent<int> OnCurrencyChange;
    public UnityEvent<int> OnRoundChange;
    public UnityEvent<int> OnRoundStart;
    public UnityEvent<int> OnRoundEnd;
    
    public Action OnGameWinAction;
    public Action OnGameOverAction;
    public Action<int> OnLoseLifeAction;
    public Action<int> OnGainLifeAction;
    public Action<int> OnLifeChangeAction;
    public Action<int> OnCurrencyIncreaseAction;
    public Action<int> OnCurrencyDecreaseAction;
    public Action<int> OnCurrencyChangeAction;
    public Action<int> OnRoundChangeAction;
    public Action<int> OnRoundStartAction;
    public Action<int> OnRoundEndAction;
    
    
    public void Awake()
    {
        if(instance == null)
           instance = this;
        if (instance != this)
        {
            Destroy(this);
        }
    }

    public void Start()
    {
        currentLives = startingLives;
        currentCurrency = startingCurrency;
    }

    public bool HasCurrency(int amount)
    {
        return currentCurrency >= amount;
    }
    
    public int GetCurrentLives()
    {
        return currentLives;
    }

    public int GetCurrentCurrency()
    {
        return currentCurrency;
    }

    public int GetCurrentRound()
    {
        return currentRound;
    }
    
    public void IncreaseCurrency(int amount)
    {
        currentCurrency += amount;
        OnCurrencyIncreaseAction?.Invoke(amount);
        OnCurrencyIncrease?.Invoke(amount);
        OnCurrencyChangeAction?.Invoke(amount);
        OnCurrencyChange?.Invoke(amount);
    }

    public void DecreaseCurrency(int amount)
    {
        currentCurrency -= amount;
        OnCurrencyDecreaseAction?.Invoke(amount);
        OnCurrencyDecrease?.Invoke(amount);
        OnCurrencyChangeAction?.Invoke(amount);
        OnCurrencyChange?.Invoke(amount);
    }

    public void IncreaseLives(int amount)
    {
        currentLives += amount;
        OnGainLifeAction?.Invoke(amount);
        OnGainLife?.Invoke(amount);
        OnLifeChangeAction?.Invoke(amount);
        OnLifeChange?.Invoke(amount);
    }

    public void DecreaseLives(int amount)
    {
        currentLives -= amount;
        OnLoseLifeAction?.Invoke(amount);
        OnLoseLife?.Invoke(amount);
        OnLifeChangeAction?.Invoke(amount);
        OnLifeChange?.Invoke(amount);
        if (currentLives <= 0)
        {
            OnGameOverAction?.Invoke();
            OnGameOver?.Invoke();
        }
    }

    public bool HasCurrentRoundStarted()
    {
        return roundStarted;
    }
    public bool IsCurrentRoundRunning()
    {
        return roundStarted && !roundFinished;
    }
    public bool HasCurrentRoundFinished()
    {
        return roundFinished;
    }

    public bool HasRoundStarted(int valueIntegerValue)
    {
        return roundsStarted.Contains(valueIntegerValue);
    }
    public bool IsRoundRunning(int roundNumber)
    {
        return (HasRoundStarted(roundNumber) && roundNumber == currentRound && !HasRoundFinished(roundNumber));
    }
    
    public bool HasRoundFinished(int valueIntegerValue)
    {
        return roundsFinished.Contains(valueIntegerValue);
    }

    public void IncrementRound()
    {
        
        currentRound++;
        OnRoundChangeAction?.Invoke(currentRound);
        OnRoundChange?.Invoke(currentRound);
    }
    public void DecreaseRound()
    {
        currentRound--;
        OnRoundChangeAction?.Invoke(currentRound);
        OnRoundChange?.Invoke(currentRound);
    }

    public void ReplayRound()
    {
        if(roundsFinished.Contains(currentRound))
            roundsFinished.Remove(currentRound);
        if(roundsStarted.Contains(currentRound))
            roundsStarted.Remove(currentRound);
        
        OnRoundChangeAction?.Invoke(currentRound);
        OnRoundChange?.Invoke(currentRound);
    }
    
    public void RoundEnded()
    {
        if(!roundsFinished.Contains(currentRound))
            roundsFinished.Add(currentRound);
        roundStarted = false;
        roundFinished = true;
        OnRoundEndAction?.Invoke(currentRound);
        OnRoundEnd?.Invoke(currentRound);
        if (currentRound >= numberOfRounds)
        {
            OnGameWin?.Invoke();
            OnGameWinAction?.Invoke();
        }
    }

    public void RoundStarted()
    {
        if(roundsFinished.Contains(currentRound))
            roundsFinished.Remove(currentRound);
        if(!roundsStarted.Contains(currentRound))
            roundsStarted.Add(currentRound);
        roundStarted = true;
        roundFinished = false;
        OnRoundStartAction?.Invoke(currentRound);
        OnRoundStart?.Invoke(currentRound);
    }


    public void GameWon()
    {
        OnGameWinAction?.Invoke();
        OnGameWin?.Invoke();
    }

 
}
