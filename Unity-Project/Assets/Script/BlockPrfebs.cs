using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public enum BlockState {
        Empty,
        Connected
    }

    public Color red;
    public Color green;
    public Color blue;
    public Color yellow;


    BoxCollider2D box;
    SpriteRenderer coloring;

    void Start () {
		
	}

	void Update () {

    }
    
}
