﻿namespace ZeUnit.TestRunners;

public abstract class ObservableRunner<TTYpe> : ObservableRunner
{
    public override Type SupportType => typeof(TTYpe);
}