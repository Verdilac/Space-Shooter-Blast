using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private int _powerUpID;
    /*Powerup ID
     * 0 = Triple Shot
     * 1 = Speed
     * 2 = Sheilds
    */
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
              
                switch (_powerUpID)
                {
                    case 0:
                        player.ActivateTripleShot();
                        break;
                    case 1:
                        player.ActivateSpeedBoost();
                        break;
                    case 2:
                        Debug.Log("Sheild Collected");
                        break;

                }



              
                Destroy(this.gameObject);
            }
            
        }


    }



}
