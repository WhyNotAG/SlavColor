using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoardManager))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private BoardManager _boardManager;
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        _boardManager = GetComponent<BoardManager>();
        _boardManager.Startup();
    }
}
