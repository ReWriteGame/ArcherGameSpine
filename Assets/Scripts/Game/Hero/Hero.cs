using System;
using UnityEngine;

[SelectionBase]
public class Hero : MonoBehaviour
{
    [SerializeField] private Move move;
    private bool isDied = false;
    
    public Action OnAttackBow;
    public Action OnAttackSword;
    public Action OnAttackStaff;
    public Action OnDied;


    public Move Move => move;
    public bool IsDied => isDied;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Ground>())
        {
            move.CanJump = true;
        }
        
      if (col.gameObject.GetComponent<Enemy>())
      {
          Died();
      }
    }
    
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Ground>())
        {
            move.CanJump = false;
        }
    }

    public void AttackBow()
    {
        OnAttackBow?.Invoke();
    }
    
    public void AttackSword()
    {
        OnAttackSword?.Invoke();
    }
    
    public void AttackStaff()
    {
        OnAttackStaff?.Invoke();
    }
    
    public void Died()
    {
        OnDied?.Invoke();
        move.CanJump = false;
        move.CanMove = false;
        isDied = true;
    }
}
