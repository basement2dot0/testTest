using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AxisKeys))]
public class AxisKeyDrawer : PropertyDrawer {


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //ensure override works on entire property
        EditorGUI.BeginProperty(position, label, property);

        //don't indent
        int indent = EditorGUI.indentLevel;

        EditorGUI.indentLevel = 0;


        //Label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        //set position rect
        Rect posLabel = new Rect(position.x, position.y, 15f, position.height);
        Rect posField = new Rect(position.x + 20, position.y, 50f, position.height);

        Rect negLabel = new Rect(position.x + 75, position.y, 15f, position.height);
        Rect negField = new Rect(position.x + 95, position.y, 50f, position.height);


        //set labels
        GUIContent posGUI = new GUIContent("+");
        GUIContent negGUI = new GUIContent("-");

        //Draw Fields
        EditorGUI.LabelField(posLabel, posGUI);
        EditorGUI.PropertyField(posField, property.FindPropertyRelative("positive"), GUIContent.none);

        EditorGUI.LabelField(negLabel, negGUI);
        EditorGUI.PropertyField(negField, property.FindPropertyRelative("negative"), GUIContent.none);


        //Reset indent
        EditorGUI.indentLevel = indent;

        //End Property
        EditorGUI.EndProperty();


        
    }

}
