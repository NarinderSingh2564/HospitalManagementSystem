namespace HospitalManagementSystem.Models.Common
{
    public class ReturnResponseModel<T>
    {
        public bool status { get; set; }
        public string message { get; set; }
        public T Data { get; set; }
    }
}
