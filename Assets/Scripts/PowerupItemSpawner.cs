using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupItemSpawner : MonoBehaviour
{
    public List<GameObject> powerupItemList;

    //[SerializeField] private float startDelay = 6;

    private float maxItems = 1;

    private BoxCollider2D boxCollider;

     private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        //StartCoroutine(SpawnItemWithDelay(startDelay));
    }

    public IEnumerator SpawnItemWithDelay(float startDelay)
    {
        yield return new WaitForSeconds(startDelay);
        float minX = boxCollider.bounds.min.x;
        float maxX = boxCollider.bounds.max.x;
        
        for (int i = 0; i < maxItems; i++)
        {
            Vector3 spawnPoint = new Vector3(Random.Range(minX, maxX), transform.position.y, 0);
            Instantiate(powerupItemList[Random.Range(0, powerupItemList.Count)].gameObject, spawnPoint, Quaternion.identity);
        }
    }
}
