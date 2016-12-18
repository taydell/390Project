using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class Dropdown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform container;
    public bool isOpen;
    public Text mainText;
    public Image image { get { return GetComponent<Image>(); } }

    public List<DropdownChild> children;
    public float childHeight = 30;
    public int childFontSize = 11;
    public Color normal = Color.white;
    public Color highlighted = Color.red;
    public Color pressed = Color.grey;
     
    void Start()
    {
        container = transform.FindChild("Container").GetComponent<RectTransform>();
        isOpen = false;
    }
    public void Update()
    {
        Vector3 scale = container.localScale;
        scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 10);
        container.localScale = scale;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        isOpen = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOpen = false;
    }
}

[System.Serializable]
public class DropdownChild
{
    public GameObject childObj;
    public Text childText;
    public Button.ButtonClickedEvent childEvents;

    private LayoutElement element { get { return childObj.GetComponent<LayoutElement>(); } }
    private Button button { get { return childObj.GetComponent<Button>(); } }
    private Image image { get { return childObj.GetComponent<Image>(); } }

    public DropdownChild(Dropdown parent)
    {
        childObj = UIUtility.NewButton("Child", "Button", parent.container).gameObject;
        childObj.AddComponent<LayoutElement>();

        childText = childObj.GetComponentInChildren<Text>();

        childEvents = button.onClick;
    }

    public bool UpdateChild(Dropdown parent)
    {
        if (childObj == null)
            return false;

        element.minHeight = parent.childHeight;

        image.sprite = parent.image.sprite;
        image.type = parent.image.type;

        childText.font = parent.mainText.font;
        childText.color = parent.mainText.color;
        childText.fontSize = parent.childFontSize;

        ColorBlock b = button.colors;
        b.normalColor = parent.normal;
        b.highlightedColor = parent.highlighted;
        b.pressedColor = parent.pressed;

        button.onClick = childEvents;

        return true;
    }
}