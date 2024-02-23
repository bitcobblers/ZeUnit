﻿// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Composers;


public class CoreClassComposer : IZeClassComposer
{
    private bool disposedValue;
    private readonly Type @class;

    public CoreClassComposer(Type @class)
    {
        this.@class = @class;
    }

    public object? Get(Type @class)
    {
        return Activator.CreateInstance(@class);        
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
