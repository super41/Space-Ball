using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHUD : MonoBehaviour
{

    public Text coinCount;
    public GameObject gameOverUI;
    public GameObject gamePassUI;
    PlayerController controller;
  
    void Awake()
    {
        controller = FindObjectOfType<PlayerController>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateCoinCount(string s)
    {
        coinCount.text = s;
    }

    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void ShowGamePassUI()
    {
        gamePassUI.SetActive(true);
    }

    public void OnClik_Restar()
    {
        SceneManager.LoadScene(LevelConfig.Level_Name_1);
    }

    public void OnClick_NextLevel()
    {
        SceneManager.LoadScene(LevelConfig.Level_Name_1);
    }

    public void OnClick_Jump(){
        controller.Jump();
    }
}
