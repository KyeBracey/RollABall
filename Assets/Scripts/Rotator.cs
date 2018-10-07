using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	// Our cubes are "static colliders", but because we are moving them here,
	// Unity recalculates the position of all the static colliders and saves it again
	// in the cache. This takes up needless resources because these static colliders never
	// change position.  We add a Rigidbody component to them, to indicate to Unity
	// that these objects are static colliders, then it uses less resources.
	// HOWEVER this makes gravity have an effect on them so we need to fix that as well.
	// We could uncheck the "use gravity" box in Rigidbody, but the collider will still respond
	// to other physics forces.  It's better to check
	// "is kinematic" - a kinematic gameObject won't respond to physics forces, but
	// can be animated and moved by its transform.
}
