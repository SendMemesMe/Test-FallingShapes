using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Shape : MonoBehaviour, IFallingShape
{
    protected float fallSpeed;        
    protected float rotationSpeed;    
    protected Rigidbody2D rb;

    public  void Fall()
    {
        rb.velocity = new Vector2(0, -fallSpeed);
    }

    public  void Rotate()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    protected  void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        fallSpeed = Random.Range(1f, 5f);
        rotationSpeed = Random.Range(50f, 150f);
        DestroyGO();
    }

    protected void Update()
    {
        Rotate();
    }
    protected void FixedUpdate()
    {
        Fall();
    }
    public virtual void DestroyGO()
    {
        Destroy(gameObject, 10f);
    }
}
