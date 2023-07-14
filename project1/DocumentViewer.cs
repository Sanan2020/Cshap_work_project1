namespace project1
{
    internal class DocumentViewer
    {
        public object View { get; internal set; }
        public System.Action<object, object> Operation { get; internal set; }
        public object Commands { get; internal set; }
    }
}