using UnityEngine;
using System.Collections;

public class EnemyAttackRange : MonoBehaviour
{
    public float timeBetweenAttacks;
    public int attackDamage = 10;
    public AudioSource enemyAudio;
    [SerializeField] Transform trans;
    Animator anim;
    GameObject player;
    [SerializeField] GameObject attackPrefab;
    [SerializeField] GameObject axePrefab;
    [SerializeField] GameObject spitterPrefab;
    [SerializeField] GameObject spawnArea;
    [SerializeField] Transform spawnAreaPosition;
    [SerializeField] Transform[] spawnPos;
    [SerializeField] Transform[] throwPos;
    [SerializeField] Transform[] ultPos;
    [SerializeField] Transform spawnPosAcid;
    [SerializeField] float intervaloDeTiro;
    [SerializeField] float spawnProjectileCountTime;
    [SerializeField] GameObject enemy;

    PlayerHealth playerHealth;
    EnemyMovement movement;


    bool playerInAttackRange;
    public int spinOrientation;
    float timer;
    public AudioClip shootClip;
    public AudioClip deathClip;
    public AudioClip spawnClip;
    public AudioClip ultClip;
    [SerializeField] GameObject attackPos;

    float dis;
    [SerializeField] float attackRadius;
    [SerializeField] bool spitter;
    [SerializeField] GameObject energyEffect;
    float spawnTimer = 0;
    int rollCount = 10;
    SpinMe spin;

    Rigidbody2D enemyRigid;



    void Awake()
    {

        enemyAudio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();

    }

    void Start()
    {
        movement = enemy.GetComponent<EnemyMovement>();
        enemyRigid = enemy.GetComponent<Rigidbody2D>();
        timer = 2;
    }








    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine("AcidUlt");
        }



        AttackRange();

        timer += Time.deltaTime;
        if (spitter)
        {
            if (timer >= 50 && playerInAttackRange)
            {
                int number = Random.Range(0, 9);
                if (number > 0 && number < 5)
                {
                    InvokeRepeating("Shoot2", 0, intervaloDeTiro);
                    spawnTimer = 0;
                    timer = 0;
                    Invoke("CancelShoot2", intervaloDeTiro * spawnProjectileCountTime);
                }
                if (number == 0 || number == 6)
                {

                    StartCoroutine("Shoot3");
                    timer = 0;
                }
                if (number > 6)
                {
                    InvokeRepeating("Shoot", 0, intervaloDeTiro);
                    spawnTimer = 0;
                    timer = 0;
                    Invoke("CancelShoot", intervaloDeTiro * (spawnProjectileCountTime + 2));
                }
                if (number == 5)
                {
                    StartCoroutine("AcidUlt");
                    timer = 0;
                }


            }
        }

        else
        {
            if (timer >= timeBetweenAttacks && playerInAttackRange)
            {
                InvokeRepeating("Shoot2", 0, intervaloDeTiro);
                spawnTimer = 0;
                timer = 0;
                Invoke("CancelShoot2", intervaloDeTiro * spawnProjectileCountTime);
            }
        }







    }

    void CancelShoot2()
    {
        CancelInvoke("Shoot2");

    }
    void CancelShoot()
    {
        CancelInvoke("Shoot");
    }


    void AttackRange()
    {

        dis = Vector3.Distance(player.transform.position, transform.position);
        Vector3 pos = transform.position;
        if (dis <= attackRadius)
        {
            playerInAttackRange = true;
            //InvokeRepeating("Shoot", 1.5f,1.5f);
            //Instantiate(attackPrefab, attackPos.transform.position, trans.rotation);



        }
        else { playerInAttackRange = false; }

    }
    void Shoot()
    {

        int spawnPointIndex = Random.Range(0, throwPos.Length);

        timer = 0f;
        GameObject novoTiro = (GameObject)Instantiate(axePrefab, throwPos[spawnPointIndex].position, throwPos[spawnPointIndex].rotation);
        spin = novoTiro.GetComponent<SpinMe>();
        if (spawnPointIndex == 0)
        {
            spin.spinOrientation = -1;
        }
        if (spawnPointIndex == 1)
        {
            spin.spinOrientation = 1;
        }

        Destroy(novoTiro.gameObject, 8f);

    }

    
    IEnumerator AcidUlt()
    {
        enemyRigid.isKinematic = true;
        movement.isBossAttack = true;
        movement.maxSpeed = 0;
        enemy.GetComponent<Animator>().SetBool("Steady", true);
        energyEffect.SetActive(true);
        

        yield return new WaitForSeconds(3.75f);
        enemyAudio.PlayOneShot(ultClip, 1);
        energyEffect.SetActive(false);
        // flash image
        for (int y = 0; y < ultPos.Length; y++)
        {
            GameObject tiroPistol = (GameObject)Instantiate(spitterPrefab, ultPos[y].position, ultPos[y].rotation);
            Destroy(tiroPistol.gameObject, 5f);
        }

        yield return new WaitForSeconds(.5f);
        enemyRigid.isKinematic = false;
        enemy.GetComponent<Animator>().SetBool("Steady", false);
        movement.isBossAttack = false;
        movement.maxSpeed = movement.originalSpeed;


    }
    
    void Shoot2()
    {
        if (spitter)
        {
            enemyAudio.clip = shootClip;
            enemyAudio.Play();
            GameObject tiroPistol = (GameObject)Instantiate(spitterPrefab, spawnPosAcid.position, spawnPosAcid.rotation);
            Destroy(tiroPistol.gameObject, 5f);
        }
        else
        {
            enemyAudio.clip = shootClip;
            enemyAudio.Play();
            //anim.SetTrigger("Attack");
            for (int y = 0; y < spawnPos.Length; y++)
            {

                GameObject tiroPistol = (GameObject)Instantiate(attackPrefab, spawnPos[y].position, spawnPos[y].rotation);
                Destroy(tiroPistol.gameObject, 8f);


            }
        }
    }


    IEnumerator Shoot3()
    {
        enemyRigid.isKinematic = true;
        movement.isBossAttack = true;
        movement.maxSpeed = 0;
        enemy.GetComponent<Animator>().SetBool("Steady", true);
        enemyAudio.PlayOneShot(spawnClip, 1f);
        Instantiate(spawnArea, spawnAreaPosition.position, spawnAreaPosition.rotation);
        yield return new WaitForSeconds(2);
        enemyRigid.isKinematic = false;
        enemy.GetComponent<Animator>().SetBool("Steady", false);
        movement.isBossAttack = false;
        movement.maxSpeed = movement.originalSpeed;

    }

    void OnDrawGizmos()
    {
        // Draw attack sphere 
        Gizmos.color = new Color(255f, 0, 0, .5f);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(4f);
        }
    }

}
