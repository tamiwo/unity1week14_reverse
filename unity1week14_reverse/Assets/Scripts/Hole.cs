using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Hole : MonoBehaviour
{

    [SerializeField,Tag]
    private string targetTag = default;
    [SerializeField]
    private UnityEvent onCupIn = new UnityEvent();

    void OnTriggerEnter2D ( Collider2D col )
    {
        //Debug.Log("collision:"+col.name + col.tag);
        if ( col.tag != targetTag) return;
        col.tag = "Untagged";

        Physics2D.gravity = Vector2.zero;
        col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        var tf = col.transform;
        

        Sequence seq = DOTween.Sequence();
        seq.Append(tf.DOLocalMove(Vector3.zero,1.0f));
        seq.Join(tf.DOLocalRotate(new Vector3(0,0,1080),3f).SetRelative());
        seq.Join(tf.DOScale(new Vector3(0,0,0),2f).OnComplete(()=>{
            Destroy(col.gameObject);
            onCupIn.Invoke();
        }));
    }
}
