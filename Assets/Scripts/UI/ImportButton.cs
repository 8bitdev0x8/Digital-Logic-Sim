using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFB;
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

        /*
        #if UNITY_EDITOR
        string path = EditorUtility.OpenFilePanel(
            "Import chip design",
            "",
            "dls"
        );
        ChipLoader.Import(path);
        EditChipBar();
        return;
        #endif
        */

        var opath = StandaloneFileBrowser.OpenFilePanel("Open File", "", "dls", false);
        print("opath0" + opath[0]);
        ChipLoader.Import(opath[0]);
        EditChipBar();

    }

    void EditChipBar()
    {
        chipBarUI.ReloadBar();
        SaveSystem.LoadAll(manager);
    }
}
