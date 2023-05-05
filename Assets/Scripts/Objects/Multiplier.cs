using System.Collections;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    public int multiplierCount;
    public GameObject player;
    public GameObject enemy;


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SpawnObject(player,other.gameObject.transform));
        }
        //else if (other.gameObject.CompareTag("Enemy"))
        //{
        //    StartCoroutine(SpawnObject(enemy));
        //}
    }

    IEnumerator SpawnObject(GameObject spawnObject,Transform colliderObject)
    {
        for (int i = 0; i < multiplierCount; i++)
        {
            Instantiate(spawnObject, transform.position, Quaternion.identity,colliderObject.parent);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
