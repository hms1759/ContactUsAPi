namespace StartClassTest.ViewModel
{
    public class Message
    {
        public List<string> To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }

        //constructor
        public Message(List<string> to, string subject, string? body = null)
        {
            To = to;
            Subject = subject;
            Body = body;

        }
    }
}
