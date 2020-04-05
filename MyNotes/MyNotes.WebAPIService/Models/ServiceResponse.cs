using System.Collections.Generic;

namespace MyNotes.WebAPIService.Models
{
    public class ServiceResponse<T>:BaseResponse
    {
        public T Entity { get; set; }
        public List<T> Entities { get; set; }
        public int EntitiesCount { get; set; }
        public ServiceResponse()
        {
            Errors = new List<string>();
            Entities = new List<T>();

        }
    }
}
