using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    bool alive = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setAlive(bool alive)
    {
        this.alive = alive;
    }

    public bool getAlive(){
        return alive;
    }
}
