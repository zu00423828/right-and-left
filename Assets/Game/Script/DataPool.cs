using UnityEngine;
public class DataPool  {
    public static CharacterCC m_CharacterDT;
    public static questionbank m_questiondt;
    /// <summary>
    /// 初始化Pool
    /// </summary>
    public static void f_InitPool ()
    {
        m_CharacterDT = Resources.Load<CharacterCC>( "ExcelData/CharacterCC" );
        m_questiondt = Resources.Load<questionbank>("questionbank");
        
    }
    
}
