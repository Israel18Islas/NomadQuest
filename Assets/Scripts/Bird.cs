using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MovingObject
{
    [Header("Enemy Props")]
    public MovingObject Target;
    public float Speed = 1.5f;    

    public Transform startPosition;

    // Is chasing
    private bool isChasing = false;
    // Sprite component to flip x
    private SpriteRenderer sprite;
    // Trigger animations, set values, etc
    private Animator animator;
    // Range Collider, triggers the collision with the target!
    private Collider2D rangeCollider;
    // Range Sensor
    private SensorMovement rangeSensor;

    public override void Start()
    {
        base.Start();
        sprite = GetComponent<SpriteRenderer>();
        var obj = transform.Find("RangeSensor");
        rangeCollider = obj.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rangeSensor = obj.GetComponent<SensorMovement>();        
    }

    void Update()
    {
        if (Target == null)
            return;

        if(rangeSensor.State())        
            isChasing = true;

        if(!rangeSensor.State())
            isChasing = false;

        if (isChasing)
            MoveTowards(Target.Position, Speed);
        else
            MoveTowards(startPosition.position, Speed);

    }

    protected override bool AttemptMove(float xDir, float yDir)
    {
        return true;
    }

    protected override void OnMovement()
    {
        //// Trigger animation by moving var!
        //if (isMoving)
        //    animator.SetInteger("State", 1);
        //else
        //    animator.SetInteger("State", 0);
    }

    protected override void OnSwapDirection(int direction)
    {
        if (direction > 0)
            sprite.flipX = true;
        else if (direction < 0)
            sprite.flipX = false;
    }
}

