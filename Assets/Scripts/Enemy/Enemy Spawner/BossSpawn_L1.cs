using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossSpawn_L1 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject BossHPBar;

    private void Start()
    {
        StartCoroutine(SpawnAfterDelay());
    }

    private IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(60f);
        enemyPrefab.SetActive(true);
        BossHPBar.SetActive(true);
    }
}
