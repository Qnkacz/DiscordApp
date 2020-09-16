namespace DiscordApp.RPGSystems.DnD
{
    public struct attacksNSpells
    {
        public string spellName;
        public string description;
        public attacksNSpells(string _name , string _desc)
        {
            spellName = _name;
            description = _desc;
        }
    }

    public struct DnDTrait
    {
        public string spellName;
        public string description;
        public DnDTrait(string _name, string _desc)
        {
            spellName = _name;
            description = _desc;
        }
    }
    public struct DnDSpells
    {
        public string spellName;
        public string description;
        public DnDSpells(string _name, string _desc)
        {
            spellName = _name;
            description = _desc;
        }
    }
}