/****
 *Created by: Ava Fritts
 *Date Created: March 30, 2022
 *
 *Last Edited by: NA
 * Last Edited: March 30, 2022
 *
 *Description: shooty bits.
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private BoundsCheck bndCheck;

    // Start is called before the first frame update
    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bndCheck.offUp) //if off screen (top)
        {
            Destroy(gameObject);
        }
    }
}
