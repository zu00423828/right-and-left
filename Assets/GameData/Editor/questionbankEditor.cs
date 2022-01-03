using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityQuickSheet;
using System.Linq;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(questionbank))]
public class questionbankEditor : BaseExcelEditor<questionbank>
{	    
    public override bool Load()
    {
        questionbank targetData = target as questionbank;

        string path = targetData.SheetName;
        if (!File.Exists(path))
            return false;

        string sheet = targetData.WorksheetName;

        ExcelQuery query = new ExcelQuery(path, sheet);
        if (query != null && query.IsValid())
        {
            targetData.dataArray = query.Deserialize<questionbankData>().ToArray();
            targetData.dataList = query.Deserialize<questionbankData>();
            EditorUtility.SetDirty(targetData);
            AssetDatabase.SaveAssets();
            return true;
        }
        else
            return false;
    }
}
