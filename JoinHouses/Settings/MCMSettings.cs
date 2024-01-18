using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace JoinHouses.Settings {
    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {

        [SettingPropertyGroup("Join Houses")]
        [SettingPropertyInteger("Relation Needed", 0, 10000, "0", Order = 0, RequireRestart = false, HintText = "Relation ship need to join houses")]
        public int RelationValue { get; set; } = 1;

        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}
