using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float MovementSpeed = 10f;
    [SerializeField]
    private float MaxMovementToOneSide = 7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -MaxMovementToOneSide && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += (Vector3)(Vector2.left * Time.deltaTime * MovementSpeed);
        }
        else if (transform.position.x < MaxMovementToOneSide && Input.GetKey(KeyCode.RightArrow)) {

            transform.position += (Vector3)(Vector2.right * Time.deltaTime * MovementSpeed);
        }
    }
}
