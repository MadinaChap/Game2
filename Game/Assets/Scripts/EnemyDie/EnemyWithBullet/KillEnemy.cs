
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public int health;
    public float speed;
    public Transform player;

    private void Update(){
        if(health <= 0){
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }  

    public void TakeDamage(int damage){
        health -= damage;
        if(health > 0){
            float PlayerMass = player.localScale.x * player.localScale.y * player.localScale.z;
            float newScale = PlayerMass - PlayerMass/health + 0.3f;
            transform.localScale = new Vector3(newScale, newScale, newScale);
        }
        else{
            Destroy(gameObject);
        }
    }
}
