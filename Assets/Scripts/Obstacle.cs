using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 0.5f;
    public float xLimit = -11f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        TryDestroyObstacle();
    }

    private void MoveLeft()
    {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void TryDestroyObstacle()
    {
        if(this.transform.position.x < xLimit)
        {
            Destroy(this.gameObject);
        }
    }
}
