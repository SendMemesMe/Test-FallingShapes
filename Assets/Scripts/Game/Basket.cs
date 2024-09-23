using UnityEngine;
using UnityEngine.EventSystems;


public class Basket : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Sprite[] sprites;
    public float minSpriteChangeInterval = 3f;
    public float maxSpriteChangeInterval = 7f;
    private SpriteRenderer spriteRenderer;
    private string currentColor;
    private float nextSpriteChangeTime;
    private float minX;
    private float maxX;
    private Vector2 dragStartPosition;
    public float speedMultiplier = 1.0f;
    public UIScore uiscore;


    private void OnEnable()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        Vector3 screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
        Vector3 screenTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        minX = screenBottomLeft.x + (transform.localScale.x); 
        maxX = screenTopRight.x - (transform.localScale.x);
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        ChangeSprite();
    }

    void Update()
    {
        if (Time.time >= nextSpriteChangeTime)
        {
            ChangeSprite();
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 newPosition = transform.position;
        newPosition.x += eventData.delta.x * Time.deltaTime * speedMultiplier;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }

    public void OnEndDrag(PointerEventData eventData){}

    private void ChangeSprite()
    {
        int randomIndex = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[randomIndex];
        currentColor = GetColorFromIndex(randomIndex);
        ScheduleNextSpriteChange();
        Debug.Log($"{currentColor}");
    }

    private string GetColorFromIndex(int index)
    {
        switch (index)
        {
            case 0: return "Green";
            case 1: return "Blue";
            case 2: return "Red";
            case 3: return "Yellow";
            default: return "Unknown";
        }
    }

    private void ScheduleNextSpriteChange()
    {
        float randomInterval = Random.Range(minSpriteChangeInterval, maxSpriteChangeInterval);
        nextSpriteChangeTime = Time.time + randomInterval;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == currentColor)
        {
            Destroy(collision.gameObject);
            uiscore.AddScore(3);
        }
        else
        {
            Destroy(collision.gameObject);
            uiscore.SubtractScore(1);
        }
    }
}
