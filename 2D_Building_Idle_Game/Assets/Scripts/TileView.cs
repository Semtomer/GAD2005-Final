
using UnityEngine;

public class TileView : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Color baseColor;
    [SerializeField] private Color offsetColor;

    public void Initialize(bool isOffset)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = isOffset ? baseColor : offsetColor;
    }
}
