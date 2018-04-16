namespace D3_Search_for_items
{
    struct CharacterInfo
    {
        public string Name { get; private set; }
        public string Icon { get; private set; }

        public CharacterInfo(string name, string icon)
        {
            Name = name;
            Icon = icon;
        }
    }
}
