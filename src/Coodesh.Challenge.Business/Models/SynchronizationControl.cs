using System;

namespace Coodesh.Challenge.Business.Models
{
    public class SynchronizationControl : Entity<int>
    {
        public int ArticlesCount { get; set; }
        public DateTime CreateAt { get; set; }
    }
}