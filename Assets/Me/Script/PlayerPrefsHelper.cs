using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsHelper
{

    public static Object SINGLE_LOCK = new Object();
    private static PlayerPrefsHelper INSTANCE = null;

    private PlayerPrefsHelper()
    {

    }

    public static PlayerPrefsHelper GetInstance()
    {
        if (INSTANCE == null)
        {
            lock (SINGLE_LOCK)
            {
                if (INSTANCE == null)
                {
                    INSTANCE = new PlayerPrefsHelper();
                }
            }
        }
        return INSTANCE;
    }

    string KEY_COIN_COUNT = "KEY_COIN_COUNT";
    string KEY_STUDY_RUSH = "KEY_STUDY_RUSH";
    
    string KEY_JUMP_LEVEL = "KEY_JUMP_LEVEL";

    int HAS_STUDY = 1;
    int NO_STUDY = 0;

    int JUMP_LEVEL_1  = 1;
    int JUMP_LEVEL_2 = 2;

    int DEF_COIN_COUNT = 0;
    public void SetStudyRunSkill(bool study)
    {
        PlayerPrefs.SetInt(KEY_STUDY_RUSH, study ? HAS_STUDY : NO_STUDY);
    }

    public bool GetIsStudyRushSkill()
    {
        int isStudy = PlayerPrefs.GetInt(KEY_STUDY_RUSH, NO_STUDY);
        return (isStudy == HAS_STUDY);
    }

    public void SetStudyDoubleJump(bool study)
    {
        PlayerPrefs.SetInt(KEY_JUMP_LEVEL, study ? JUMP_LEVEL_2 : JUMP_LEVEL_1);
    }
    public bool GetIsStudyDoubleJump()
    {
        return PlayerPrefs.GetInt(KEY_JUMP_LEVEL,JUMP_LEVEL_1) == JUMP_LEVEL_2;
    }

    public int GetJumpLevel(){
         return PlayerPrefs.GetInt(KEY_JUMP_LEVEL,JUMP_LEVEL_1);
    }

    public void SetCoinCount(int count)
    {
        PlayerPrefs.SetInt(KEY_COIN_COUNT, count);
    }
    public int GetCoinCount()
    {
        return PlayerPrefs.GetInt(KEY_COIN_COUNT, DEF_COIN_COUNT);
    }

}
