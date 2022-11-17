using System;
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SkeletonAnimation))]
public class HeroAnimationController : MonoBehaviour
{
    [SerializeField] private Hero hero;
    private SkeletonAnimation skeletonAnimation;
    
    private void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.AnimationName = "Idle_01";
    }

    private void OnEnable()
    {
        hero.Move.OnMoveLeft += MoveLeft;
        hero.Move.OnMoveRight += MoveRight;
        hero.Move.OnIdle += Idle;
        hero.Move.OnJump += Jump;
        hero.OnDied += Died;
        //hero.Move.OnFall += Fall;

        hero.OnAttackSword += AttackSword;
        hero.OnAttackStaff += AttackStaff;
        hero.OnAttackBow += AttackBow;
    }

    private void OnDisable()
    {
        
    }

    private void MoveLeft()
    {
        skeletonAnimation.loop = true;
        skeletonAnimation.AnimationName = "Running";
        skeletonAnimation.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
    }
    
    private void MoveRight()
    {
        skeletonAnimation.loop = true;
        skeletonAnimation.AnimationName = "Running";
        skeletonAnimation.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    
    private void Jump()
    {
        skeletonAnimation.loop = false;
        skeletonAnimation.AnimationName = "Jump_Start";
    }

  

    private void Idle()
    {
        skeletonAnimation.loop = true;

        skeletonAnimation.AnimationName = "Idle_01";
        if(Random.Range(0,4) == 0) skeletonAnimation.AnimationName = "Idle_02_blink";
    }
    
    private void Died()
    {
        skeletonAnimation.loop = false;
        skeletonAnimation.AnimationName = "Dying";
    }
    
    private void Fall()
    {
        skeletonAnimation.loop = true;
        skeletonAnimation.AnimationName = "Jump_Loop";
    }
    
    private void AttackBow()
    {
        if(hero.IsDied)return;
        skeletonAnimation.loop = true;
        skeletonAnimation.AnimationName = "Attack_Bow";
    }
    
    private void AttackStaff()
    {
        if(hero.IsDied)return;
        skeletonAnimation.loop = true;
        skeletonAnimation.AnimationName = "Attack_Stuff";
    }
    
    private void AttackSword()
    {
        if(hero.IsDied)return;
        skeletonAnimation.loop = true;
        skeletonAnimation.AnimationName = "Attack_Sword";
    }
}
