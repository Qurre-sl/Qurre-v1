using System.ComponentModel;
namespace Qurre.API.Addons
{
    public interface IConfig
    {
        [Description("Config name")]
        string Name { get; set; }
    }
}