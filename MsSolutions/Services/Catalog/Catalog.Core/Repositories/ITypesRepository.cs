﻿using Catalog.Core.Entities;

namespace Catalog.Core.Repositories
{
    public interface ITypesRepository
    {
        Task<IList<ProductType>> GetAllTypes();
    }
}
