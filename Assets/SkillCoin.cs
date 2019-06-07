using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCoin : MonoBehaviour

{
    public int SKILL_WHAT = 0;
    public const int SKILL_RUSH = 1;
    public const int SKILL_JUMP_DOUBLE = 2;
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
        if (character)
        {
            AudioHelper.GetInstance().PlayGetCoinClip(transform.position);
            switch (SKILL_WHAT)
            {
                case SKILL_RUSH:
                    controller.StudyRushSkill();
                    controller.UpdateSkillIcon();
                    controller.ShowHintStudyRushSkill();
                    break;
                case SKILL_JUMP_DOUBLE:
                    controller.StudyDoubleJumpSkill();
                    controller.UpdateSkillIcon();
                    controller.ShowHintStudyDoubleJumpSkill();
                    break;
            }
            Destroy(gameObject);
        }
    }
}
