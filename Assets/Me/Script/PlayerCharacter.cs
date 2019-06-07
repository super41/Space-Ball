using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    public int moveSpeed;
    public int jumpSpeed;

    public int rushSpeed;
    public float rushTime;
    //冲刺技能包括 向前冲击和下坠两个状态
    private bool isRushing = false;  //是否向前冲击
    private bool isCanRush = true;  // 直到下坠到接触到地板才能开启新一轮的rush
    private bool isCanJumpDouble = true;

    new Rigidbody rigidbody;

    private int coinCount = 0;

    public GameObject rushEffect;
    public GameObject doubleJumpEffect;

    private Quaternion initRushRotation;
    private Quaternion initDoubleJumpRotation;

    private Vector3  rushEffectOffest;
    private Vector3  doubleJumpEffectOffes;
    

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        initRushRotation = rushEffect.transform.rotation;
        initDoubleJumpRotation = doubleJumpEffect.transform.rotation;
        rushEffectOffest = transform.position - rushEffect.transform.position;
        doubleJumpEffectOffes = transform.position  - doubleJumpEffect.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //如果不能rush
        if (!isCanRush)
        {
            //检测是否在地板上，是的话CanRush = true
            if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
            {
                isCanRush = true;
            }
        }

        FixEffectPosition();

    }

  /**
    * 修正特效的位置
    */
    private void FixEffectPosition()
    {
        rushEffect.transform.rotation = initRushRotation;
        doubleJumpEffect.transform.rotation = initDoubleJumpRotation;
        rushEffect.transform.position = transform.position - rushEffectOffest;
        doubleJumpEffect.transform.position = transform.position - doubleJumpEffectOffes;
    }

    public void Move(Vector3 power)
    {
        if (!isRushing)
        {
            rigidbody.AddForce(power * moveSpeed, ForceMode.Force);
        }
    }

    public void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
        {            
            rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
            isCanJumpDouble = true;
        }else if(isCanJumpDouble && PlayerPrefsHelper.GetInstance().GetIsStudyDoubleJump()){
            isCanJumpDouble = false;
            rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
            isCanRush=true; //激活二段跳后，可以再rush一次 
            doubleJumpEffect.SetActive(true);
            StopCoroutine("HideDoubleJumpEffect");
            StartCoroutine("HideDoubleJumpEffect",0.5f);
        }
    }

    public void Rush()
    {
        //在空中才能Rush
        if (Physics.Raycast(transform.position, Vector3.down, 0.6f) || !isCanRush)
        {   
            Debug.Log("Rush return");
            return;
        }
        Debug.Log("Rushing");
        isRushing = true;
        isCanRush = false;
        rigidbody.useGravity = false;
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.AddForce(Vector3.forward * rushSpeed, ForceMode.Impulse);
        rushEffect.SetActive(true);
        StopCoroutine("RushEnd");
        StartCoroutine("RushEnd", rushTime);
    }

    public void AddCoin()
    {
        coinCount++;
        int allCoinCount = PlayerPrefsHelper.GetInstance().GetCoinCount();
        PlayerPrefsHelper.GetInstance().SetCoinCount(++allCoinCount);
    }
    public int GetCoin()
    {
        return coinCount;
    }


    private IEnumerator RushEnd(float rushTime)
    {
        yield return new WaitForSeconds(rushTime);   
        rushEffect.SetActive(false);     
        rigidbody.useGravity = true;
        isRushing = false;
    }

    private IEnumerator HideDoubleJumpEffect(float time){
        yield return new WaitForSeconds(time);
        doubleJumpEffect.SetActive(false);
    }



}
