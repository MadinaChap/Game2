
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;



    private void Update(){
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null){
            if(hitInfo.collider.CompareTag("Enemy")){
                hitInfo.collider.GetComponent<EnemySmall>().TakeDamage(damage);
            }else if (hitInfo.collider.CompareTag("Enemy2")){
                hitInfo.collider.GetComponent<KillEnemy>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    
}
