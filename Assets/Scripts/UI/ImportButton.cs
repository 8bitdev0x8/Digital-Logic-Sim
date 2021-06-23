using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ImportButton : MonoBehaviour
{
    public Button importButton;
    public Manager manager;
    public ChipBarUI chipBarUI;
    void Start()
    {
        importButton.onClick.AddListener(ImportChip);
    }

    void ImportChip() {
        #if UNITY_EDITOR
        string path = EditorUtility.OpenFilePanel(
            "Import chip design",
            "",
            "dls"
        );
        ChipLoader.Import(path);
        EditChipBar();
        #endif
    }

    void EditChipBar()
    {
        chipBarUI.ReloadBar();
        SaveSystem.LoadAll(manager);
    }
}
