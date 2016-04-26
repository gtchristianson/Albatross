using System;
using UnityEngine;

public class OrbitController: MonoBehaviour {
	public float DX = (float)0, DY = (float)100;
	private static float G = (float)9.810, radius = (float)100;
	private float psi;
	private Rigidbody2D RB;
	
	void Start() {
		Vector2 U;
		psi = (float)Math.Sqrt(1/radius*G);
		RB = GetComponent<Rigidbody2D>();
		U = new Vector2(RB.position.x-DX, RB.position.y-DY);
		RB.velocity = (new Vector2(U.y, -U.x))*psi;
	}
	
	void FixedUpdate() {
		float r, F;
		Vector2 R, U = new Vector2(RB.position.x-DX, RB.position.y-DY);
		if(-radius/5 <= U.y && U.y < radius/5) {
			r = (float)Math.Sqrt(U.x*U.x+U.y*U.y); // Scalar r.
			R = new Vector2(U.x, U.y)/r; // Vector r̂.
		}
		else { // If outside the core, use the simplifying assumption that U.x ≈ 0 (so that gravity is independent of U.x).
			r = (float)Math.Abs(U.y);
			R = new Vector2(0, U.y)/r;
		}
		F = -r*psi*psi*RB.mass; // Orbital force.
		RB.AddForce(F*R);
	}
}

