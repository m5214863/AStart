using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRun : MonoBehaviour
{
    //��ȡ���񴴽��ű�
    public GridMeshCreate gridMeshCreate;
    //��������Ԫ��grid���ϰ��ĸ���
    [Range(0,1)]
    public float probability;


    bool isCreateMap=false;


    int clickNum=0;

    Grid startGrid;
    Grid endGrid;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Run();
            isCreateMap = false;
            clickNum = 0;

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AStarLookRode aStarLookRode = new AStarLookRode();
            aStarLookRode.Init(gridMeshCreate,startGrid,endGrid);
            StartCoroutine(aStarLookRode.OnStart());
            

        }


    }
    private void Run()
    {
        
        gridMeshCreate.gridEvent = GridEvent;
        gridMeshCreate.CreateMesh();
    }

    /// <summary>
    /// ����gridʱִ�еķ�����ͨ��ί�д���
    /// </summary>
    /// <param name="grid"></param>
    private void GridEvent(GameObject go,int row,int column)
    {
        //�������������Ԫ���Ƿ�Ϊ�ϰ�
        Grid grid = go.GetComponent<Grid>();
        float f = Random.Range(0, 1.0f);
        Color color = f <= probability ? Color.red : Color.white;
        grid.ChangeColor(color);
        grid.isHinder = f <= probability;
        grid.posX = row;
        grid.posY = column;
        //ģ��Ԫ�ص���¼�
        grid.OnClick = () => {
            if (grid.isHinder)
                return;

            clickNum++;

            Debug.Log(grid.posX);
            Debug.Log("�Ƿ�Ϊ�ϰ�"+grid.isHinder.ToString());
            switch (clickNum)
            {
                case 1:
                    startGrid = grid;
                    grid.ChangeColor(Color.yellow);
                    break;
                case 2:
                    endGrid = grid;
                    grid.ChangeColor(Color.yellow);
                    isCreateMap = true;
                    break;
                default:
                    break;
            }

        };

    }
}
