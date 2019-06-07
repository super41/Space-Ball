using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHUD : MonoBehaviour
{

    public Text curCoinCount;
    public Text allCoinCount;

    public GameObject jumpIcon;
    public GameObject gameOverUI;
    public GameObject gamePassUI;

    public GameObject gamePassFinalUI;
    public GameObject rushSkillIcon;
    PlayerController controller;
    public Animator animStudyRush_1;
    public Animator animStudyRush_2;
    public Animator animStudyDoubleJump_1;
    public Animator animStudyDoubleJump_2;

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

    public void UpdateCurCoinCount(string s)
    {
        curCoinCount.text = s;
    }

    public void UpdateAllCoinCount(string s)
    {
        allCoinCount.text = s;
    }


    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void ShowGamePassUI()
    {
        gamePassUI.SetActive(true);
    }

    public void ShowGamePassFinalUI()
    {
        gamePassFinalUI.SetActive(true);
    }

    public void OnClik_Restar()
    {
        SceneManager.LoadScene(LevelConfig.CUR_LEVEL);
    }

    public void OnClick_NextLevel()
    {
        SceneManager.LoadScene(++LevelConfig.CUR_LEVEL);
    }

    public void OnClick_GoToLevel(int what)
    {
        LevelConfig.CUR_LEVEL = what;
        SceneManager.LoadScene(what);
    }

    public void OnClick_ExitGame()
    {
        Application.Quit();
    }


    public void OnClick_Jump()
    {
        controller.Jump();
    }

    public void OnClick_Rush()
    {
        controller.Rush();
    }

    public void ShowRushSkillIcon(bool isShow)
    {
        rushSkillIcon.SetActive(isShow);
    }

    public void UpdateJumpIcon(int level)
    {
        Debug.Log("jump level " + level);
        Image image = jumpIcon.GetComponent<Image>();
        string colorValue;
        switch (level)
        {
            default:
            case 1:
                colorValue = "#3E4A82";
                break;
            case 2:
                colorValue = "#DB845A";
                break;
        }
        Color newColor;
        // ColorUtility.TryParseHtmlString("#FECEE1", out newColor);
        ColorUtility.TryParseHtmlString(colorValue, out newColor);
        image.color = newColor;
    }

    public void ShowHintStudyRush()
    {
        StopCoroutine("ShowHintStudyRushIE");
        StartCoroutine("ShowHintStudyRushIE");
    }

    public void ShowHintStudyDoubleJumpSkill(){
        StopCoroutine("ShowHintStudyDoubleJumpIE");
        StartCoroutine("ShowHintStudyDoubleJumpIE");
    }

    private IEnumerator ShowHintStudyRushIE()
    {   
        animStudyRush_1.SetTrigger("study_rush_skill");
        yield return new WaitForSeconds(2);
        animStudyRush_2.SetTrigger("study_rush_skill");

    }

    private IEnumerator ShowHintStudyDoubleJumpIE(){
        animStudyDoubleJump_1.SetTrigger("study_rush_skill");
        yield return new WaitForSeconds(2);
        animStudyDoubleJump_2.SetTrigger("study_rush_skill");
    }


}
