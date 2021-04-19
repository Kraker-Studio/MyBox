using System;
using System.Collections.Generic;
using MyBox.Internal;

namespace MyBox {
    /// <summary>
    /// CollectionWrapper used to apply custom drawers to Array fields
    /// </summary>
    [Serializable]
    public class CollectionWrapper<T> : CollectionWrapperBase {
        public T[] Value;

        public T this[int i] {
            get { return Value[i]; }
            set { Value[i] = value; }
        }
        public int Count {
            get {
                return Value.Length;
            }
        }
        public List<T> To_List(){
            return new List<T>(Value);
        }
    }
}

namespace MyBox.Internal {
    [Serializable]
    public class CollectionWrapperBase { }
}

#if UNITY_EDITOR
namespace MyBox.Internal {
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(CollectionWrapperBase), true)]
    public class CollectionWrapperDrawer : PropertyDrawer {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var collection = property.FindPropertyRelative("Value");
            return EditorGUI.GetPropertyHeight(collection, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var collection = property.FindPropertyRelative("Value");
            EditorGUI.PropertyField(position, collection, label, true);
        }
    }
}
#endif