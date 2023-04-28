using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerSpawnPos;
    public Transform playerParent;

    public float moveSpeed;
    public int playerSpawnerHealth;

    public Joystick joystick;


    void Update()
    {
        Move();

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SpawnPlayer());
        }
    }

    private void Move()
    {
        float inputX = joystick.Horizontal;

        float xPos = Mathf.Clamp(transform.position.x + inputX * moveSpeed * Time.deltaTime, -6, 6);

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }



    IEnumerator SpawnPlayer()
    {
        Instantiate(player, playerSpawnPos.transform.position, Quaternion.identity, playerParent);
        yield return new WaitForSeconds(0.2f);
    }
}
