using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private int _powerUpID;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6.59)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(Vector3.down*_speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player =  other.transform.GetComponent<Player>();
            
            if (player!= null)
            {
                if (_powerUpID == 0)
                {
                     player.ActivateTripleShot();
                }
                else if(_powerUpID == 1)
                {
                    Debug.Log("Speed Collected");
                }
                else if (_powerUpID == 2)
                {
                    Debug.Log("Sheild Collected");
                }


              
                Destroy(this.gameObject);
            }
            
        }


    }



}
