using UnityEngine;
using UnityEngine.AI;

public class PlayerAgents : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;   //editörden görülmesi için public verildi
    public float destroyTime = 0.2f;

    EnemySpawnerContainer container;
   
    void Start()
    {
        container = transform.parent.GetComponent<EnemySpawnerContainer>();
        target = container.enemySpawners[0].gameObject;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    { 
        Move(target.transform.position);
    }

    private void Move(Vector3 location)
    {
        agent.SetDestination(location);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject, destroyTime);
            Destroy(other.gameObject, destroyTime);
        }
        if (other.gameObject.CompareTag("EnemySpawner"))
        {
            Destroy(gameObject, destroyTime);
            target.GetComponent<EnemyManager>().enemySpawnerHealth--;

            if (target.GetComponent<EnemyManager>().enemySpawnerHealth == 0)
            {
                target.GetComponent<EnemyManager>().enemySpawnCount = 0;
                GameManager.instance.SetSuccessMenuState(true);
            }
        }
    }
}
