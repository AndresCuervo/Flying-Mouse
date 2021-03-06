﻿
using UnityEngine;
using System.Collections;

public class DestinationModel : MonoBehaviour
{
	private float clock;		// Keep track of time since creation for animation.
	private Destination owner;			// Pointer to the parent object.
	private Material mat;		// Material for setting/changing texture and color.
	private float BGSCALE = 4f;
	private float quadHeight;
	private float quadWidth;
	public static Vector2 dest_center;

	public void init(Destination owner) {
		this.owner = owner;
		dest_center = new Vector2(owner.transform.position.x, owner.transform.position.y);
		transform.parent = owner.transform;					// Set the model's parent to the background.
		transform.localPosition = owner.transform.position;		// Center the model on the parent.

//		print ("owner-center " + owner.transform.position);
		//quadHeight = Camera.main.orthographicSize * 2.0f;
		//quadWidth = quadHeight * Screen.width / Screen.height;
		//		transform.localScale = new Vector3(quadWidth * BGSCALE, quadHeight * BGSCALE,1f);
		transform.localScale = new Vector3(7f, 7f,1f);
		name = "Destination Model";									// Name the object.

		mat = GetComponent<Renderer>().material;								// Get the material component of this quad object.
		mat.shader = Shader.Find ("Sprites/Default");						// Tell the renderer that our textures have transparency.
		mat.color = new Color(1, 1, 1, 1f);
		mat.mainTexture = Resources.Load<Texture2D>("Textures/sun");	// Set the texture.  Must be in Resources folder.
		DestroyImmediate(this.gameObject.GetComponent<MeshCollider>());
		CircleCollider2D cc = this.gameObject.AddComponent<CircleCollider2D> ();
		cc.radius = .27f;
		cc.isTrigger = true;
		//bc.size = new Vector2 (4f, 4f);
	}


	void OnTriggerEnter2D(Collider2D col){
		Bird bird = col.gameObject.GetComponent<Bird> ();
		if (bird) {
			
			bird.AtDestination = true;
		}
	}

	void Update(){
		clock += Time.deltaTime;
		transform.eulerAngles = new Vector3 (0, 0, 360 * clock * .1f);
	}



}
