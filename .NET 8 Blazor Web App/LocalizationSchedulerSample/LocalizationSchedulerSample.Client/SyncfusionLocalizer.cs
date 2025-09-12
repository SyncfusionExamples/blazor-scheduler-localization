using Syncfusion.Blazor;
using System.Resources;
using LocalizationSchedulerSample.Client.Resources;


namespace LocalizationSchedulerSample.Client
{
    public class SyncfusionLocalizer : ISyncfusionStringLocalizer
    {
        public string GetText(string key)
        {
            return this.ResourceManager.GetString(key);
        }

        public ResourceManager ResourceManager
        {
            get
            {
                // This now correctly points to the resource file in the client project
                return LocalizationSchedulerSample.Client.Resources.SfResources.ResourceManager;
            }
        }
    }
}
