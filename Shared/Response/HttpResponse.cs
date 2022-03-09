namespace Havbruksloggen_Coding_Challenge.Shared.Responses
{
    public class HttpResponse<T>
    {
        public T Result { get; set; }
        public string Message { get; set; }
    }
}
