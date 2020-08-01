using System;
using GObject;

namespace WebKit2
{
    public class Settings : GObject.Object
    {
        public Property<bool> AllowFileAccessFromFileUrls { get; }
        public Property<bool> AllowUniversalAccessFromFileUrls { get; }
        public Property<bool> AllowModalDialogs { get; }
        public Property<bool> EnableDeveloperExtras { get; }
        public Property<string> UserAgent { get; }

        internal Settings(IntPtr handle, bool isInitiallyUnowned = false) : base(handle, isInitiallyUnowned)
        {
            AllowFileAccessFromFileUrls = PropertyOfBool("allow-file-access-from-file-urls");
            AllowUniversalAccessFromFileUrls = PropertyOfBool("allow-universal-access-from-file-urls");
            AllowModalDialogs = PropertyOfBool("allow-modal-dialogs");
            EnableDeveloperExtras = PropertyOfBool("enable-developer-extras");
            UserAgent = PropertyOfString("user-agent");
        }
    }
}