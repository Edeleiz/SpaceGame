using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private static InputController instance;

    protected MoveableObject moveableObject;
    protected InteractionController interactionController;
    protected GameObject owner;

	// Use this for initialization
	void Start ()
    {
		if (instance)
            instance.dispose();
        instance = this;

        owner = this.gameObject;
        moveableObject = GetComponent<MoveableObject>();
        interactionController = GetComponent<InteractionController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateMove();
        UpdateInteractive();
    }

    protected void UpdateMove()
    {
        if (!moveableObject)
            return;

        Vector3 tryMove = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
            tryMove += Vector3Int.left;
        if (Input.GetKey(KeyCode.RightArrow))
            tryMove += Vector3Int.right;
        if (Input.GetKey(KeyCode.UpArrow))
            tryMove += Vector3Int.up;
        if (Input.GetKey(KeyCode.DownArrow))
            tryMove += Vector3Int.down;

        if (tryMove != Vector3.zero)
            moveableObject.Move(tryMove);
    }

    protected void UpdateInteractive()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SpicerGameManager.instance.Interact();
        }
        
        if (!interactionController || !interactionController.interactionTarget)
            return;

        
//            interactionController.interactionTarget.Interact(interactionController.gameObject);
    }

    protected void dispose()
    {
        Destroy(this);
    }

    protected virtual void OnDestroy()
    {
        owner = null;
        moveableObject = null;
        interactionController = null;
    }
}
