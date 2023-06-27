
using UnityEngine;

public class TileView : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Color baseColor;
    [SerializeField] private Color offsetColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(bool isOffset)
    {
        spriteRenderer.color = isOffset ? baseColor : offsetColor;
    }
}
