using System;
using UnityEngine;

public class GravityController: MonoBehaviour {
	public float radius = (float)100;
    public float DU = (float)0;
	private float psi;
	private Rigidbody2D RB;
	
	void Start() {
		psi = 1/(float)Math.Sqrt(radius/10);
		RB = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate() {
		float U = RB.position.y-radius+DU, V = RB.velocity.x-U*psi;
		RB.AddForce((RB.velocity.y*psi*Vector2.right*2+V*V/U*Vector2.up)*RB.mass);
	}
}

