using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
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
                player.ActivateTripleShot();
                Destroy(this.gameObject);
            }
            
        }


    }



}
