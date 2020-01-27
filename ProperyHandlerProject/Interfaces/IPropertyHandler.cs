namespace ProperyHandlerProject.Interfaces
{
    public interface IPropertyHandler<TInput, TResult>
    {
        TResult Get(TInput input);
        TInput Set(TResult input);
    }
}
