﻿namespace Cairo.Internal;

public partial class FontFaceOwnedHandle : FontFaceHandle
{
    protected override partial bool ReleaseHandle()
    {
        FontFace.Destroy(handle);
        return true;
    }
}
