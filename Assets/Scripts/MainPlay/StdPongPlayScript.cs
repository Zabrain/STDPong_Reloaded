using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StdPongPlayScript : MonoBehaviour {

    public GameObject BackgroundObject; //the object that holds the background sprites

    public Sprite[] BackgroundSprite; //arrays of all the background sprites


    private void Awake()
    {
        RenderTheBackground();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void RenderTheBackground()
    {
        SpriteRenderer spriteRenderer = BackgroundObject.GetComponent<SpriteRenderer>(); //grab the background's sprite renderer

        spriteRenderer.sprite = BackgroundSprite[1]; //assign the appropriate sprite

        //SpriteRenderer sr = GetComponent<SpriteRenderer>();

        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        Vector2 scale = BackgroundObject.transform.localScale;
        if (cameraSize.x >= cameraSize.y)
        { // Landscape (or equal)
            scale *= cameraSize.x / spriteSize.x;
        }
        else
        { // Portrait
            scale *= cameraSize.y / spriteSize.y;
        }

        BackgroundObject.transform.position = Vector2.zero; // Optional
        BackgroundObject.transform.localScale = scale;
    }

}
