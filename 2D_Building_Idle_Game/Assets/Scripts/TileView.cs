
/* 
 * This class represents the display of tile. TileView provides access to the its SpriteRenderer component.
 * The Initialize method adjusts the colors of the image based on the isOffset value. 
 * If the isOffset value is true, the base color is used, if false, the offset color is used.
*/

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
