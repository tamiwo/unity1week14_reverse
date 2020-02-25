using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateManager : MonoBehaviour
{
    [SerializeField]
    private Transform basePanel = default;
    private Vector2 gravity;

    private bool isAnimation = false;

    private void Start ()
    {
        DOTween.Init();
        gravity = Physics2D.gravity;
    }

    public void Reverse ()
    {
        if( isAnimation ) return;
        isAnimation = true;
        
        basePanel.DOLocalRotate(new Vector3(0f,0f,-180f),0.5f)
            .SetRelative()
            .OnStart(()=>{
                Physics2D.gravity = Vector2.zero;
            })
            .OnComplete(()=>{
                Physics2D.gravity = gravity;
                isAnimation = false;
            });
    }
}
