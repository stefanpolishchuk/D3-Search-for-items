namespace D3_Search_for_items
{
    struct SkillsInfo
    {
        public string Type { get; private set; }
        public string Slug { get; private set; }
        public string Name { get; private set; }
        public string Icon { get; private set; }
        public string Description { get; private set; }

        public SkillsInfo(string type, string slug, string name, string icon, string description)
        {
            Type = type;
            Slug = slug;
            Name = name;
            Icon = icon;
            Description = description;
        }
    }
}
