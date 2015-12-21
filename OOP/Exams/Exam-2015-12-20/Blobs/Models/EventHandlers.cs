namespace Blobs.Models
{
    using System;
    using Contracts;

    public delegate void OnToggleBehaviorEventHandler(IBlob sender, EventArgs eventArgs);

    public delegate void OnBlobDeathEventHandler(IBlob sender, EventArgs eventArgs);
}
