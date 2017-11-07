using System;
using System.ComponentModel.DataAnnotations;
using SuperUserWeb.Domain.Enums;

namespace SuperUserWeb.Domain
{
    public abstract class BaseDomain<T>
    {
        [Key]
        public T Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public EState State { get; set; }
    }
}