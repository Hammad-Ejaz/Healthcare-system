using HealthCare.UI.Resources;
using Syncfusion.Blazor;

namespace HealthCare.UI.Shared
{
    public class SampleLocalizer : ISyncfusionStringLocalizer
    {

        public string GetText(string key)
        {
            return this.ResourceManager.GetString(key);
        }

        public System.Resources.ResourceManager ResourceManager
        {
            get
            {
                return SfResources.ResourceManager;
            }
        }
    }
}