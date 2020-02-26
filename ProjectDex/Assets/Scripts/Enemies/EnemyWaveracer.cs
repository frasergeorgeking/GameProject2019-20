﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveracer : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(2f, 50f)] float speed = 20f;
    [SerializeField] [Range(1, 15)] int health = 6;
    [SerializeField] [Range(1, 20)] int damageToPlayer = 1;
    [SerializeField] [Range(0.1f, 5f)] float shootCooldown = 2.5f;

    //Private Variables
    private GameObject player;
    private PolygonCollider2D col;
    private Rigidbody2D rb;
    private bool canShoot = false;
    private GameObject bullet;
    private bool targetPosSet;
    private bool targetPosMax = true;
    private Vector2 targetPos;



    //Declare/Define Enums
    public enum waveracerDirection
    {
        horizontal,
        vertical
    }

    private waveracerDirection desiredDirection;

    public enum waveracerState
    {
        newTarget,
        movingToTarget,
        targetReached
    }

    private waveracerState currentState;

    void Awake()
    {
        //Define Variables
        player = GameObject.FindGameObjectWithTag("player");
        col = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        SelectDirection(); //Select direction for waveracer
        UpdateState("newTarget"); //Set state machine state
    }

    void FixedUpdate()
    {
        VerifyState(); //Verify State Machine Status & Call Imbedded Functions
    }

    private void VerifyState()
    {
        switch (currentState)
        {
            case (waveracerState.newTarget):

                if (!targetPosSet)
                {
                    CalculateTargetPos(targetPosMax); //If targetPosMax == true, sets max pos; if false, sets min pos
                    targetPosSet = true; //Update targetPosSet to true
                    UpdateState("movingToTarget"); //Update state machine to moving
                }
                
                break;

            case (waveracerState.movingToTarget):
                
                HandleMovement();
                
                break;

            case (waveracerState.targetReached):
                
                targetPosSet = false; //Set targetPosSet to false
                targetPosMax = !targetPosMax; //Inverse value of targetPosMax - toggles movement from min to max boundary
                UpdateState("newTarget"); //Update state machine to newTarget
                
                break;
        }
    }

    private void HandleMovement()
    {
        if (new Vector2(transform.position.x, transform.position.y) == targetPos)
        {
            UpdateState("targetReached"); //Update state machine to targetReached
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        
        //Clamp Enemy Position to Arena Boundary
        rb.position = new Vector2
            (
            Mathf.Clamp(rb.position.x, (ArenaScaler.Instance.GetArenaBoundary("minX") + ArenaScaler.Instance.GetColliderBufferSize()), (ArenaScaler.Instance.GetArenaBoundary("maxX") - ArenaScaler.Instance.GetColliderBufferSize())),
            Mathf.Clamp(rb.position.y, (ArenaScaler.Instance.GetArenaBoundary("minY") + ArenaScaler.Instance.GetColliderBufferSize()), (ArenaScaler.Instance.GetArenaBoundary("maxY") - ArenaScaler.Instance.GetColliderBufferSize()))
            );
    }

    private void CalculateTargetPos(bool max)
    {
        switch (desiredDirection)
        {
            case (waveracerDirection.horizontal):
                if (max)
                {
                    targetPos = new Vector2(gameObject.transform.position.x, ArenaScaler.Instance.GetArenaBoundary("maxY") - 1);
                }
                
                if (!max)
                {
                    targetPos = new Vector2(gameObject.transform.position.x, ArenaScaler.Instance.GetArenaBoundary("minY") - 1);
                }
                
                break;

            case (waveracerDirection.vertical):
                if (max)
                {
                    targetPos = new Vector2(ArenaScaler.Instance.GetArenaBoundary("maxX") - 1, gameObject.transform.position.y);
                }

                if (!max)
                {
                    targetPos = new Vector2(ArenaScaler.Instance.GetArenaBoundary("minX") - 1, gameObject.transform.position.y);
                }
                break;
        }
    }

    private void SelectDirection()
    {
        float randValue = UnityEngine.Random.value; //Effectively flips a pseudo-random coin - MUST define UnityEngine.Random, as System Namespace is used, which always contains a Random definition

        if (randValue < 0.5f)
        {
            desiredDirection = waveracerDirection.horizontal; //Set Direction to Horizontal
        }

        else
        {
            desiredDirection = waveracerDirection.vertical; //Set Direction to Vertical
        }
    }

    private void UpdateState(string updatedState)
    {
        switch (updatedState)
        {
            case ("newTarget"):
                currentState = waveracerState.newTarget;
                break;

            case ("movingToTarget"):
                currentState = waveracerState.movingToTarget;
                break;

            case ("targetReached"):
                currentState = waveracerState.targetReached;
                break;

            default:
                throw new Exception("Invalid case detected. Please use 'newTarget', 'movingToTarget' & 'targetReached'");
                break;
        }
    }


}
