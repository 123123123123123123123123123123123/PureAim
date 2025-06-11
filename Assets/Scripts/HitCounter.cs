using TMPro;
using UnityEngine;

public class HitCounter : MonoBehaviour
{
    public static HitCounter instance;
    public TextMeshProUGUI hitCountTMP;

    private int hits = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddHit()
    {
        hits++;
        UpdateText();
    }

    public int GetHits()
    {
        return hits;
    }

    public void ResetHits()
    {
        hits = 0;
        UpdateText();
    }

    private void UpdateText()
    {
        hitCountTMP.text = "Hits: " + hits;
    }

    private void Update()
    {
        UpdateText();
    }
    public int GetHitCount()
    {
        return hits;
    }

}
