using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnamy : MonoBehaviour
{
    public GameObject enemy;
    private int xPos;
    private int zPos; 
    public int yPos;
    private int enemyCount;
    public int howMany;

    private void Start()
    {
        StartCoroutine(EnemyDrop());
    }
    IEnumerator EnemyDrop()
    {
        while (enemyCount < howMany) 
        { 
            xPos = Random.Range(1,31);
            zPos = Random.Range(1,31);
            Instantiate(enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}

