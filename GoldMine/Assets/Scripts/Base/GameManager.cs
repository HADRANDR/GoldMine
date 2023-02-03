using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    int _randomX, _randomY, _instantiateValue1, _instantiateValue2;
    [SerializeField] GameObject[] prefabs;
    [HideInInspector] public UnityEvent GameStart = new();
    [HideInInspector] public UnityEvent GameReady = new();
    [HideInInspector] public UnityEvent GameEnd = new();
    [HideInInspector] public UnityEvent LevelSuccess = new();
    [HideInInspector] public UnityEvent LevelFail = new();
    [HideInInspector] public UnityEvent OnMoneyChange = new();

    private float playerMoney;
    public float PlayerMoney
    {
        get
        {
            return playerMoney;
        }
        set
        {
            playerMoney = value;
            OnMoneyChange.Invoke();
        }
    }

    private bool hasGameStart;
    public bool HasGameStart
    {
        get
        {
            return hasGameStart;
        }
        set
        {
            hasGameStart = value;
        }
    }

    private void Awake()
    {
        LoadData();
        _instantiateValue1 = Random.Range(1, 6);
        _instantiateValue2 = Random.Range(1, 6);

        if (_instantiateValue1 > _instantiateValue2)
        {
            for (int i = 0; i < _instantiateValue1; i++)
            {
                _randomX = Random.Range(-7, 7);
                _randomY = Random.Range(-4, -23);
                Instantiate(prefabs[0], new Vector3(_randomX, _randomY, -0.1f), Quaternion.identity);
            }
            for (int i = 0; i < _instantiateValue2; i++)
            {
                _randomX = Random.Range(-7, 7);
                _randomY = Random.Range(-4, -23);
                Instantiate(prefabs[1], new Vector3(_randomX, _randomY, -0.1f), Quaternion.identity);
            }
        }
        else
        {
            for (int i = 0; i < _instantiateValue1; i++)
            {
                _randomX = Random.Range(-7, 7);
                _randomY = Random.Range(-4, -23);
                Instantiate(prefabs[1], new Vector3(_randomX, _randomY, -0.1f), Quaternion.identity);
            }
            for (int i = 0; i < _instantiateValue2; i++)
            {
                _randomX = Random.Range(-7, 7);
                _randomY = Random.Range(-4, -23);
                Instantiate(prefabs[0], new Vector3(_randomX, _randomY, -0.1f), Quaternion.identity);
            }
        }
    }

    public void LevelState(bool value)
    {
        if (value) LevelSuccess.Invoke();
        else LevelFail.Invoke();
    }

    private void OnEnable()
    {
        GameStart.AddListener(() => hasGameStart = true);
        GameEnd.AddListener(() => hasGameStart = false);
    }

    private void OnDisable()
    {
        SaveData();
    }

    void LoadData()
    {
        playerMoney = PlayerPrefs.GetFloat("PlayerMoney", 0);
    }

    void SaveData()
    {
        PlayerPrefs.SetFloat("PlayerMoney", playerMoney);
    }
}
