using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float range;
    public float waitSec;
    public GameObject zombieHitbox;
    public GameObject zombie;
    private float waitTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
    }
    

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameObject.Find(collider.gameObject.name).GetComponent<Player>().TakeDamage(20);
            StartCoroutine(WaitToAttack());
        }
    }

    public IEnumerator WaitToAttack()
    {
        zombieHitbox.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitSec);
        zombieHitbox.gameObject.SetActive(true);
    }
}
