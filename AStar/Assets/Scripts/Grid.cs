using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{

    public int posX;
    public int posY;
    public bool isHinder;
    public Action OnClick;

    //����Ԥ��·����������ֵ
    public int G = 0;
    public int H = 0;
    public int All = 0;

    //��¼��Ѱ·�����иø��ӵĸ�����
    public Grid parentGrid;
    public void ChangeColor(Color color)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }

    //ί�а�ģ�����¼�
    private void OnMouseDown()
    {
        OnClick?.Invoke();
    }

}
