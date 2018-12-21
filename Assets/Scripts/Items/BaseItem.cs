using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour {
    public ItemTypeEnum ItemType;
    public bool IsUnique = false;
    public int MaxStack = 16;
}
