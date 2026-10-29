using UnityEngine;

public class ColorPropulsor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteNave;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteNave = transform.parent.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) spriteRenderer.color = Color.red;
        else if (Input.GetKey(KeyCode.DownArrow)) spriteRenderer.color = Color.yellow;
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) spriteRenderer.color = new Color(1f, 0.5f, 0f);
    }

    void LateUpdate()
    {
        spriteNave.color = Color.white;
    }
}