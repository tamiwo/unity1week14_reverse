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

        col.transform.SetParent(transform,false);

        var rb = col.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
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
