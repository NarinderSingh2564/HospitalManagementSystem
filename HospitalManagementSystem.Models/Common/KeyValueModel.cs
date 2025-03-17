namespace HospitalManagementSystem.Models.Common
{
    public class KeyValueModel<Key, Value>
    {
        public Key key { get; set; }
        public Value value { get; set; }
    }
}