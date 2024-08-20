
using TMPro;
using UnityEngine;


public class PlayerScore : MonoBehaviour
{
    public TextMeshProUGUI Score;

    public float ScoreEditor = 100;

    private void Start(){
        InvokeRepeating("UpdateScore", 1, 1);
    }

    void UpdateScore(){
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

        float _score = 0f;

        for(int i = 0; i < player.Length; i++){
            _score += player[i].transform.localScale.x * ScoreEditor;
        }

        Score.text = _score.ToString("f0");
    }
}
