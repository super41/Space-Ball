using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    public int moveSpeed;
    public int jumpSpeed;

    new Rigidbody rigidbody;

    private int coniCount = 0;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector3 power)
    {
        rigidbody.AddForce(power * moveSpeed, ForceMode.Force);
    }

    public void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
        {
            rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    public void AddCoin()
    {
        coniCount++;
    }
    public int GetCoin(){
        return coniCount;
    }

  

}
