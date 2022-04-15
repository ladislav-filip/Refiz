#region Info

// FileName:    LanguageListQuery.cs
// Author:      Ladislav Filip
// Created:     15.04.2022

#endregion

using AutoMapper;
using Refiz.Domain;
using Refiz.Infrastructure;
using Refiz.Queries.Entities.Models;

namespace Refiz.Queries.Entities.Queries;

public class LanguageListQuery : EfBaseQuery<Language, LanguageItem, Filter>
{
    public LanguageListQuery(RefizContext context, IMapper mapper) : base(context, mapper)
    {
    }
}