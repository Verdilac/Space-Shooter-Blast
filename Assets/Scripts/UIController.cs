using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] private Text _scoreText;
    [SerializeField] Player player;
    void Start()
    {
        _scoreText.text = "Score :";
        player = GameObject.Find("Player").GetComponent<Player>();


        if(player == null)
        {
            Debug.LogError("Referebce to the Player component failed ");
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        _scoreText.text = "Score :"+ player.getScore();

    }
}
