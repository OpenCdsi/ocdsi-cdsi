namespace cdsi.evaluation
{
    public interface IEnv
    {
        object Get(object key);
        object Get<T>(object key);
        void Set(object key, object value);
    }
}