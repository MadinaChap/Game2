using System.Runtime.InteropServices;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    float speed = 3f;
    float activationRadius = 5f;
    PlayerMovements player;

    void Start(){
        player = FindObjectOfType<PlayerMovements>();
    }

    void FixedUpdate(){
        if (IsPlayerInRange()) {
            FollowPlayer();
        }
    }

    bool IsPlayerInRange(){
        if(player != null){
            float distance = Vector2.Distance(transform.position, player.transform.position);
            return distance <= activationRadius;
        }
        return false;
    }

    void FollowPlayer(){
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        if (Vector2.Distance(transform.position, player.transform.position) < 0.1f) {
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Transform playerTransform = other.transform;
            playerTransform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
            Die();
        }
    }
}
