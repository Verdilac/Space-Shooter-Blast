using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    [SerializeField] private float _speed = 7.0f;
    [SerializeField] public GameObject _laserPrefab;
    [SerializeField] private GameObject _tripleShotPrefab;
    [SerializeField] private GameObject _sheildVisualizer;
    [SerializeField] private float _fireRate = 0.15f;
    [SerializeField] private int _lives = 3;
    private SpawnManager _spawnManager;
    [SerializeField]private bool _tripleShotActive = false;
    [SerializeField] public bool _speedBoostActive = false;
    [SerializeField] private bool _sheildActive = false;
    [SerializeField] Enemy _enemy;
    [SerializeField] Transform _enemyContainer;
    [SerializeField] private bool simulascheck = false;



    private float _canFire = -1f;

    void Start()
    {
        //Zeroing out the Player Object
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");
        }
    
        

    }

  
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }


    }



    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);


        //time.delta time is the time you have between 2 frames typically very close to 1 second.

     
     
        transform.Translate(direction * _speed * Time.deltaTime);
     
       

        if (transform.position.x > 11.35)
        {
            transform.position = new Vector3(-11.35f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -11.35)
        {
            transform.position = new Vector3(11.35f, transform.position.y, transform.position.z);
        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.98f, 0), 0);
    }

    void FireLaser()
    {

        //the reason we re incrementing this is we need the statement fail inbetween firing and the next shot.so while (*ex)time might be 1 can fire would be 1.5 and untill time hit 1.6 you cant fire
        
        if (!_tripleShotActive)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);
        }
        else
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_tripleShotPrefab, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);
           //  _tripleShotActive = false;
        }
        
       
    }

    public void Damage()
    {
        if (_sheildActive)
        {
            _sheildVisualizer.SetActive(false);
            _sheildActive = false;
            return;
        }
        _lives --;

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }

    }

    public void ActivateTripleShot()
    {
      
        _tripleShotActive = true;
        StartCoroutine(PowerDownRoutine());


    }
    public void ActivateSpeedBoost()
    {

        _speedBoostActive= true;
        StartCoroutine(PowerDownRoutine());
        _speed = 14.0f;

        Debug.Log("Activate Speed Boost is getting called ");


        
      




    }

    public void ActivateSheild()
    {
        _sheildVisualizer.SetActive(true);
        _sheildActive = true;


    
    }

    IEnumerator PowerDownRoutine()
    {
        if (_tripleShotActive)
        {
            yield return new WaitForSeconds(5.0f);
            _tripleShotActive = false;
        }
        if (_speedBoostActive)
        {
            yield return new WaitForSeconds(5.0f);
            _speedBoostActive= false;


            foreach (Transform enemy in _enemyContainer)
            {
                _enemy.ChangeSpeed(4.0f);
            }

            _speed = 7.0f;
        }
   

           
    }

    public bool CheckSpeed()
    {
        if (_speedBoostActive)
        {
            return true;
        }
        else
        {
            return false;   
        }

    }


}
