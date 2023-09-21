﻿using UnityEditor;
using UnityEngine;
using static LanguageConfig;

public class Setting : EditorWindow
{
    private static Setting setting;
    int sleIndex = 0;

    
    [MenuItem("LayaAir3D 3.0/Setting")]
    public static void initTutorial()
    {
        setting = (Setting)EditorWindow.GetWindow(typeof(Setting));
        Texture2D title = new Texture2D(16, 16);
        Util.FileUtil.FileStreamLoadTexture(Util.FileUtil.getPluginResUrl("LayaResouce/layabox.png"), title);
        GUIContent titleContent = new GUIContent("LayaAir3D", title);
        setting.titleContent = titleContent;
    }
    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("", GUILayout.Width(15));
        string[] selections = new[] { "English", "中文" };
        int languageIndex = EditorGUILayout.Popup("Language",sleIndex, selections);
        sleIndex = languageIndex;
        languages currentLanguage = languages.English;
        switch (languageIndex)
        {
            case 0: currentLanguage = languages.English;
                break;
            case 1: currentLanguage = languages.Chinese;
                break;
            default: currentLanguage = languages.Chinese;
                break;
        }
        if (LanguageConfig.setLanguages(currentLanguage))
        {
            if (LayaAir3D.layaWindow != null)
            {
                LayaAir3D.layaWindow.Repaint();
            }
           
        }
        GUILayout.EndHorizontal();
    }

    private void OnDestroy()
    {

    }
}
