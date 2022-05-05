using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using DG.Tweening; 

public class MenuList : MonoBehaviour
{
    private bool Out;  
    Transform mTransform;

    float shade = 170; 
    float shadeTime = 2;
    float mask = 30;  
    float maskTime = 0.3f; 
    float flipTime = 0.3f; 
    void Start()
    {
        Out = true;
        mTransform = GameObject.FindWithTag("menu").GetComponent<Transform>();
    }

    public void ButtonPressed()
    {
        Sequence sequence = DOTween.Sequence(); 
       if(Out == true)
        {
            sequence.Append(mTransform.DOMoveX(mTransform.position.x - shade, shadeTime)).Join(transform.DOMoveX(transform.position.x - shade, shadeTime))
                .Append(mTransform.DOMoveX(mTransform.position.x - shade - mask, maskTime)).Append(transform.DOScale(-1, flipTime));

            Out = false; 
        }
        else
        {
            sequence.Append(mTransform.DOMoveX(mTransform.position.x + mask, maskTime))
                .Append(mTransform.DOMoveX(mTransform.position.x + mask + shade, shadeTime))
                .Join(transform.DOMoveX(transform.position.x + shade, shadeTime))
                .Append(transform.DOScaleX(1, flipTime));

            Out = true; 
        }

    }
}
