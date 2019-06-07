using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCoin : MonoBehaviour
{
    PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter character = other.GetComponent<PlayerCharacter>();
        if (character != null)
        {
            AudioHelper.GetInstance().PlayGameOverClip(transform.position);
            if (LevelConfig.CUR_LEVEL == LevelConfig.FINAL_LEVEL)
            {
                controller.ShowGamePassFinalUI();
            }
            else
            {
                controller.ShowGamePassUI();
            }
        }
    }
}
