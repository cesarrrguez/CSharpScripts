public interface IProcess<TInput, TOutput>
        where TInput : class
        where TOutput : class
{
    TOutput Execute(TInput parameters);
}
