using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    private int sec = 0;
    private int min = 0;
    public TextMeshProUGUI Score;
    [SerializeField] private int delta = 1; // Set delta to 1 for a standard timer

    private void Start() // Corrected method name
    {
        StartCoroutine(ITimer());
    }

    IEnumerator ITimer()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = 0; // Reset sec to 0 instead of -1
            }
            else
            {
                sec += delta; // Increment sec by delta
            }
            Score.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
}
