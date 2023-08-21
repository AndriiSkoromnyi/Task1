﻿using System.ComponentModel;
/// <summary>
/// Dummy enum.
/// </summary>
public enum MammalSpecies
{
    [Description("Simple description of a none")]
    None = 0,
    [Description("Simple description of a dog")]
    Dog = 1,
    [Description("Simple description of a horse")]
    Horse = 2,
    [Description("Simple description of a rabbit")]
    Rabbit = 3,
    [Description("Simple description of a cat")]
    Cat = 4,
}