using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using otutama;

public class RankingSender : MonoBehaviour
{
    [SerializeField]
    private SaveDataInt score = default;

    public void Start()
    {
        score.Load();
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score.data);
    }
}
