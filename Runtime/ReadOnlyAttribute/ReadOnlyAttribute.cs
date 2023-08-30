namespace WiseMonkeES.Util.Editor
{
    #if UNITY_EDITOR
    using UnityEngine;
    /// <summary>
    /// Read Only attribute.
    /// Attribute is use only to mark ReadOnly properties.
    /// </summary>
    public class ReadOnlyAttribute : PropertyAttribute { }
    #endif
}
