namespace CodeBase.Interfaces
{
    public interface ICollisionHandler
    {
        void HandleCollision(UnityEngine.Collider2D collider, int damage, string allowedTags);
    }
}