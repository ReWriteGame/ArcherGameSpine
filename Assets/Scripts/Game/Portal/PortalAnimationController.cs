using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PortalAnimationController : MonoBehaviour
{
  [SerializeField]private Portal portal;
  private Animator animator;

  private const string OPEN = "Open";
  private void Start()
  {
    animator = GetComponent<Animator>();
  }

  private void OnEnable()
  {
    portal.OnOpen += Open;
  }

  private void OnDisable()
  {
    portal.OnOpen -= Open;
  }

  private void Open()
  {
    animator.SetTrigger(OPEN);
  }
}
