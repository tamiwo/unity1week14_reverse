using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateManager : MonoBehaviour
{
    [SerializeField]
    private Transform basePanel = default;
    private float[] angles = {0,-180};
    private int index = 0;
    private Vector2 gravity;

    private bool isAnimation = false;
    private Tween rotate;

    private void Start ()
    {
        gravity = Physics2D.gravity;
    }

    public void Reverse ()
    {
        if( isAnimation ) return;
        isAnimation = true;
        
        rotate = basePanel.DOLocalRotate(new Vector3(0f,0f,angles[index]),0.5f)
            .OnStart(()=>{
                Physics2D.gravity = Vector2.zero;
            })
            .OnComplete(()=>{
                Physics2D.gravity = gravity;
                isAnimation = false;
                index = (index + 1)%2;
            });
    }
}
