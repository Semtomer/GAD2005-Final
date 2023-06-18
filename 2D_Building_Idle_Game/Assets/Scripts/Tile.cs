
using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Color baseColor, offsetColor;

    public void Init(bool isOffset)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = isOffset ? baseColor : offsetColor;
    }
}
