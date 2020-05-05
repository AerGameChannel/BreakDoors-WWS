using WW_SYSTEM;
using WW_SYSTEM.Attributes;

namespace BreakDoors
{
    [PluginDetails(
        author = "Aer",
        name = "BreakDoors",
        description = "BreakDoors",
        id = "breakdoors.plugin",
        configPrefix = "BreakDoors",
        version = "1.0",
        WWSYSTEMMajor = 6,
        WWSYSTEMMinor = 3,
        WWSYSTEMRevision = 1
        )]
    public class BreakDoors : Plugin
    {
        public override void OnDisable()
        {
            this.Info(this.Details.name + " was disabled");
        }

        public override void OnEnable()
        {
            bool enabled = this.Config.GetBool("breakdoors_enable", true);
            if (!enabled) return;
            this.Info(this.Details.name + " has loaded");
        }

        public override void Register()
        {
            AddEventHandlers(new EventHandler(this));
        }
    }
}
