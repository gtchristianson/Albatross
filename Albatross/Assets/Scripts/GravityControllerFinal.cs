using System;
using UnityEngine;

public class GravityControllerFinal: MonoBehaviour {
	public float DX = (float)0, DY = (float)100;
	private static float G = (float)9.810, radius = (float)100;
	private float psi;
	private Rigidbody2D RB;
	
	void Start() {
		psi = (float)Math.Sqrt(1/radius*G);
		RB = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate() {
		float r, dr, dphi, f1, f2;
		Vector2 R, phi, U = new Vector2(RB.position.x-DX, RB.position.y-DY), V = new Vector2(RB.velocity.x, RB.velocity.y);
		if(-radius/5 <= U.y && U.y < radius/5) {
			r = (float)Math.Sqrt(U.x*U.x+U.y*U.y); // Scalar r.
			dr = (U.x*V.x+U.y*V.y)/r; // Scalar dr/dt.
			dphi = psi-(U.y*V.x-U.x*V.y)/r/r; // Scalar dφ/dt.
			R = new Vector2(U.x, U.y)/r; // Vector r̂.
			phi = new Vector2(-U.y, U.x)/r; // Vector φ̂.
		}
		else { // If outside the core, use the simplifying assumption that U.x ≈ 0 (so that gravity is independent of U.x).
			r = (float)Math.Abs(U.y);
			dr = U.y*V.y/r;
			dphi = psi-U.y*V.x/r/r;
			R = new Vector2(0, U.y)/r;
			phi = new Vector2(-U.y, 0)/r;
		}
		f1 = r*dphi*dphi*RB.mass; // Centrifugal force.
		f2 = -dr*dphi*RB.mass*2; // Coriolis force.
		RB.AddForce(f1*R+f2*phi);
	}
}

