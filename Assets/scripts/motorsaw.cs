/*
  Copyright (c) Mizomancer
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motorsaw : MonoBehaviour {

    #region Variables
    public float speed; 

	#endregion


	#region Unity Methods
	void Start () {
 	}


    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, speed));


    }
    #endregion
}
