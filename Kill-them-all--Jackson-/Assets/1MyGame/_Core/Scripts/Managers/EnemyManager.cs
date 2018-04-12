using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public GameObject jogador;

   


    void Start ()
    {
        jogador = GameObject.FindGameObjectWithTag("Player");
        playerHealth = jogador.GetComponent<PlayerHealth>();
        //InvokeRepeating ("Spawn", spawnTime, spawnTime);
        Invoke("Spawn", spawnTime);
    }


    void Spawn ()
    {
        
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }
        
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
