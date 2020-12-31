using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable] 
    public class Wave
    {
        public string name;
        public GameObject enemyPrefab;
        public int count;
        public float spawnRate;
    }

    public Wave[] waves;
    private int nextIndex = 0;
    public float timeBtwWave = 5f;
    public float searchCounter = 1f;
    public float timer = 0f;

    public enum STATE
    {
        SPAWNING, WAITING, COUNTING
    }

    public STATE state = STATE.COUNTING;

    // public Spawner[] spawnPoints;
    public List<Spawner> spawnPoints;
    
    public List<Spawner> wave1;
    public List<Spawner> wave2;
    public List<Spawner> wave3;
    public List<Spawner> wave4;

    void Start()
    {
        timer = timeBtwWave;
    }

    void Update()
    {
        if (state == STATE.WAITING)
        {
            // make sure all enemies killed
            searchCounter -= Time.deltaTime;
            if (searchCounter <= 0f)
            {
                searchCounter = 1f;
                if (GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    // print("New round started");

                    nextIndex++;
                    GameManager.instance.currentWave = nextIndex;
                    AudioManager.instance.Play("nextRound");
                    state = STATE.COUNTING;
                    timer = timeBtwWave;
                    // TODO Enable the next spawners
                    switch(nextIndex)
                    {
                        case 1:
                            foreach (var item in wave1)
                            {
                                item.gameObject.SetActive(true);
                                spawnPoints.Add(item);
                            }
                            break;
                        case 2:
                            foreach (var item in wave2)
                            {
                                item.gameObject.SetActive(true);
                                spawnPoints.Add(item);
                            }
                            break;
                        case 3:
                            foreach (var item in wave3)
                            {
                                item.gameObject.SetActive(true);
                                spawnPoints.Add(item);
                            }
                            break;
                        case 4:
                            foreach (var item in wave4)
                            {
                                item.gameObject.SetActive(true);
                                spawnPoints.Add(item);
                            }
                            break;
                    }

                    if (nextIndex > waves.Length - 1)
                    {
                        // print("COMPLETE");
                        SceneManager.LoadScene(2);
                    }

                    return;
                }
                else 
                {
                    // print("round not over");
                    return;
                }
            }
            else
            {
                return;
            }
        }

        if (timer <= 0)
        {
            if (state != STATE.SPAWNING)
            {
                // Spawning
                StartCoroutine(SpawnWave(waves[nextIndex]));
                
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave wave)
    {
        // print("Spawning wave");
        state = STATE.SPAWNING;
        
        //SPAWNING
        for (int i = 0; i < wave.count; i++)
        {
            // print($"Enemy spawned {wave.enemyPrefab.name}");
            Transform sp = spawnPoints[Random.Range(0, spawnPoints.Count)].spawnPoint;
            Instantiate(wave.enemyPrefab, sp.position, sp.rotation);
            yield return new WaitForSeconds(1f/wave.spawnRate);
        }
        // print("Done Spawning");
        // timer = timeBtwWave;

        state = STATE.WAITING;
        yield break;
    }

}
