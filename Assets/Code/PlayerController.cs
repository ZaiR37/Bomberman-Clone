using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool dead;

    [Header("Bomb")]
    [SerializeField] private Transform bombPrefab;
    [SerializeField][Min(0)] private int currentBomb = 0;
    [SerializeField][Min(1)] private int maxBomb = 1;
    [SerializeField][Min(1)] private int maxPower = 1;

    private void Update()
    {
        if (dead) return;

        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 moveForce = playerInput.normalized * moveSpeed;
        rb.velocity = moveForce;

        animator.SetFloat("Horizontal", playerInput.x);
        animator.SetFloat("Vertical", playerInput.y);

        if (Input.GetKeyDown(KeyCode.P))
        {
            GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            Debug.Log(gridPosition);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBomB();
        }
    }

    private void DropBomB()
    {
        if (currentBomb >= maxBomb) return;

        GridPosition gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if (LevelGrid.Instance.HasObjectOnGridPosition(gridPosition)) return;

        Vector3 bombPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
        Transform bombTransform = Instantiate(bombPrefab, bombPosition, Quaternion.identity);
        bombTransform.GetComponent<Bomb>().Setup(this, maxPower);

        currentBomb++;
    }

    public void Dead()
    {
        dead = true;
        rb.velocity = Vector2.zero;
        animator.SetTrigger("Dead");
    }

    public void DecreaseCurrentBomb() => currentBomb--;

    public void IncreaseBombMax() => maxBomb++;
    public void DecreaseBombMax() => maxBomb--;

    public void IncreaseBombPower() => maxPower++;
    public void DecreaseBombPower() => maxPower--;

    public void IncreaseMoveSpeed() => moveSpeed += 1f;
    public void DecreaseMoveSpeed() => moveSpeed -= 1f;

}
