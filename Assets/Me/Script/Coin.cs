using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    PlayerController playerController;
    // Start is called before the first frame update

    
    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    void Start()
    {

    }

    // Update is called once per frame
  

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter playerCharacter = other.GetComponent<PlayerCharacter>();
        if (playerCharacter != null)
        {             
            AudioHelper.GetInstance().PlayGetCoinClip(transform.position);
            playerController.AddCoin();
            Destroy(gameObject);
        }
    }
}
