﻿namespace BullsAndCows.Contracts
{
    public interface IRandomNumberProvider
    {
        IRandomNumberProvider Instance { get; }

        int GenerateNumber();
    }
}