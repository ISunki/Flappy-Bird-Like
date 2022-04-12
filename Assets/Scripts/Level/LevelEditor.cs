using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor
{
    private Level level;
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        level = target as Level;
        OnRulesGUI(level);
    }

    void OnRulesGUI(Level level)
    {
        GUILayout.Label("Rules");
        
        GUILayout.BeginVertical();
        foreach (var rule in level.rules)
        {
            EditorGUILayout.ObjectField(rule.enemyPrefab, typeof(Character));
        }
        GUILayout.EndVertical();

        if (GUILayout.Button("Add Rule"))
        {
            level.rules.Add(new SpawnRule());
        }
    }
}
