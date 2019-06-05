using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerCharacter playerCharacter;
    CameraFollow playerCamera;
    PlayerHUD playerHUD;
    PlayerState playerState;
    public AudioClip gameOverClip;
    public ScroolRocker scroolRocker;
    int dieY = -30;

    void Awake()
    {
        playerCharacter = FindObjectOfType<PlayerCharacter>();
        playerCamera = FindObjectOfType<CameraFollow>();
        playerHUD = FindObjectOfType<PlayerHUD>();
        playerState = FindObjectOfType<PlayerState>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!playerState.getAlive())
        {
            return;
        }



        Vector3 directionVector3;
        switch (DeviceConfig.CUR_DEVICE)
        {
            default:
            case DeviceConfig.DEVICE_PC:
                {
                    float h = Input.GetAxis("Horizontal");
                    float v = Input.GetAxis("Vertical");
                    Transform cameraTransForm = playerCamera.transform;
                    directionVector3 = (cameraTransForm.forward * v + cameraTransForm.right * h).normalized;
                }
                break;
            case DeviceConfig.DEVICE_ANDROID:
                {
                    Transform cameraTransForm = playerCamera.transform;
                    directionVector3 = (scroolRocker.output.y * cameraTransForm.forward + scroolRocker.output.x * cameraTransForm.right).normalized;
                }
                break;

        }
        playerCharacter.Move(directionVector3);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (transform.position.y < dieY)
        {
            GameOver();
        }
    }

    public void AddCoin()
    {
        playerCharacter.AddCoin();
        playerHUD.UpdateCoinCount("硬币: " + playerCharacter.GetCoin().ToString());
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        AudioHelper.GetInstance().PlayGameOverClip(transform.position);
        playerHUD.ShowGameOverUI();
        playerState.setAlive(false);
    }

    public void ShowGamePassUI()
    {
        playerHUD.ShowGamePassUI();
    }

    public void Jump()
    {
        playerCharacter.Jump();
    }
}
