using Microsoft.AspNetCore.Components;

namespace TabBlazor.Components
{
    public interface ITab
    {
        string Title { get; }
        RenderFragment ChildContent { get; }

        bool IsEnabled { get; set; }
    }
}
