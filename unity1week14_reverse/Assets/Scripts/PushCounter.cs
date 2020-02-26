using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using otutama;

public class PushCounter : MonoBehaviour
{
    [SerializeField]
    private SaveDataInt _totalCount = default;

    private int _count = 0;
    private int count
    {
        get{
            return _count;
        }
        set{
            _count = value;
            countText.text = value.ToString();
        }
    }
    private int totalCount
    {
        get{
            return _totalCount.data;
        }
        set{
            _totalCount.data = value;
            totalCountText.text = value.ToString();
        }
    }
    [SerializeField]
    private Text totalCountText = default;
    [SerializeField]
    private Text countText = default;

    public void CountUp()
    {
        count++;
        totalCount++;
    }
}

