using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletType;
    [SerializeField] private float shootSpeed = 1;
    [SerializeField] private float maxDegree;
    [SerializeField] private float range = 1;
    [SerializeField] private bool doIHaveToSeePlayer = true;
    private float bulletSpeed;
    private Vector2 direction;
    private bool isInRange;

    private Vector3 startingUp;
    private CircleCollider2D viewCircle;
    private bool canISeeThePlayer;
    private Coroutine MyCorutine;
    private bool isCorutineRunning;

    private void Start()
    {
        maxDegree = (maxDegree / 180);
        startingUp = transform.up;
        bulletSpeed = bulletType.GetComponent<BulletScript>().BulletSpeed;
        viewCircle = gameObject.GetComponent<CircleCollider2D>();
        viewCircle.radius = range;
        canISeeThePlayer = !doIHaveToSeePlayer;
    }

    private void Update()
    {
        Rotation();
        if (doIHaveToSeePlayer)
        {
            canISeeThePlayer = CheckTheWay();
        }

    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            MyCorutine = StartCoroutine(Shoot());
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isCorutineRunning)
        {
            MyCorutine = StartCoroutine(Shoot());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            if (isCorutineRunning)
            {
                StopCoroutine(MyCorutine);
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        
        Gizmos.DrawWireSphere(transform.position, range * transform.localScale.x);
        Gizmos.color = Color.white;
    }

    private IEnumerator Shoot()
    {
        isCorutineRunning = true;
        
        if (canISeeThePlayer && isInRange)
        {
            yield return new WaitForSeconds(1 / shootSpeed);
            var dropPos = gameObject.transform.Find("ShootPoint");
            var bullet = Instantiate(bulletType, dropPos.position, Quaternion.identity);
            var shootPoint = new Vector2(dropPos.position.x - transform.position.x, dropPos.position.y - transform.position.y);
            bullet.transform.up = shootPoint;
            bullet.transform.rotation = gameObject.transform.rotation;
            bullet.GetComponent<Rigidbody2D>().velocity = shootPoint.normalized * bulletSpeed;
        }

        isCorutineRunning = false;
    }

    private bool CheckTheWay()
    {
        var dropPos = gameObject.transform.Find("ShootPoint");
        var playerPos = GameObject.FindWithTag("Player").transform.position;
        direction = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);
        var hit = Physics2D.Raycast(dropPos.position, direction, range);
        try
        { 
            return hit.collider.CompareTag("Player");
        }
        catch
        {
            // ignored
        }

        return false;
    }

    private void Rotation()
    {
        if (canISeeThePlayer)
        {
            var playerPos = GameObject.FindWithTag("Player").transform.position;
            direction = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);
            if (Math.Abs(startingUp.x - direction.x) < maxDegree && Math.Abs(startingUp.y - direction.y) < maxDegree) transform.up = direction;
        }
    }
}