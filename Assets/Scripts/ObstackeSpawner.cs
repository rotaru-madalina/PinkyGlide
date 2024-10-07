using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstackeSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnInterval = 2f;
    public float startDelay = 1f;
    public float randomLimit = 3f;
    public float spawnVariation = 0.2f;
    public float currentBonusSpeed = 0f;
    public float bonusSpeedIncrement = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating(nameof(SpawnObject), startDelay, spawnInterval);
        //Invoke(nameof(SpawnObject), startDelay);
        StartCoroutine(SpawnObject(startDelay));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator SpawnObject(float startDelay)
    {
        yield return new WaitForSeconds(startDelay);

        while(true)
        {
            Instantiate(obstacle, 
                this.transform.position + Vector3.up * Random.Range(-randomLimit, randomLimit), 
                Quaternion.identity).GetComponent<Obstacle>().speed += (currentBonusSpeed += bonusSpeedIncrement);

            yield return new WaitForSeconds(spawnInterval * Random.Range(1f - spawnVariation, 1f + spawnVariation));

            //Invoke(nameof(SpawnObject), spawnInterval * Random.Range(1f - spawnVariation, 1f + spawnVariation));
        }
    }
}
