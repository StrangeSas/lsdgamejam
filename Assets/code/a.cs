
using UnityEngine;
using UnityEngine.AI;

public class a : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GunData gunData;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletForce;

    [SerializeField] AudioSource weaponShoot;
    [SerializeField] AudioSource reloadingSound;
    [SerializeField] AudioClip kickerSound;
    [SerializeField] AudioClip emptyClick;

    [SerializeField] GameObject[] squadron;

    [SerializeField] Animator _weaponAnimator;

    [SerializeField] Animator _characterAnimator;
    string _currentState;
    const string SHOOT = "shooting";
    const string IDLE = "standing";
    const string START_RUNNING = "start_run";
    const string RUN = "run";
    const string STOP_RUNNING = "stop_running";
    const string AIMING = "aiming";
    const string DOWN_WEAPON = "start_running";

    [SerializeField] float grafityForce;
    [SerializeField] float bulletLifeTime;
    public NavMeshAgent agent;

    public Transform player;
    public Transform gunMuzzle;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject bulletPrefab;


    bool aiming = false;
    bool runing = false;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    private void Awake()
    {
        GameObject player = new GameObject();
        player = GameObject.Find("SoldierPlayer");
        agent = GetComponent<NavMeshAgent>();
        _weaponAnimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

 
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);
        if (runing)
        {
            ChangeWeaponAnimationState(STOP_RUNNING);
        }

        if(runing == false && aiming == false)
        {

            ChangeWeaponAnimationState(IDLE);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        if (runing == false)
        {
            ChangeWeaponAnimationState(START_RUNNING);
        }
        else 
        {
            ChangeWeaponAnimationState(RUN);
        }
    }
    public void ChangeWeaponAnimationState(string newState)
    {
        _weaponAnimator.Play(newState);
    }
    public void ChangeBodyAnimationState(string newState)
    {
        _weaponAnimator.Play(newState);
    }
    private void OnGunShoot()
    {

        GameObject currentBullet = Instantiate(bulletPrefab, gunMuzzle.position, Quaternion.identity);

        Bullet bulletScript = currentBullet.GetComponent<Bullet>();
        if (bulletScript)
        {

            ChangeWeaponAnimationState(SHOOT);
            bulletScript.Initialize(gunMuzzle.transform, bulletSpeed, grafityForce);

        }


        AudioSource currentStuff = Instantiate(weaponShoot, gunMuzzle.position, Quaternion.identity);

        Destroy(currentBullet, bulletLifeTime);
        Destroy(bulletScript, bulletLifeTime);
        Destroy(currentStuff, bulletLifeTime);
        Destroy(currentStuff.gameObject, bulletLifeTime);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        if (runing)
        {

            ChangeWeaponAnimationState(STOP_RUNNING);
        }
        if (!alreadyAttacked)
        {
            ///Attack code here
            if (runing == true) 
            {

                ChangeWeaponAnimationState(STOP_RUNNING);

            }
            else if(aiming == false)
            {

                ChangeWeaponAnimationState(AIMING);
            }
            else
            {
                OnGunShoot();
            }
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public void EnemyStartedRunning()
    {
        runing = true;

    }
    public void EnemyStoptedRunning()
    {
        runing = false;

    }
    public void EnemyStartedAimining()
    {
        aiming = true;

    }
    public void EnemyStoptedAimining()
    {
        aiming = false;

    }

}
