using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] //�������� ����� ���� ���
public class Stage_Data : ScriptableObject
{
    [SerializeField] private Vector2 limitMin;
    [SerializeField] private Vector2 limitMax;

    //public Vector2 LimitMin => limitMin;
    //public Vector2 LimitMax => limitMax;
    public Vector2 LimitMin
    {
        get
        {
            return limitMin;
        }
    }
    public Vector2 LimitMax
    {
        get
        {
            return limitMax;
        }
    }
}
