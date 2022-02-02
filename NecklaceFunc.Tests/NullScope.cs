using System;

namespace NecklaceFunc.Tests;
public class NullScope : IDisposable
{
    public static NullScope Instance { get; } = new NullScope();

    private NullScope() { }

    public void Dispose() { }
}
