
using UnityEngine;

public class Gan : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;

    private float timeBTWShots;
    public float startTimeBTWShots;

    Actions actions;

    void Start(){
        actions = GetComponent<Actions>();
    }
    void Update(){
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if(timeBTWShots <= 0){
            if(Input.GetMouseButton(0) ){
                actions.DecreaseMass();
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timeBTWShots = startTimeBTWShots;
            }
        }
        else{
            timeBTWShots -= Time.deltaTime;
        }
    }

}
