using UnityEngine;
using System.Collections;

public class SpriteLimbs : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag.Equals("SpriteLeftHand") && other.name.Equals("lHand") ||
            gameObject.tag.Equals("SpriteRightHand") && other.name.Equals("rHand") ||
            gameObject.tag.Equals("SpriteLeftFoot") && other.name.Equals("lFoot") ||
            gameObject.tag.Equals("SpriteRightFoot") && other.name.Equals("rFoot"))
        {
            GameObject.Find("GameLogic").GetComponent<GameLogic>().increaseScore(3);
            Debug.Log(other.name + " has collided with " + transform.name);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (gameObject.tag.Equals("SpriteLeftHand") && other.name.Equals("lHand") ||
            gameObject.tag.Equals("SpriteRightHand") && other.name.Equals("rHand") ||
            gameObject.tag.Equals("SpriteLeftFoot") && other.name.Equals("lFoot") ||
            gameObject.tag.Equals("SpriteRightFoot") && other.name.Equals("rFoot"))
        {
            Debug.Log(other.name + " staying in " + transform.name);
        }
        
    }
}
