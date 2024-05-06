using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class GridMeshCreate : MonoBehaviour 
{
    [Serializable]
    public class MeshRange
    {
        public int horizontal;
        public int vertical;
    }
    [Header("�����ͼ��Χ")]
    public MeshRange meshRange;
    [Header("�����ͼ��ʼ��")]
    private Vector3 startPos;
    [Header("������ͼ���񸸽ڵ�")]
    public Transform parentTran;
    [Header("�����ͼģ��Ԥ����")]
    public GameObject gridPre;
    [Header("�����ͼģ���С")]
    public Vector2 scale;


    private GameObject[,] m_grids;
    public GameObject[,] grids
    {
        get
        {
            return m_grids;
        }
    }
    //ע��ģ���¼�
    public Action<GameObject, int, int> gridEvent;

    /// <summary>
    /// ���ڹ�������ĳ�ʼ���ݴ�������
    /// </summary>
    public void CreateMesh()
    {
        if (meshRange.horizontal == 0 || meshRange.vertical == 0)
        {
            return;
        }
        ClearMesh();
        m_grids = new GameObject[meshRange.horizontal, meshRange.vertical];
        for (int i = 0; i < meshRange.horizontal; i++)
        {
            for (int j = 0; j < meshRange.vertical; j++)
            {
                CreateGrid(i, j);

            }
        }
    }

    /// <summary>
    /// ���أ����ڴ�������������������
    /// </summary>
    /// <param name="height"></param>
    /// <param name="widght"></param>
    public void CreateMesh(int height, int widght)
    {
        if (widght == 0 || height == 0)
        {
            return;
        }
        ClearMesh();
        m_grids = new GameObject[widght, height];
        for (int i = 0; i < widght; i++)
        {
            for (int j = 0; j < height; j++)
            {
                CreateGrid(i, j);

            }
        }
    }

    /// <summary>
    /// ����λ�ô���һ��������Grid����
    /// </summary>
    /// <param name="row">x������</param>
    /// <param name="column">y������</param>
    public void CreateGrid(int row, int column)
    {
        GameObject go = GameObject.Instantiate(gridPre, parentTran);
        //T grid = go.GetComponent<T>();

        float posX = startPos.x + scale.x * row;
        float posZ = startPos.z + scale.y * column;
        go.transform.position = new Vector3(posX, startPos.y, posZ);
        m_grids[row, column] = go;
        gridEvent?.Invoke(go, row, column);
        Vector3.Distance(new Vector3(0, 0, 0), transform.position);
    }





    /// <summary>
    /// ɾ�������ͼ���������������
    /// </summary>
    public void ClearMesh()
    {
        if (m_grids == null || m_grids.Length == 0)
        {
            return;
        }
        foreach (GameObject go in m_grids)
        {
            if (go != null)
            {
                Destroy(go);
            }
        }
        Array.Clear(m_grids, 0, m_grids.Length);
    }

}