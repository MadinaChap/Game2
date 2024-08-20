
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{

    public GameObject Virus;
    public int MaxViruses = 20;
    public List<GameObject> Viruses = new List<GameObject>();
    
    Map map;

    void Start(){
        map = Map.ins;
        InvokeRepeating("InstantiateVirus", 1, 0.2f);
    }

    void InstantiateVirus(){
        if(Viruses.Count >= MaxViruses){
            return;
        }
        Vector2 NewPos = new Vector2(Random.Range(map.MapLimits.x / 2 * -1, map.MapLimits.x / 2), Random.Range(map.MapLimits.y / 2 * -1, map.MapLimits.y / 2));
        GameObject NewVirus = Instantiate(Virus, NewPos, Quaternion.identity);
        Viruses.Add(NewVirus);
    }

    public void AddVirus(GameObject V){
        Viruses.Add(V);
    }

    public void RemoveVirus(GameObject V){
        Viruses.Remove(V);
    }
}
