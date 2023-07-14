using System.Windows.Forms;

namespace Leadtools
{
    internal class Documents
    {
        internal class UI
        {
            internal class DocumentViewerCreateOptions
            {
                public DocumentViewerCreateOptions()
                {
                }

                public SplitterPanel ViewContainer { get; internal set; }
                public SplitterPanel ThumbnailsContainer { get; internal set; }
                public Control BookmarksContainer { get; internal set; }
                public bool UseAnnotations { get; internal set; }
            }
        }
    }
}