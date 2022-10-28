#region Info

// FileName:    EntityLogon.cs
// Author:      Ladislav Filip
// Created:     17.04.2022

#endregion

namespace Refiz.Queries.Entities.Models;

public record EntityLogon(int Id, string Email, string Password) : RecordMarker;