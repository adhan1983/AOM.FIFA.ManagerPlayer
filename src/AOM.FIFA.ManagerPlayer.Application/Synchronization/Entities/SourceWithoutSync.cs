namespace AOM.FIFA.ManagerPlayer.Application.Synchronization.Entities
{
    public class SourceWithoutSync
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public int SyncPageId { get; set; }
        public SyncPage SyncPage { get; set; }
    }
}
