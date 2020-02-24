using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    [SerializeField]
    private Transform basePanel = default;

    public void Reverse ()
    {
        basePanel.Rotate(new Vector3(0f,0f,180f));
    }
}
