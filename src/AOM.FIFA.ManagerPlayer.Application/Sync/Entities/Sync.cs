using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Application.Sync.Entities
{
    public class Sync
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int TotalItemsPerPage { get; set; }
        public bool Synchronized { get; set; }
        public List<SyncPage> SyncPages { get; set; }
    }
}
