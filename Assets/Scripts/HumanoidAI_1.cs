using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidAI_1 : MonoBehaviour
{
    public Animator animator;
    public bool lookingRight;
    public float moveSpeed;
    public Transform[] moveTargets;
    public Transform LevelTarget;
    private Vector3 currentMoveTarget;
    public float DecisionTimeLimit;
    private float DecisionTimer;
    private bool MoveToNextTarget;
    public float TargetApproachLimit;
    private bool isMoving, isShooting;
    public float MinDecisionTime, MaxDecisionTime;

    public Gun gun;

    private float timer;


    void Start()
    {
        isMoving = false;

        // force rotation
        //transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        //lookingRight = true;
    }

    void Update()
    {

        switch (Manager.Instance.stageState)
        {
            case Manager.StageState.None:
                Idle();
                break;
            case Manager.StageState.Delve:
                currentMoveTarget = LevelTarget.position;
                if (!lookingRight)
                {
                    lookingRight = true;
                    TurnAround();
                }
                Run();
                //MoveHumanoid(LevelTarget.transform.position);
                break;
            case Manager.StageState.Combat:
                Manouver();

                if (MoveToNextTarget)
                {
                    MoveHumanoid(currentMoveTarget);
                }
                if (isMoving)
                {
                    Run();
                }
                else
                {
                    if(GameObject.FindGameObjectWithTag("monster"))
                        Shoot();
                    else
                    {
                        Idle();

                        timer += Time.deltaTime;

                        if(timer > Manager.Instance.TimeBeforeDelveAgain)
                        {
                            timer = 0;
                            Manager.Instance.stageState = Manager.StageState.Delve;
                        }
                    }
                }
                break;
            case Manager.StageState.Event:
                break;
            default:
                break;
        }

        CheckRunDirection();
    }

    void CheckRunDirection()
    {
        Vector3 directionVect = currentMoveTarget - transform.position;
        if (directionVect.x < 0.0f && lookingRight)
        {
            TurnAround();
            lookingRight = false;
        }

        if(directionVect.x > 0.0f && !lookingRight)
        {
            TurnAround();
            lookingRight = true;
        }
    }

    void Manouver()
    {
        DecisionTimer += Time.deltaTime;
        if(DecisionTimer > DecisionTimeLimit)
        {
            DecisionTimer = 0;
            isMoving = true;
            DecisionTimeLimit = Random.Range(MinDecisionTime, MaxDecisionTime);
            currentMoveTarget = PickMoveTarget();
            MoveToNextTarget = true;
        }
    }

    Vector3 PickMoveTarget()
    {
        int randomPick = Random.Range(0, moveTargets.Length);
        return moveTargets[randomPick].position;
    }

    void MoveHumanoid(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, target) < TargetApproachLimit)
        {
            MoveToNextTarget = false;
            isMoving = false;
        }
    }

    void TurnAround()
    {
        gameObject.transform.eulerAngles += new Vector3(0, 180, 0);
    }

    void Run()
    {
        animator.Play("marine-run");
    }

    void Shoot()
    {
        animator.Play("marine-shoot-2");
    }


    void ShootAlt()
    {
        animator.Play("marine-shoot-3");
    }


    void Idle()
    {
        animator.Play("marine-idle");
    }
}
