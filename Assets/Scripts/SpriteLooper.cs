using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLooper : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    int currentPicture = 0;
    public float changeInterval = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(LoadNextPicture), 0.01f, changeInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextPicture()
    {
        currentPicture++;
        if(currentPicture >= sprites.Length)
        {
            currentPicture = 0;
        }
        this.GetComponent<SpriteRenderer>().sprite = sprites[currentPicture];
    }
}
