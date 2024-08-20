
using UnityEngine;

public class ColorsManager : MonoBehaviour
{
    public static ColorsManager ins;

    private void Awake(){
        if(ins == null){
            ins = this;
        }
    }

    public Color[] colors;

    public void GetRandomColor(SpriteRenderer sprite){
        int r = Random.Range(0, colors.Length);
        sprite.color = colors[r];
    }

    public void GetTargetColor(SpriteRenderer SourceColor, SpriteRenderer TargetColor){
        TargetColor.color = SourceColor.color;
    }
}
