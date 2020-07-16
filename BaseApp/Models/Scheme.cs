using System;
using System.Collections.Generic;

namespace BaseApp.Models
{
    public class Scheme
    {
        public static void Update(Scheme changedScheme, VolumeItem currentItem)
        {
            changedScheme.itemName = currentItem.name;
            changedScheme.itemSignature = currentItem.signature;
        }

        public string id;
        public string name { get; set; }
        public string volumeId;
        public List<SchemeField> fields;
        public string itemRef;
        public string generatedId = Guid.NewGuid().ToString();
        public string itemName;
        public string itemSignature;

    }
}
