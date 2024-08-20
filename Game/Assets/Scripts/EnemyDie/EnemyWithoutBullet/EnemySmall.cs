
using UnityEngine;

public class EnemySmall : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Actions actions = collider.GetComponent<Actions>();
            if (actions != null)
            {
                actions.EnemyDecreaseMass();
            }
        }
    }

    public void TakeDamage(int damage){
        health -= damage;
        if(health > 0){
            float PlayerMass = player.localScale.x * player.localScale.y * player.localScale.z;
            float newScale = PlayerMass - PlayerMass/health + 0.2f;
            transform.localScale = new Vector3(newScale, newScale, newScale);
        }
        else{
            Destroy(gameObject);
        }
    }
}
