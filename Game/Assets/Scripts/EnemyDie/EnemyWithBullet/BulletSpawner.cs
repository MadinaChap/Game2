
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]

    GameObject bullet;

    [SerializeField]
    public float activationRadius = 20f;

    float fireRate;
    float nextFire;
    PlayerMovements player;

    void Start(){
        fireRate = 2f;
        nextFire = Time.time;
        player = FindObjectOfType<PlayerMovements>();
    }

    void Update(){
        if(IsPalyerInRange()){
            CheakifTimeToFire();
        }
    }

    void CheakifTimeToFire(){
        if(Time.time > nextFire){
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    bool IsPalyerInRange(){
        if(player != null){
            float distance = Vector2.Distance(transform.position, player.transform.position);
            return distance <= activationRadius;
        }
        return false;
    }
}
