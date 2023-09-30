namespace WebApplication2
{
    public class TaskObject
    {
        private string _id;
        private string _name;
        public string Id { get { return _id; } }
        public string Name { get { return _name; } }

        public TaskObject(string id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}
