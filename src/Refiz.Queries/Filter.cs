#region Info

// FileName:    Filter.cs
// Author:      Ladislav Filip
// Created:     15.04.2022

#endregion

namespace Refiz.Queries;

public record Filter(int Limit = 0, int Skip = 0);