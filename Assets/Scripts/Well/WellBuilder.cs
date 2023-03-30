using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellBuilder : MonoBehaviour
{
    [Header("WellBuilder")]
    [SerializeField] private GameObject _wellPrefab;
    [SerializeField] private GameObject _nextWellPrefab;
    [Header("RangeSpawn")]
    [SerializeField] private float _rangeSpawnWellToStart;
    [SerializeField] private float _rangeSpawnWell;
    [SerializeField] private float _rangeSpawnWellMax;
    [Header("SizeDoubleWell")]
    [SerializeField] private float _sizeDoubleWellToStart;
    [SerializeField] private float _sizeDoubleWell;
    [SerializeField] private float _sizeDoubleWellMax;
    [Header("SizeOneWell")]
    [SerializeField] private float _sizeOneWellToStart;
    [SerializeField] private float _sizeOneWell;
    [SerializeField] private float _sizeOneWellMax;
    [Header("SpeedWell")]
    [SerializeField] private float _speedWellToStart;
    [SerializeField] private float _speedWell;
    [SerializeField] private float _speedWellMax;
    [SerializeField] private GameObject _gemPrefab;

    private List<GameObject> _wellList = new List<GameObject>();

    private void Start()
    {
        LevelSettings.instance.OnStartLevel += StartBuildWell;
        LevelSettings.instance.OnResumeLevel += BuildWell;
        LevelSettings.instance.OnFinishLevel += DestroyAllWells;
    }
    void StartBuildWell()
    {
        _rangeSpawnWell = _rangeSpawnWellToStart;
        _sizeDoubleWell = _sizeDoubleWellToStart;
        _sizeOneWell = _sizeOneWellToStart;
        _speedWell = _speedWellToStart;
        
        BuildWell();
    }
    public void BuildWell()
    {
        var rand = Random.Range(0, 100);
        Vector3 posTopWell = new Vector3(transform.position.x + _rangeSpawnWell, 10, 10);
        Vector3 posBottomWell = new Vector3(transform.position.x + _rangeSpawnWell, -10, 10);

        if (rand <= 33)
        {
            InstatiateWell(_wellPrefab, posTopWell, Quaternion.Euler(0, 0, 180), _sizeOneWell);
        }
        else if (rand <= 66)
        {
            InstatiateWell(_wellPrefab, posBottomWell, Quaternion.identity, _sizeOneWell);
        }
        else
        {
            InstatiateWell(_wellPrefab, posTopWell, Quaternion.Euler(0, 0, 180), _sizeDoubleWell);
            InstatiateWell(_wellPrefab, posBottomWell, Quaternion.identity, _sizeDoubleWell);

        }
        InstatiateWell(_nextWellPrefab, posBottomWell, Quaternion.identity, _sizeDoubleWell);
    }

    private void InstatiateWell(GameObject prefab, Vector3 posWell, Quaternion quaternion, float size)
    {
        GameObject well = Instantiate(prefab, posWell, quaternion) as GameObject;
        well.GetComponentInParent<SetWellConfiguration>().SetConfiguration(_speedWell, size);
        _wellList.Add(well);
    }

    public void SetBiggestSize()
    {

        _sizeDoubleWell = _sizeDoubleWell < _sizeDoubleWellMax ? _sizeDoubleWell + 0.1f : _sizeDoubleWell = _sizeDoubleWellMax;
        _sizeOneWell = _sizeOneWell < _sizeOneWellMax ? _sizeOneWell + 0.1f : _sizeOneWell = _sizeOneWellMax;

    }
    public void SetFasterWells()
    {

        _speedWell = _speedWell < _speedWellMax ? _speedWell + 0.1f : _speedWell = _speedWellMax;

    }
    public void DestroyAllWells()
    {
        foreach (var item in _wellList)
        {
            Destroy(item);
        }
    } 
    void DropItem(GameObject prefab, Transform transform)
    {
        GameObject item =  Instantiate(prefab, transform) as GameObject;
        //item.transform.localPosition = new Vector3(0, Random.Range(-_sizeHoleInWell + 0.5f, _sizeHoleInWell- 0.5f), 10);
    }
    void RandomDrop(Transform transform)
    {
        var randomInt = Random.Range(0, 100);
        if (randomInt <= 30)
            DropItem(_gemPrefab, transform);
       // Debug.Log(randomInt);

    }
}
