using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using otutama;

public class score2text : MonoBehaviour
{
    [SerializeField]
    SaveDataInt score = default;

    // Start is called before the first frame update
    void Start()
    {
        score.Load();
        GetComponent<Text>().text = score.data.ToString();
    }
}
