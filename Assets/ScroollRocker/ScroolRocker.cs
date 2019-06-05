using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScroolRocker : ScrollRect
{
    private float raduis;
    public Vector3 output;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private bool isPress;
    void Start()
    {
        raduis = (transform as RectTransform).sizeDelta.x * 0.5f;
    }

    public override void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnDrag(eventData);

        if (content.anchoredPosition.magnitude > raduis)
        {
            SetContentAnchoredPosition(content.anchoredPosition.normalized * raduis);
        }
    }

    private void Update()
    {
        if (isPress)
        {
            output = content.localPosition / raduis;
        }
        else
        {
            output = Vector3.zero;
        }

    }

    public override void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {   
        base.OnEndDrag(eventData);
        isPress = false;
        Debug.Log("EndDrag----------");
    }

    public override void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {   
        base.OnBeginDrag(eventData);
        isPress = true;
         Debug.Log("BeginDrag+++++++++++++");
         Debug.Log("5 " +f(5));
         Debug.Log("6 "+f(6));
         Debug.Log("7 "+f(7));
    }

    private  int f(int n){
        if(n ==1 || n == 2){
            return 1;
        }else{
            return f(n -1)+ f(n-2);
        }
    }
}


