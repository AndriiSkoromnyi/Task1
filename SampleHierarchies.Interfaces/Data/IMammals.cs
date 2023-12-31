﻿using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Mammals collection.
/// </summary>
public interface IMammals
{
    #region Interface Members

    /// <summary>
    /// Dogs collection.
    /// </summary>
    List<IDog> Dogs { get; set; }

    List<IHorse> Horses { get; set; }

    List<IRabbit> Rabbits { get; set; }

    List<ICat> Cats { get; set; }
    #endregion // Interface Members
}
