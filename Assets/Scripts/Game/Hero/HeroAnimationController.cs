using Spine.Unity;
using UnityEngine;

[RequireComponent(typeof(SkeletonMecanim),typeof(Animator))]
public class HeroAnimationController : MonoBehaviour
{
    [SerializeField] private Hero hero;
    private Animator animator;

    private const string RUN = "Run";
    private const string JUMP = "Jump";
    private const string DIED = "Died";
    private const string ATTACK_SWORD = "AttackSword";
    private const string ATTACK_BOW = "AttackBow";
    private const string ATTACK_STAFF = "AttackStaff";
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        hero.Move.OnMoveLeft += MoveLeft;
        hero.Move.OnMoveRight += MoveRight;
        hero.Move.OnIdle += Idle;
        hero.Move.OnJump += Jump;
        hero.OnDied.AddListener(Died);
        
        hero.OnAttackSword.AddListener(AttackSword);
        hero.OnAttackStaff.AddListener(AttackStaff);
        hero.OnAttackBow.AddListener(AttackBow);
    }

    private void OnDisable()
    {
        hero.Move.OnMoveLeft -= MoveLeft;
        hero.Move.OnMoveRight -= MoveRight;
        hero.Move.OnIdle -= Idle;
        hero.Move.OnJump -= Jump;
        hero.OnDied.RemoveListener(Died);
        
        hero.OnAttackSword.RemoveListener(AttackSword);
        hero.OnAttackStaff.RemoveListener(AttackStaff);
        hero.OnAttackBow.RemoveListener(AttackBow);
    }

    private void MoveLeft()
    {
        animator.SetBool(RUN, true);
        animator.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
    }
    
    private void MoveRight()
    {
        animator.SetBool(RUN, true);
        animator.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    
    private void Jump()
    {
        animator.SetTrigger(JUMP);
    }
    

    public void Idle()
    {
        animator.SetBool(RUN, false);
    }
    
    private void Died()
    {
        animator.SetBool(DIED, true);
    }
    
    
    private void AttackBow()
    {
        animator.SetTrigger(ATTACK_BOW);
    }
    
    private void AttackStaff()
    {
        animator.SetTrigger(ATTACK_STAFF);
    }
    
    private void AttackSword()
    {
        animator.SetTrigger(ATTACK_SWORD);
    }
}