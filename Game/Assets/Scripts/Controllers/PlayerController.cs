using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
    Actions actions;

    public bool LockActions = false;
    public float Speed = 5f;

    Map map;

    void Start()
    {
        map = Map.ins;
        actions = GetComponent<Actions>();
    }

    void Die()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0f;
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        float Speed_ = Speed / transform.localScale.x;
        Vector2 Dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Dir.x = Mathf.Clamp(Dir.x, map.MapLimits.x * -1 / 2, map.MapLimits.x / 2);
        Dir.y = Mathf.Clamp(Dir.y, map.MapLimits.y * -1 / 2, map.MapLimits.y / 2);
        
        transform.position = Vector2.MoveTowards(transform.position, Dir, Speed_ * Time.deltaTime);

        if (actions.GetMass() <= 0)
        {
            Die();
        }

        if (LockActions)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            actions.ThrowMass();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            actions.IncreaseMass();
        } 
    }
}
