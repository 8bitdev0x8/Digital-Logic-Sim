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

       
        StandaloneFileBrowser.OpenFilePanelAsync("Open File", "", "dls", false, (string[] opath) => {
            if (string.IsNullOrEmpty(opath[0]))
                return;
            ChipLoader.Import(opath[0]); 
        });
        
        
        EditChipBar();

    }

    void EditChipBar()
    {
        chipBarUI.ReloadBar();
        SaveSystem.LoadAll(manager);
    }
}
