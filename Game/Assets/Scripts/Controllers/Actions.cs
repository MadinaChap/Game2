
using UnityEngine;

public class Actions : MonoBehaviour
{
    public GameObject Mass;
    public Transform MassPosition;

    public float Percentage = 0.01f;


    public void ThrowMass()
    {
        if(transform.localScale .x < 1)
        {
            return;
        }
        
        Vector2 Direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float Z_Rotation = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0, 0, Z_Rotation);

        GameObject b = Instantiate(Mass, MassPosition.position, Quaternion.identity);

        b.GetComponent<MassForce>().ApplyForce = true;

        ColorsManager.ins.GetTargetColor(GetComponent<SpriteRenderer>(), b.GetComponent<SpriteRenderer>());

        ms.AddMass(b);

        transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
    }

    public void IncreaseMass()
    {
        transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
    }

    public void DecreaseMass(){
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void EnemyDecreaseMass(){
        transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
    }
    public void EnemyKillMass(){
        transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f);
    }

    public float GetMass(){
        return transform.localScale.x;
    }

    PlayerEatMass mass_script;
    MassSpawner ms;
    void Start()
    {
        mass_script = GetComponent<PlayerEatMass>();
        ms = MassSpawner.ins;

        ColorsManager.ins.GetRandomColor(GetComponent<SpriteRenderer>());
    }

    void Update()
    {
        if(transform.localScale.x < 1)
        {
            return;
        }
        transform.localScale -= new Vector3(Percentage, Percentage, Percentage) * Time.deltaTime;
    }

}
