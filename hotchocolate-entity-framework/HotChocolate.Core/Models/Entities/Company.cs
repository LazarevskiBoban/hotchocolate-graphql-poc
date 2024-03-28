using HotChocolate.Core.Models.Entities.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotChocolate.Core.Models.Entities
{
    public class Company : BaseEntity
    {
        /// <summary>
        ///         Company name
        /// </summary>
        [MinLength(2)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///         Company employees
        /// </summary>
        public IEnumerable<Employee>? Employees { get; set; } = new List<Employee>();
    }
}