using System;
using UnityEngine;

public class GravityCoreOrbit : MonoBehaviour
{
    public float DX = (float)0, DY = (float)100;
    private static float G = (float)9.810, radius = (float)100;
    private float psi;
    private Rigidbody2D RB;

    void Start()
    {
        psi = (float)Math.Sqrt(1 / radius * G);
        RB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float R, dr, dphi, f1, f2;
        Vector2 r, phi, U = new Vector2(RB.position.x - DX, RB.position.y - DY), V = new Vector2(RB.velocity.x, RB.velocity.y);
        if (-radius / 5 <= U.y && U.y < radius / 5)
        {
            R = (float)Math.Sqrt(U.x * U.x + U.y * U.y); // Scalar r.
            dr = (U.x * V.x + U.y * V.y) / R; // Scalar dr/dt.
            dphi = psi - (U.y * V.x - U.x * V.y) / R / R; // Scalar dφ/dt.
            r = new Vector2(U.x, U.y) / R; // Vector r̂.
            phi = new Vector2(-U.y, U.x) / R; // Vector φ̂.
        }
        else
        { // If outside the core, use the simplifying assumption that U.x ≈ 0 (so that gravity is independent of U.x).
            R = (float)Math.Abs(U.y);
            dr = U.y * V.y / R;
            dphi = psi - U.y * V.x / R / R;
            r = new Vector2(0, U.y) / R;
            phi = new Vector2(-U.y, 0) / R;
        }
        f1 = R * dphi * dphi * RB.mass; // Centrifugal force.
        f2 = -dr * dphi * RB.mass * 2; // Coriolis force.
        RB.AddForce(r * f1 + phi * f2);
        f1 = -U.x * R * dphi * dphi - U.y * dr * dphi * 2; // Correction force (x-component).
        f2 = -U.y * R * dphi * dphi + U.x * dr * dphi * 2; // Correction force (y-component).
        RB.AddForce(Vector2.right * f1 + Vector2.up * f2);
    }
}
