using System;
using 
System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random =  UnityEngine.Random;

public class BoardManager : MonoBehaviour, IManager
{
    [Serializable]
    public class Count
    {
        private int _min;
        private int _max;
        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }
        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }
        public Count(int min, int max)
        {
            this._min = min;
            this._max = max;
        }
    }

    [SerializeField] private int _columns;
    [SerializeField] private int _rows;
    [SerializeField] private Count _wallCount;
    [SerializeField] private Count _foodCount;
    [SerializeField] private GameObject _exit;
    [SerializeField] private GameObject[] _floorTiles;
    [SerializeField] private GameObject[] _wallTiles;
    [SerializeField] private GameObject[] _outerWallTiles;
    [SerializeField] private GameObject[] _foodTiles;
    [SerializeField] private GameObject _player;
    private Transform boardHolder;
    private List<Vector3> gridPosition;
    public ManagerStatus managerStatus { get; private set; }
    
    void InitialiseList()
    {
        gridPosition.Clear();

        for (int x = 1; x < _columns - 1; x++)
        {
            for (int y = 1; y < _rows - 1; y++)
            {
                gridPosition.Add(new Vector3(x, y, 0.0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = -1; x < _columns + 1; x++)
        {
            for (int y = -1; y < _rows + 1; y++)
            {
                GameObject toInstantiate = _floorTiles[Random.Range(0, _floorTiles.Length)];

                if (x == -1 || x == _columns || y == -1 || y == _rows)
                {
                    toInstantiate = _outerWallTiles[Random.Range(0, _outerWallTiles.Length)];
                }

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0.0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPosition.Count);
        Vector3 randomPosition = gridPosition[randomIndex];
        gridPosition.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectsAtRandom(GameObject[] tileArray, int min, int max)
    {
        int objectCount = Random.Range(min, max + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void Startup()
    {
        Debug.Log("Board manager started");
        _columns = 120;
        _rows = 120;
        
        _wallCount = new Count(5, 9);
        _foodCount = new Count(1, 5);
        gridPosition = new List<Vector3>();
        BoardSetup();
        InitialiseList();
        LayoutObjectsAtRandom(_wallTiles, _wallCount.Min, _wallCount.Max);
        LayoutObjectsAtRandom(_foodTiles, _foodCount.Min, _foodCount.Max);
        Instantiate(_exit, new Vector3(_columns - 1, _rows  - 1, 0.0f), Quaternion.identity);
        Instantiate(_player, new Vector3(1, 1), Quaternion.identity);
        managerStatus = ManagerStatus.Started;
    }
    
    
}
