using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject _enemyPrefab;
    [SerializeField ] private GameObject _enemyContainer;
    private bool _stopSpawning = false;
    void Start()
    {
         StartCoroutine(SpawnRoutine());
    }

  
    void  Update()
    {
       
    }  
    IEnumerator SpawnRoutine()
        {
            while (_stopSpawning == false)
            {
                float randomX = Random.Range(-8.70f, 8.70f);
                Vector3 posToSpawn = new Vector3(randomX, 6.44f, 0);
                GameObject newEnemy =  Instantiate(_enemyPrefab, posToSpawn,Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
                yield return new WaitForSeconds(5.0f);
            }
        }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
        Destroy(_enemyContainer);
    }
}
