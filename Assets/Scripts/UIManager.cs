using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject HealForeground;
    public TMPro.TMP_Text EnemyCount;

    private static int currentWaveKills = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // update player hp
        float ratio = GameManager.instance.hero.health / GameManager.instance.hero.maxHealth; 
        HealForeground.transform.localScale = new Vector3(ratio, 1,1);

        // update wave count
        EnemyCount.text = $"{currentWaveKills} / {WaveManager.GetCurrentWaveMaxCount()}";
    }

    public static void IncreaseCurrentKills()
    {
        currentWaveKills++;
    }

    public static void ResetCurrentKills()
    {
        currentWaveKills = 0;
    }


}
    