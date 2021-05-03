using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float _speed = 4f;
    [SerializeField] public bool sethis = false;
    
    
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.41f)
        {
            float randomX = Random.Range(-8.70f, 8.70f);
            transform.position = new Vector3(randomX, 6.44f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Player player = other.transform.GetComponent<Player>();
            
            if (player != null)
            {
                Destroy(this.gameObject);
                player.Damage();
            }
      

        }

        
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
    
    public void ChangeSpeed(float speed)
    {
        _speed = speed;
    }


}
