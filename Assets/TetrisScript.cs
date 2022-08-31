using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisScript : MonoBehaviour
{
    private int[][] matrix = new int[3][];
    public GameObject squarePrefabVar;

    void Start()
    {
        matrix[0] = new int[3] { 0, 0, 1 };
        matrix[1] = new int[3] { 1, 1, 1 };
        matrix[2] = new int[3] { 1, 0, 0 };

        StartCoroutine(SpawnCoroutine());

    }

    IEnumerator SpawnCoroutine()
    {
        SpawnFigure(matrix);
        yield return new WaitForSeconds(1);
        int[][] newMatrix = TurnFigure(matrix);
        SpawnFigure(newMatrix);
    }

    void SpawnFigure(int[][] matrix)
    {
        squarePrefabVar.transform.position = new Vector3(0, 0, 0);
        GameObject oldSquarePrefabVar = squarePrefabVar;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (matrix[i][j] == 1)
                {
                     Instantiate(squarePrefabVar);
                }
                // отступ в форме квадрата в право.
                squarePrefabVar.transform.position = oldSquarePrefabVar.transform.position + Vector3.right;
            }
            // отступ в формате квадрата вниз
            squarePrefabVar.transform.position = new Vector3(0, 0, 0);
            squarePrefabVar.transform.position = oldSquarePrefabVar.transform.position + new Vector3(0, -i - 1, 0);
        }

        oldSquarePrefabVar = null;
    }
    int[][] TurnFigure(int[][] matrix)
    {   
        int[][] turnedMatrix = new int[3][];

        for (int i = 0; i < 3; i++)
        {
            turnedMatrix[i] = new int[3] { 0, 0, 0 };
            for (int j = 0; j < 3; j++)
            {
                turnedMatrix[i][j] = matrix[j][3 - i - 1];
            }
        }

        return (turnedMatrix);
    }
}
