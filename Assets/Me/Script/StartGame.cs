using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject helpDeatil;

    public void OnClick_Start(){
        LevelConfig.CUR_LEVEL = 1;
        SceneManager.LoadScene(LevelConfig.CUR_LEVEL);        
    }
    public void OnClick_Reset(){
        PlayerPrefs.DeleteAll();
    }

    public void OnClick_HelpDetail(){
        helpDeatil.SetActive(true);
    }

    public void OnClick_ExitHelp(){
         helpDeatil.SetActive(false);
    }
}
