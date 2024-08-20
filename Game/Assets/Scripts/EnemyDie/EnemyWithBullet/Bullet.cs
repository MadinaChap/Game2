using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float moveSpeed = 7f;
    
    Rigidbody2D rb;
    PlayerMovements target;
    Actions playerActions;  
    Vector2 moveDirection; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerMovements>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerActions = other.GetComponent<Actions>();  
            
            if (playerActions != null) 
            {
                playerActions.EnemyKillMass();  
            }

            Destroy(gameObject);
        }
    }
}
