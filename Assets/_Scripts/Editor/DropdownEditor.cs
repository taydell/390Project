using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;


[CustomEditor(typeof(Dropdown))]
public class DropdownEditor : Editor
{
    public Dropdown currDropdown;
    public SerializedProperty childrenProps;

    void OnEnable()
    {
        currDropdown = target as Dropdown;
        childrenProps = serializedObject.FindProperty("children");
    }

    public override void OnInspectorGUI()
    {
        VerifyValid();
        if (GUILayout.Button("Add Child"))
        {
            AddChild();
        }
        currDropdown.isOpen = EditorGUILayout.Toggle("Is Open?", currDropdown.isOpen);

        GUILayout.Space(5);
        currDropdown.mainText.text = EditorGUILayout.TextField("Main Text", currDropdown.mainText.text);
        currDropdown.mainText.fontSize = EditorGUILayout.IntField("Font Size", currDropdown.mainText.fontSize);

        GUILayout.Space(5);
        currDropdown.mainText.font = (Font)EditorGUILayout.ObjectField("Font", currDropdown.mainText.font, typeof(Font), false);
        currDropdown.mainText.color = EditorGUILayout.ColorField("Font Color", currDropdown.mainText.color);

        GUILayout.Space(5);
        currDropdown.image.sprite = (Sprite)EditorGUILayout.ObjectField("Button Sprite", currDropdown.image.sprite, typeof(Sprite), false, GUILayout.Height(16));
        currDropdown.image.type = (Image.Type)EditorGUILayout.EnumPopup("Type", currDropdown.image.type);
        currDropdown.normal = EditorGUILayout.ColorField("Button Normal", currDropdown.normal);
        currDropdown.highlighted = EditorGUILayout.ColorField("Button Highlighted", currDropdown.highlighted);
        currDropdown.pressed = EditorGUILayout.ColorField("Button Pressed", currDropdown.pressed);
        
        currDropdown.image.color = currDropdown.normal;


        UpdateChildren();
        currDropdown.Update();
        EditorUtility.SetDirty(currDropdown);
        Repaint();
    }

    void AddChild()
    {
        if (currDropdown.children == null)
            currDropdown.children = new System.Collections.Generic.List<DropdownChild>();
        currDropdown.children.Add(new DropdownChild(currDropdown));
    }

    void UpdateChildren()
    {
        if (currDropdown.children == null)
            return;

        GUILayout.Space(15);
        GUILayout.Label("Edit Children", EditorStyles.centeredGreyMiniLabel);
        currDropdown.childHeight = EditorGUILayout.FloatField("Child Height", currDropdown.childHeight);
        currDropdown.childFontSize = EditorGUILayout.IntField("Child Font Size", currDropdown.childFontSize);
        GUILayout.Space(10);

        for (int i = 0; i < currDropdown.children.Count; i++)
        {
            currDropdown.children[i].childObj.transform.SetSiblingIndex(i);

            currDropdown.children[i].childText.text = EditorGUILayout.TextField("Button Text", currDropdown.children[i].childText.text);

            #region Button
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Remove"))
            {
                DestroyImmediate(currDropdown.children[i].childObj);
            }
            if (GUILayout.Button("Move Up"))
            {
                if (i - 1 >= 0)
                {
                    DropdownChild temp = currDropdown.children[i];
                    currDropdown.children[i] = currDropdown.children[i - 1];
                    currDropdown.children[i - 1] = temp;
                }
            }
            if (GUILayout.Button("Move Down"))
            {
                if (i + 1 <= currDropdown.children.Count)
                {
                    DropdownChild temp = currDropdown.children[i];
                    currDropdown.children[i] = currDropdown.children[i + 1];
                    currDropdown.children[i + 1] = temp;
                }
            }
            GUILayout.EndHorizontal();
            #endregion 

            serializedObject.UpdateIfDirtyOrScript();
            EditorGUILayout.PropertyField(childrenProps.GetArrayElementAtIndex(i).FindPropertyRelative("childEvents"));
            serializedObject.ApplyModifiedProperties();
            if (currDropdown.children[i].UpdateChild(currDropdown) == false)
            {
                currDropdown.children.RemoveAt(i);
            }
        }
    }

    void VerifyValid()
    {
        if (currDropdown.image == null)
            currDropdown.gameObject.AddComponent<Image>();

        if (currDropdown.container == null)
        {
            if (currDropdown.transform.Find("Container") == null)
            {
                currDropdown.container = UIUtility.NewUIElement("Container", currDropdown.transform);
                currDropdown.container.gameObject.AddComponent<VerticalLayoutGroup>();
                UIUtility.ScaleRect(currDropdown.container, 0, 0);
                currDropdown.container.anchorMin = new Vector2(0, 0);
                currDropdown.container.anchorMax = new Vector2(1, 0);
            }
            else
                currDropdown.container = currDropdown.transform.Find("Container").GetComponent<RectTransform>();
        }

        if (currDropdown.mainText == null)
        {
            if (currDropdown.transform.Find("Text") == null)
            {
                currDropdown.mainText = UIUtility.NewText("Dropdown", currDropdown.transform);
            }
            else
                currDropdown.mainText = currDropdown.transform.Find("Text").GetComponent<Text>();

        }
    }
}