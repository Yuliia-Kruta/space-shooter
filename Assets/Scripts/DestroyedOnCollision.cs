using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TagListType
{
    Blacklist,
    Whitelist
}

public class DestroyedOnCollision : MonoBehaviour
{
    [SerializeField] private TagListType tagListType = TagListType.Blacklist;

    // A list of tags which we use to determine whether to explode or not
    // Depending on the tagListType (Blacklist or Whitelist)
    [SerializeField] private List<string> tags;

    void OnTriggerEnter2D(Collider2D other)
    {
        bool tagInList = tags.Contains(other.gameObject.tag);

        if (tagListType == TagListType.Blacklist
            && tagInList)
        {
            // Destroy if it's a Blacklist and the tag IS in the Blacklist
            Destroy(gameObject);
        }
        else if (tagListType == TagListType.Whitelist
                 && !tagInList)
        {
            // Destroy if it's a Whitelist and the tag is NOT in the Whitelist
            Destroy(gameObject);
        }
        else
        {
            // Use default collision code
        }
    }
}