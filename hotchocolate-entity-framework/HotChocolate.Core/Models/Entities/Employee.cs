using HotChocolate.Core.Models.Entities.Generic;

namespace HotChocolate.Core.Models.Entities
{
    public class Employee : BaseEntity
    {
        /// <summary>
        ///         Employee name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///         Employee job title
        /// </summary>
        public JobTitle JobTitle { get; set; }

        /// <summary>
        ///         Employee company Id
        /// </summary>
        public Guid? CompanyId { get; set; }

        /// <summary>
        ///         Employee company relation model
        /// </summary>
        public Company? Company { get; set; }
    }

    public enum JobTitle
    {
        Chief,
        DedicatedWorker,
        MiserableWorker
    }
}