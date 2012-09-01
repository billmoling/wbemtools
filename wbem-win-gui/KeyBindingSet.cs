using System;
using System.Collections.Generic;
using System.Text;
using Wbem;

namespace DemoGui
{
    class KeyBindingSetItem
    {
        #region Members
        private CimKeyBindingList _keyBindings;
        private int _numInstances;
        private string _baseKeyClassName;
        #endregion

        #region Constructors
        public KeyBindingSetItem(CimKeyBindingList keyBindings, string baseKeyClassName)
        {
            BaseKeyClassName = baseKeyClassName;
            KeyBindings = keyBindings;
            NumInstances = 1;
        }
        #endregion

        #region Properties and Indexers
        public string BaseKeyClassName
        {
            get { return _baseKeyClassName; }
            set { _baseKeyClassName = value; }
        }

        public int NumInstances
        {
            get { return _numInstances; }
            set { _numInstances = value; }
        }


        public CimKeyBindingList KeyBindings
        {
            get { return _keyBindings; }
            set { _keyBindings = value; }
        }
        #endregion

        #region Methods and Operators

        #endregion
    }

    class KeyBindingSet
    {
        #region Members
        private List<KeyBindingSetItem> _set;
        #endregion

        #region Constructors
        public KeyBindingSet()
        {
            Set = new List<KeyBindingSetItem>();
        }
        #endregion

        #region Properties and Indexers
        public List<KeyBindingSetItem> Set
        {
            get { return _set; }
            set { _set = value; }
        }
        #endregion

        #region Methods and Operators
        public bool Contains(CimKeyBindingList newKeyBindingList, string baseKeyClassName)
        {
            return (Find(newKeyBindingList, baseKeyClassName) != null);
        }

        public KeyBindingSetItem Find(CimKeyBindingList newKeyBindingList, string baseKeyClassName)
        {
            foreach (KeyBindingSetItem curItem in Set)
            {
                if ( (curItem.KeyBindings.ShallowEquals(newKeyBindingList) == true) &&
                     (curItem.BaseKeyClassName == baseKeyClassName) )
                {
                    return curItem;
                }
            }

            return null;
        }

        public void Add(CimKeyBindingList newKeyBindingList, string baseKeyClassName)
        {
            Set.Add(new KeyBindingSetItem(newKeyBindingList, baseKeyClassName));
        }
        #endregion
    }
}
