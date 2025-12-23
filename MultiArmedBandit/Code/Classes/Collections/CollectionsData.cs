using MultiArmedBandit.Properties;
using System.Collections.ObjectModel;

namespace MultiArmedBandit
{
    static class CollectionsData
    {
        static CollectionsData()
        {
            Data = FileReader.ReadJsonResource<CollectionNames, CollectionData>(Resources.CollectionsData);
        }

        public static ReadOnlyDictionary<CollectionNames, CollectionData> Data { get; }
    }
}
