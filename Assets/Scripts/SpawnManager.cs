using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] public GameObject _enemyPrefab;
    [SerializeField] Enemy _enemy;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject _tripleShotPrefab;
    [SerializeField] private GameObject _speedBoostPrefab;
    [SerializeField]GameObject[] _powerUps;
    private bool _stopSpawning = false;
    private bool _stopPowerups = false;
    void Start()
    {

        


        StartCoroutine(SpawnEnemyRoutine());

        
        StartCoroutine(SpawnPowerupRoutine());
    }

  
    void  Update() 
    {
       
    }  
    IEnumerator SpawnEnemyRoutine()
        {
            while (_stopSpawning == false)
            {

          
                
                
            float randomX = Random.Range(-8.70f, 8.70f);
            Vector3 posToSpawn = new Vector3(randomX, 6.44f, 0);
            
       
         
        
                GameObject newEnemy =  Instantiate(_enemyPrefab, posToSpawn,Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
                
            if (_player.GetComponent<Player>()._speedBoostActive)
            {
                newEnemy.GetComponent<Enemy>().ChangeSpeed(8.0f);


                Transform[] allchildren = _enemyContainer.GetComponentsInChildren<Transform>();
                foreach (Transform child in allchildren)
                {
                    _enemy.ChangeSpeed(8.0f);
                }
            }
            else
            {
                newEnemy.GetComponent<Enemy>().ChangeSpeed(4.0f);
            }
                
        
            yield return new WaitForSeconds(5.0f);
           


            //check for is the speed boost is active through player and instanciate second enemy prefab if the speed is collected
        
            
                

                
            }
        }

    IEnumerator SpawnPowerupRoutine()
    {
        while(_stopPowerups ==false)
        {
            Vector3 posToSpawn = Xrandomize(-8.70f, 8.70f);
            int whichPowerUp = Random.Range(0, 3);

            //makes sense to add power ups a bit later.
            if (Time.deltaTime > 10)
            {
                yield return new WaitForSeconds(Random.Range(7,12));
                //12 is exclusive make it float to include max
                GameObject newPowerup = Instantiate(_powerUps[whichPowerUp], posToSpawn, Quaternion.identity);
            }
        
            else
            {
                yield return new WaitForSeconds(11);
                GameObject newPowerup = Instantiate(_powerUps[whichPowerUp], posToSpawn, Quaternion.identity);
            }
        }
     

    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
        Destroy(_enemyContainer);
    }

    private Vector3 Xrandomize(float min ,float max)
    {
        float randomX = Random.Range(min, max);
        Vector3 posToSpawn = new Vector3(randomX, 6.44f, 0);
        return posToSpawn;
    }

 
         
  
}
