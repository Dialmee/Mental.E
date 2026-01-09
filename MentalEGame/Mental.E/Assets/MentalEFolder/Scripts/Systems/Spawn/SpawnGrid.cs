using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class SpawnGrid : MonoBehaviour
{

    //TODO: round calculation and modification of enemies stats
    public float fFrequence = 10f;
    [SerializeField]private SpawnAxe[] spawnAxes = new SpawnAxe[9];
    [SerializeField] private FoeStat foeStat;

    [SerializeField] private int baseEnemiesNumber = 2;
    [SerializeField] private int baseAsteroidNumber = 1;

     private float timeBetweenRound = 3f;
     private float timeBetweenWave = 1f;

    [SerializeField] private int round = 1;

    private int[] RoundBuffer = {0, 0};//enemie, asteroid

    private bool _waveSpawning = false;
    private float _tTimer = 0f;
    private float _tNextRoundSpawn = 0f;
    private float _tNextWaveSpawn = 0f;

    private void Start()
    {
        foeStat.Start();
    }


    private void Update()
    {
        TimerCheck();
    }

    private void TimerCheck()
    {

        _tTimer += Time.deltaTime;


        if (!_waveSpawning && _tNextRoundSpawn < _tTimer)
        {
            CalculateEnemieRound();
            _waveSpawning = true;
        }

        if (_waveSpawning && _tNextWaveSpawn < _tTimer)
        {
            //Debug.Log(_tNextWaveSpawn +"   "+ _tTimer);
            _tNextWaveSpawn = _tTimer + timeBetweenWave;
            SpawnWave();
        }
    }

    private void CalculateEnemieRound()
    {
        int nbEnemie = baseEnemiesNumber + (baseEnemiesNumber * (round / 5));
        int nbAsteroid = baseAsteroidNumber + (baseEnemiesNumber * (round / 5));

        foeStat.maxHP = foeStat.initialMaxHP * (round/3);
        foeStat.BulletDamage = foeStat.initialBulletDamage * (round / 5);

        Debug.Log("For this round "+round+", enemies: "+nbEnemie+" and asteroids:"+nbAsteroid);

        RoundBuffer[0] = nbEnemie; 
        RoundBuffer[1] = nbAsteroid; 
    }

    private void EndSpawnRound()
    {
        _waveSpawning = false;
        _tNextRoundSpawn = _tTimer + timeBetweenRound;
        round++;
    }

    private void SpawnWave()
    {
        int qtt = RoundBuffer[0] + RoundBuffer[1];
        Debug.Log("Spawning Wave, qtt:" + qtt);
        if (qtt == 0) { 
            EndSpawnRound();
            return;
        }

        if (qtt >= 9)
            qtt = 9;

        qtt = Random.Range(qtt / 3, qtt);

        if (qtt <= 0)
            qtt = 1;
        
        List<int> availableList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        int i;

        for (int j =qtt; j>0; j--)
        {
            i = Random.Range(0, availableList.Count());
            spawnAxes[availableList[i]].Spawn(IsNextEnemy());
            availableList.RemoveAt(i);
        }
    }


    private bool IsNextEnemy()
    {
        int i = Random.Range(1, RoundBuffer[0] + RoundBuffer[1]);
        if (RoundBuffer[0] >= i)
        {
            RoundBuffer[0]--;
            return true;
        }else
        {
            RoundBuffer[1]--;
            return false;
        }
    }
}
