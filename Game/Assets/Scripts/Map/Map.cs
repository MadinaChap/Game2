
using UnityEngine;

public class Map : MonoBehaviour
{
    #region Instance
    public static Map ins;

    private void Awake(){
        if(ins == null){
            ins = this;
        }
    }
    #endregion

    public Vector2 MapLimits;
    public Color Maplimits_Color;

    private void OnDrawGizmos(){
        Gizmos.color = Maplimits_Color;
        Gizmos.DrawWireCube(transform.position, MapLimits);
    }
}
