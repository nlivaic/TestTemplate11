using System.Collections.Generic;
using TestTemplate11.Application.Sorting.Models;

namespace TestTemplate11.Application.Sorting
{
    public interface IPropertyMappingService
    {
        IEnumerable<SortCriteria> Resolve(BaseSortable sortableSource, BaseSortable sortableTarget);
    }
}
